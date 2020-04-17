using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    public class AssetStay
    {
        [JsonProperty("assetId")]
        public int AssetId { get; set; }

        [JsonProperty("location")]
        public AssetLocation Location { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("addedBy")]
        public AssetUser AddedBy { get; set; }
    }
}