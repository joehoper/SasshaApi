using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyExampleApp
{
    public class Config
    {
        [JsonProperty("apiUrl")]
        public string ApiUrl { get; set; }

        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("contractorCode")]
        public string ContractorCode { get; set; }

        [JsonProperty("lastPoll")]
        public DateTime LastPoll { get; set; }
    }
}