using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LijnTijd.Models.Lijn
{
    public class LijnKleuren
    {

        [JsonProperty("achtergrond")]
        public Achtergrond Achtergrond { get; set; }

    }
}
