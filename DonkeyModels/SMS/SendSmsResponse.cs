using System;
using System.Collections.Generic;
using System.Linq;

namespace DonkeyWebApp.API.Models
{
    public class SendSmsResponse
    {
        public string To { get; set; }
        public string MessageID { get; set; }
        public int ErrorNo { get; set; }
        public string ErrorDesc { get; set; }
        public bool IsSuccess { get; set; }

        public string Status => IsSuccess ? "SENT" : $"SEND ERROR: {ErrorNo}: {ErrorDesc}";
    }
}