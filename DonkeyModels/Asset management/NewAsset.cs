using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    public class NewAsset
    {
        [JsonProperty("tag"), MaxLength(50)]
        public string Tag { get; set; }

        [JsonProperty("serial"), MaxLength(50)]
        public string Serial { get; set; }

        [JsonProperty("manufacturer"), MaxLength(50)]
        public string Manufacturer { get; set; }

        [JsonProperty("model"), MaxLength(50)]
        public string Model { get; set; }

        [JsonProperty("os"), MaxLength(50)]
        public string Os { get; set; }

        [JsonProperty("locationId")]
        public int LocationId { get; set; }

        [JsonProperty("typeId")]
        public int TypeId { get; set; }

        [JsonProperty("conditionId")]
        public int ConditionId { get; set; }
    }
}