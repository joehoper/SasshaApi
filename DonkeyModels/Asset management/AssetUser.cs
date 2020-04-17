using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    public class AssetUser
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}