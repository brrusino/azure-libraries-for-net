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
    using Rest;
    using Rest.Azure;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Resource Id.
    /// </summary>
    [JsonTransformation]
    public partial class VirtualMachineCaptureResultInner : Microsoft.Azure.Management.Resource.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the VirtualMachineCaptureResultInner
        /// class.
        /// </summary>
        public VirtualMachineCaptureResultInner() { }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineCaptureResultInner
        /// class.
        /// </summary>
        /// <param name="output">Operation output data (raw JSON)</param>
        public VirtualMachineCaptureResultInner(string id = default(string), object output = default(object))
            : base(id)
        {
            Output = output;
        }

        /// <summary>
        /// Gets or sets operation output data (raw JSON)
        /// </summary>
        [JsonProperty(PropertyName = "properties.output")]
        public object Output { get; set; }

    }
}

