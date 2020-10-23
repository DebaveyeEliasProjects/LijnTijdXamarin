using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LijnTijd.Models.Doorkomsten
{
    public class Doorkomst
    {
        [JsonProperty(PropertyName = "doorkomsten")]
        public List<DoorkomstProperties> Doorkomsts { get; set; }
    }
}
