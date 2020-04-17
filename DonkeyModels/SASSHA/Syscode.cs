using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DonkeyWebApp.API.Models
{
    public class SysCode
    {
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("recCode")]
        public string RecCode { get; set; }

        [JsonProperty("codeIsSys")]
        public bool CodeIsSys { get; set; }

        public override string ToString() => $"{Prefix}.{Code} = {Text}";
    }
}