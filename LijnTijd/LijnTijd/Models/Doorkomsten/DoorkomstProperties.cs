using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LijnTijd.Models.Doorkomsten
{
    public class DoorkomstProperties : IComparable<DoorkomstProperties>
    {

        [JsonProperty("entiteitnummer")]
        public long Entiteitnummer { get; set; }

        [JsonProperty("lijnnummer")]
        public long Lijnnummer { get; set; }

        [JsonProperty("richting")]
        public string Richting { get; set; }

        [JsonProperty("ritnummer")]
        public long Ritnummer { get; set; }

        [JsonProperty("bestemming")]
        public string Bestemming { get; set; }

        [JsonProperty("vias")]
        public string[] Vias { get; set; }

        [JsonProperty("dienstregelingTijdstip")]
        public DateTimeOffset DienstregelingTijdstip { get; set; }

        [JsonProperty("real-timeTijdstip")]
        public DateTimeOffset RealTimeTijdstip { get; set; }

        public string TimeFormat
        {
            get
            {
                return DienstregelingTijdstip.ToString("HH:mm");
            }
            set
            {
                TimeFormat = "";
            }
        }

        [JsonProperty("vrtnum")]
        public string Vrtnum { get; set; }

        [JsonProperty("predictionStatussen")]
        public string[] PredictionStatussen { get; set; }

        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        public string Color { get; set; }

        public Lijn.Lijn Lijn { get; set; }


        public int CompareTo(DoorkomstProperties other)
        {
            return DateTimeOffset.Compare(DienstregelingTijdstip, other.DienstregelingTijdstip);
        }
    }
}
