using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace DonkeyWebApp.API.Models
{
    [Description("A SASSHA repair record")]
    public class Repair
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("contractorId")]
        public string ContractorId { get; set; }

        [JsonProperty("propertyId")]
        public string PropertyId { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("recorded")]
        public DateTime Recorded { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("access")]
        public string Access { get; set; }

        [JsonProperty("scheduleItems")]
        public ScheduleItem[] ScheduleItems { get; set; }

        [JsonProperty("notes")]
        public RepairNote[] Notes { get; set; }

        [JsonProperty("workTypeCode")]
        public string WorkTypeCode { get; set; }

        [JsonProperty("workTypeDescription")]
        public string WorkTypeDescription { get; set; }

        [JsonProperty("priorityCode")]
        public string PriorityCode { get; set; }

        [JsonProperty("priorityDescription")]
        public string PriorityDescription { get; set; }

        [JsonProperty("partnerData")]
        public Dictionary<string, string> PartnerData { get; set; } = new Dictionary<string, string>();
    }
}