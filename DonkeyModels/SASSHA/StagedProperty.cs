using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    public class StagedProperty
    {
        [JsonProperty("id")]
        public Guid PropertyID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("addressLine3")]
        public string AddressLine3 { get; set; }

        [JsonProperty("town")]
        public string Town { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("providerId")]
        public Guid ProviderId { get; set; }

        [JsonProperty("providerName")]
        public string ProviderName { get; set; }

        [JsonProperty("coreRent")]
        public decimal CoreRent { get; set; }

        [JsonProperty("proposedHandoverDate")]
        public DateTime ProposedHandover { get; set; }

        [JsonProperty("unitCount")]
        public int UnitCount { get; set; }

        [JsonProperty("communalCount")]
        public int CommunalCount { get; set; }

        [JsonProperty("processed")]
        public bool Processed { get; set; }
    }
}