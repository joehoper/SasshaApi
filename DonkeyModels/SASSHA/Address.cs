using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace DonkeyWebApp.API.Models
{
    public class Address
    {
        [JsonProperty("lines")]
        public string[] Lines { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("town")]
        public string Town { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("formatted")]
        [Description("Address formatted with CRLF linebreaks")]
        public string Formatted { get; set; }

        [JsonProperty("html")]
        [Description("Address formated with HTML linebreaks")]
        public string Html { get; set; }
    }
}