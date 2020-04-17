using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DonkeyWebApp.API.Models
{
    [Description("A phone number and note")]
    public class PhoneNumber
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("isMobile")]
        public bool IsMobile { get; set; }

        public override string ToString()
        {
            return $"{Note} = {Number}{(IsMobile ? " (mobile)" : "")}";
        }
    }
}