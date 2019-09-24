using System;
using System.Collections.Generic;
using System.Text;
using UKFast.API.Client.Models;

namespace UKFast.API.Client.Registrar.Models
{
    public class Nameserver : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("host")]
        public string Host { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public string IP { get; set; }
    }
}
