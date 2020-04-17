using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace DonkeyWebApp.API.Models
{
    public class RepairNote
    {
        [JsonProperty("id")]
        [Description("For internal use -- may not be accurate/present in all queries. (Ignored on API POST.)")]
        public int Id { get; set; }

        [JsonProperty("repairId")]
        [Description("SASSHA repair ID.")]
        public string RepairId { get; set; }

        [JsonProperty("text")]
        [Description("Text of the note.")]
        public string Text { get; set; }

        [JsonProperty("date")]
        [Description("The entry date of this note with no time component. (Ignored on API POST.)")]
        public DateTime Date { get; set; }

        [JsonProperty("dateTime")]
        [Description("The datetime of this note. (Ignored on API POST.)")]
        public DateTime DateTime { get; set; }

        [JsonProperty("type")]
        [Description("Values: APPOINTMENT, AUTHORISED, CANCEL REPAIR, CANCELLED, COMPLETED, DATE CHANGED, DOCUMENT ADDED, GENERIC, JOB CANCELLED, JOB COMPLETED, JOB UPDATED, MISSED VISIT, NEW REPAIR, NO ACCESS, POST_INSPECT, PRE_INSPECT, PRINTING, PROGRESS, PROGRESS CHANGE, QUOTE ADDED, SOR ADD, SOR CHANGE, SOR DELETE, TEST_NOTE, TSS, VARY, VISIT ADD")]
        public string Type { get; set; }

        [JsonProperty("username")]
        [Description("SASSHA username of note creator. (Ignored on API POST.)")]
        public string Username { get; set; }
    }
}