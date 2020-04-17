using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DonkeyWebApp.API.Models
{
    [Description("Describes an exception")]
    public class Error
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("stackTrace")]
        public string StackTrace { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("innerError")]
        public Error InnerError { get; set; }

        [JsonProperty("targetSite")]
        public string TargetSite { get; set; }
    }
}