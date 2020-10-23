using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LijnTijd.Models.Doorkomsten
{
    public class DoorkomstGroup
    {
        [JsonProperty(PropertyName = "halteDoorkomsten")]
        public List<Doorkomst> Doorkomsten { get; set; }

    }
}
