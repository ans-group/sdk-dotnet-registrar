using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Json;
using UKFast.API.Client.Models;

namespace UKFast.API.Client.Registrar.Models
{
    public class Domain : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("registrar")]
        public string Registrar { get; set; }

        [Newtonsoft.Json.JsonProperty("registered_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime RegisteredAt { get; set; }

        [Newtonsoft.Json.JsonProperty("updated_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("renewal_at")]
        [Newtonsoft.Json.JsonConverter(typeof(DateTimeConverter))]
        public DateTime RenewalAt { get; set; }

        [Newtonsoft.Json.JsonProperty("auto_renew")]
        public bool AutoRenew { get; set; }

        [Newtonsoft.Json.JsonProperty("whois_privacy")]
        public bool WHOISPrivacy { get; set; }
    }
}
