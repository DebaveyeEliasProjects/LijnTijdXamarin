using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LijnTijd.Models.Halte
{
    public class Halte
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "naam")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "afstand")]
        public int Distance { get; set; }

        public ImageSource Image
        {
            get
            {
                return ImageSource.FromResource("LijnTijd.Assets.bus-stop.png");
            }

        }

        public ImageSource InfoImage
        {
            get
            {
                return ImageSource.FromResource("LijnTijd.Assets.info.png");
            }

        }
        
        [JsonProperty(PropertyName = "links")]
        public List<Link> links { get; set; }

    }
}
