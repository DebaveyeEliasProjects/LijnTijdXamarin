using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LijnTijd.Repositories;
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
        [JsonProperty(PropertyName = "haltenummer")]
        public string HalteNummer { get; set; }
        [JsonProperty(PropertyName = "naam")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "afstand")]
        public int Distance { get; set; }

        public GeoCoord geoCoordinaat { get; set; }


        public bool isCurrent = false;

        public Color Background
        {
            get
            {
                if (isCurrent)
                {
                    Console.WriteLine("eeee");
                    return Color.FromHex("85e085");
                }
                else
                {
                    Console.WriteLine("ffff");
                    return Color.FromHex("ffffff");
                }
            }
            
        }

        public string Address { get; set; }


        public string Omschrijving { get; set; }

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
