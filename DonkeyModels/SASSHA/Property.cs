using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DonkeyWebApp.API.Models
{
    [Description("A SASSHA customer property record")]
    public class Property
    {
        [JsonProperty("id")]
        public string PropertyId { get; set; }

        [JsonProperty("scheme")]
        public string Scheme { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("bedrooms")]
        public int Bedrooms { get; set; }

        [JsonProperty("bedspaces")]
        public int Bedspaces { get; set; }

        [JsonProperty("company")]
        public int Company { get; set; }

        [JsonProperty("localAuthority")]
        public string LocalAuthority { get; set; }

        [JsonProperty("landlord")]
        public string Landlord { get; set; }

        [JsonProperty("warnings")]
        public List<Warning> Warnings { get; set; } = new List<Warning>();

        [JsonProperty("isVoid")]
        public bool IsVoid { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("partnerData")]
        public Dictionary<string, string> PartnerData { get; set; } = new Dictionary<string, string>();
    }
}