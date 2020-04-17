using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    public class AssetLocation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name"), MaxLength(50)]
        public string Name { get; set; }

        [JsonProperty("company")]
        public AssetCompany Company { get; set; }

        [JsonProperty("glyph"), MaxLength(50)]
        public string Glyph { get; set; }
    }
}