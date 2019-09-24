using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UKFast.API.Client.Registrar.Models
{
    public class Whois
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public IEnumerable<string> Status { get; set; }

        [Newtonsoft.Json.JsonProperty("created_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("updated_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("expires_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime ExpiresAt { get; set; }

        [Newtonsoft.Json.JsonProperty("nameservers")]
        public IEnumerable<Nameserver> Nameservers { get; set; }
    }
}
