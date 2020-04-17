using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    public class Asset
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("company")]
        public AssetCompany Company { get; set; }

        [JsonProperty("tag"), MaxLength(50)]
        public string Tag { get; set; }

        [JsonProperty("serial"), MaxLength(50)]
        public string Serial { get; set; }

        [JsonProperty("type")]
        public AssetType Type { get; set; }

        [JsonProperty("manufacturer"), MaxLength(50)]
        public string Manufacturer { get; set; }

        [JsonProperty("model"), MaxLength(50)]
        public string Model { get; set; }

        [JsonProperty("os"), MaxLength(50)]
        public string Os { get; set; }

        [JsonProperty("added")]
        public DateTime Added { get; set; }

        [JsonProperty("addedBy")]
        public AssetUser AddedBy { get; set; }

        [JsonProperty("stays")]
        [Description("Records of the asset's stay in locations.")]
        public AssetStay[] Stays { get; set; }

        [JsonProperty("states")]
        [Description("Records of the asset's state through conditions.")]
        public AssetState[] States { get; set; }
    }
}