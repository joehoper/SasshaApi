using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    [Description("A warning/risk pertaining to a property or tenant")]
    public class Warning
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("isCritical")]
        public bool IsCritical { get; set; }

        public override string ToString()
        {
            return IsCritical
                ? $"!!! {Type}: {Text} !!!"
                : $"{Type}: {Text}";
        }
    }
}