using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DonkeyWebApp.API.Models
{
    [Description("A response to a fired trigger action")]
    public class TriggerResponse
    {
        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("ignored")]
        [Description("True if ignored by forward API binding.")]
        public bool Ignored { get; set; }
    }
}