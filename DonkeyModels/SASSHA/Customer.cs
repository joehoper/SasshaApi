using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DonkeyWebApp.API.Models
{
    [Description("A SASSHA customer record")]
    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string EmailAdd { get; set; }

        [JsonProperty("phoneNumbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

        [JsonProperty("warnings")]
        public List<Warning> Warnings { get; set; } = new List<Warning>();

        [JsonProperty("address")]
        public Address Address { get; set; }

        public override string ToString()
        {
            string title = string.IsNullOrEmpty(Title) ? "" : $"{Title} ";

            return $"{title}{FirstName} {LastName}";
        }
    }
}