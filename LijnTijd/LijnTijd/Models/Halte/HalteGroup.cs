using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LijnTijd.Models.Halte
{
    public class HalteGroup
    {
        [JsonProperty(PropertyName = "haltes")]
        public List<Halte> Haltes { get; set; }

    }
}
