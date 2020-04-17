using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonkeyWebApp.API.Models
{
    public class IncomingSms
    {
        public string Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Keyword { get; set; }
        public string Content { get; set; }
    }
}