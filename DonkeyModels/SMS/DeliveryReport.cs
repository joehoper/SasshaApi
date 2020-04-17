using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace DonkeyWebApp.API.Models
{
    public class DeliveryReport
    {
        public string MessageId { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
        public string ClientId { get; set; }        
    }
}