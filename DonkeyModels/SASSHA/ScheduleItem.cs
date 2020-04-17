using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace DonkeyWebApp.API.Models
{
    [Description("A repair schedule item")]
    public class ScheduleItem
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("claimedQuantity")]
        public decimal ClaimedQuantity { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("uplift")]
        public decimal Uplift { get; set; }

        [JsonProperty("linePosted")]
        public DateTime LinePosted { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("workType")]
        public string WorkType { get; set; }
    }
}