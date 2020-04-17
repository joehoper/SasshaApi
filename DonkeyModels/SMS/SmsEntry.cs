using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonkeyWebApp.API.Models
{
    public class SmsEntry
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public DateTime? Updated { get; set; }
        public string Direction { get; set; }
        public string Nominal { get; set; }
    }
}