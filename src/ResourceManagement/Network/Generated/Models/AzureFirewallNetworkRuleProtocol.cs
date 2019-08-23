// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Management.ResourceManager;
    using Management.ResourceManager.Fluent;
    using Management.ResourceManager.Fluent.Core;

    using Newtonsoft.Json;
    /// <summary>
    /// Defines values for AzureFirewallNetworkRuleProtocol.
    /// </summary>
    /// <summary>
    /// Determine base value for a given allowed value if exists, else return
    /// the value itself
    /// </summary>
    [JsonConverter(typeof(Management.ResourceManager.Fluent.Core.ExpandableStringEnumConverter<AzureFirewallNetworkRuleProtocol>))]
    public class AzureFirewallNetworkRuleProtocol : Management.ResourceManager.Fluent.Core.ExpandableStringEnum<AzureFirewallNetworkRuleProtocol>
    {
        public static readonly AzureFirewallNetworkRuleProtocol TCP = Parse("TCP");
        public static readonly AzureFirewallNetworkRuleProtocol UDP = Parse("UDP");
        public static readonly AzureFirewallNetworkRuleProtocol Any = Parse("Any");
        public static readonly AzureFirewallNetworkRuleProtocol ICMP = Parse("ICMP");
    }
}