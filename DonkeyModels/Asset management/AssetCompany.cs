using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    public class AssetCompany
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name"), MaxLength(50)]
        public string Name { get; set; }

        [JsonProperty("shortName"), MaxLength(50)]
        public string ShortName { get; set; }
    }
}