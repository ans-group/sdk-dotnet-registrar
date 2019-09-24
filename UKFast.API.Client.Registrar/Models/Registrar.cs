using System;
using System.Collections.Generic;
using System.Text;

namespace UKFast.API.Client.Registrar.Models
{
    public class Registrar
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public string URL { get; set; }

        [Newtonsoft.Json.JsonProperty("iana_id")]
        public int IANAID { get; set; }
    }
}
