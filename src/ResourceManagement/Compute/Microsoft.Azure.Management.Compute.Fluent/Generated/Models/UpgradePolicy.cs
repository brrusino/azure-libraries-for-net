// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Azure;
    using Management;
    using Compute;
    using Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes an upgrade policy - automatic or manual.
    /// </summary>
    public partial class UpgradePolicy
    {
        /// <summary>
        /// Initializes a new instance of the UpgradePolicy class.
        /// </summary>
        public UpgradePolicy() { }

        /// <summary>
        /// Initializes a new instance of the UpgradePolicy class.
        /// </summary>
        /// <param name="mode">The upgrade mode. Possible values include:
        /// 'Automatic', 'Manual'</param>
        public UpgradePolicy(UpgradeMode? mode = default(UpgradeMode?))
        {
            Mode = mode;
        }

        /// <summary>
        /// Gets or sets the upgrade mode. Possible values include:
        /// 'Automatic', 'Manual'
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public UpgradeMode? Mode { get; set; }

    }
}

