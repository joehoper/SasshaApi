using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace DonkeyWebApp.API.Models
{
    public class Document
    {
        [JsonProperty("fileKey")]
        public string FileKey { get; set; }

        [JsonProperty("fluff")]
        public string Fluff { get; set; }

        [JsonProperty("validUntil")]
        public DateTime ValidUntil { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }
    }
}