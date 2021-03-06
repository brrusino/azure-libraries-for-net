// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Parameters that determine how the connectivity check will be performed.
    /// </summary>
    public partial class ConnectivityParameters
    {
        /// <summary>
        /// Initializes a new instance of the ConnectivityParameters class.
        /// </summary>
        public ConnectivityParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ConnectivityParameters class.
        /// </summary>
        /// <param name="source">Describes the source of the
        /// connection.</param>
        /// <param name="destination">Describes the destination of
        /// connection.</param>
        /// <param name="protocol">Network protocol. Possible values include:
        /// 'Tcp', 'Http', 'Https', 'Icmp'</param>
        /// <param name="protocolConfiguration">Configuration of the
        /// protocol.</param>
        /// <param name="preferredIPVersion">Preferred IP version of the
        /// connection. Possible values include: 'IPv4', 'IPv6'</param>
        public ConnectivityParameters(ConnectivitySource source, ConnectivityDestination destination, Protocol protocol = default(Protocol), ProtocolConfiguration protocolConfiguration = default(ProtocolConfiguration), IPVersion preferredIPVersion = default(IPVersion))
        {
            Source = source;
            Destination = destination;
            Protocol = protocol;
            ProtocolConfiguration = protocolConfiguration;
            PreferredIPVersion = preferredIPVersion;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets describes the source of the connection.
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public ConnectivitySource Source { get; set; }

        /// <summary>
        /// Gets or sets describes the destination of connection.
        /// </summary>
        [JsonProperty(PropertyName = "destination")]
        public ConnectivityDestination Destination { get; set; }

        /// <summary>
        /// Gets or sets network protocol. Possible values include: 'Tcp',
        /// 'Http', 'Https', 'Icmp'
        /// </summary>
        [JsonProperty(PropertyName = "protocol")]
        public Protocol Protocol { get; set; }

        /// <summary>
        /// Gets or sets configuration of the protocol.
        /// </summary>
        [JsonProperty(PropertyName = "protocolConfiguration")]
        public ProtocolConfiguration ProtocolConfiguration { get; set; }

        /// <summary>
        /// Gets or sets preferred IP version of the connection. Possible
        /// values include: 'IPv4', 'IPv6'
        /// </summary>
        [JsonProperty(PropertyName = "preferredIPVersion")]
        public IPVersion PreferredIPVersion { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Source == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Source");
            }
            if (Destination == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Destination");
            }
            if (Source != null)
            {
                Source.Validate();
            }
        }
    }
}
