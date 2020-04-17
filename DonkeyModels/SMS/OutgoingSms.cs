using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonkeyWebApp.API.Models
{
    public class OutgoingSms
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Text { get; set; }
        public string Nominal { get; set; }
    }
}