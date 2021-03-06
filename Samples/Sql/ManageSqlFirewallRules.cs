// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageSqlFirewallRules
{
    public class Program
    {
        private static readonly string AdministratorLogin = "sqladmin3423";
        private static readonly string AdministratorPassword = Utilities.CreatePassword();
        private static readonly string FirewallRuleIPAddress = "10.0.0.1";
        private static readonly string FirewallRuleStartIPAddress = "10.2.0.1";
        private static readonly string FirewallRuleEndIPAddress = "10.2.0.10";
        private static readonly string MyFirewallName = "myFirewallRule";
        private static readonly string MyFirewallRuleIPAddress = "10.10.10.10";
        private static readonly string OtherFirewallRuleStartIPAddress = "121.12.12.1";
        private static readonly string OtherFirewallRuleEndIPAddress = "121.12.12.10";
        
        /**
         * Azure Storage sample for managing SQL Database -
         *  - Create a SQL Server along with 2 firewalls.
         *  - Add another firewall in the SQL Server
         *  - List all firewalls.
         *  - Get a firewall.
         *  - Update a firewall.
         *  - Delete a firewall.
         *  - Add and delete a firewall as part of update of SQL Server
         *  - Delete Sql Server
         */
        public static void RunSample(IAzure azure)
        {
            string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
            string rgName = SdkContext.RandomResourceName("rgRSSDFW", 20);
            
            try
            {
                // ============================================================
                // Create a SQL Server, with 2 firewall rules.
                Utilities.Log("Create a SQL server with 2 firewall rules adding a single IP Address and a range of IP Addresses");

                var sqlServer = azure.SqlServers.Define(sqlServerName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(AdministratorLogin)
                        .WithAdministratorPassword(AdministratorPassword)
                        .WithNewFirewallRule(FirewallRuleIPAddress)
                        .WithNewFirewallRule(FirewallRuleStartIPAddress, FirewallRuleEndIPAddress)
                        .Create();

                Utilities.PrintSqlServer(sqlServer);

                // ============================================================
                // List and delete all firewall rules.
                Utilities.Log("Listing all firewall rules in SQL Server.");

                var firewallRules = sqlServer.FirewallRules.List();
                foreach (var firewallRule in firewallRules)
                {
                    // Print information of the firewall rule.
                    Utilities.PrintFirewallRule(firewallRule);

                    // Delete the firewall rule.
                    Utilities.Log("Deleting a firewall rule");
                    firewallRule.Delete();
                }

                // ============================================================
                // Add new firewall rules.
                Utilities.Log("Creating a firewall rule in existing SQL Server");
                var newFirewallRule = sqlServer.FirewallRules.Define(MyFirewallName)
                        .WithIPAddress(MyFirewallRuleIPAddress)
                        .Create();

                Utilities.PrintFirewallRule(newFirewallRule);
                Utilities.Log("Get a particular firewall rule in SQL Server");

                newFirewallRule = sqlServer.FirewallRules.Get(MyFirewallName);
                Utilities.PrintFirewallRule(newFirewallRule);

                Utilities.Log("Deleting and adding new firewall rules as part of SQL Server update.");
                sqlServer.Update()
                        .WithoutFirewallRule(MyFirewallName)
                        .WithNewFirewallRule(OtherFirewallRuleStartIPAddress, OtherFirewallRuleEndIPAddress)
                        .Apply();

                foreach (var sqlFirewallRule in sqlServer.FirewallRules.List())
                {
                    // Print information of the firewall rule.
                    Utilities.PrintFirewallRule(sqlFirewallRule);
                }

                // Delete the SQL Server.
                Utilities.Log("Deleting a Sql Server");
                azure.SqlServers.DeleteById(sqlServer.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception e)
                {
                    Utilities.Log(e);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }
    }
}