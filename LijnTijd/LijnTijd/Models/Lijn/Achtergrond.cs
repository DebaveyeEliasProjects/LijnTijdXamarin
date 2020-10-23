using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LijnTijd.Models.Lijn
{
    public class Achtergrond
    {

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }
    }
}
