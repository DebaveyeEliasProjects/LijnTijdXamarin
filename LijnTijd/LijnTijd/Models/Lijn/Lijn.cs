using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LijnTijd.Models.Lijn
{
    public class Lijn
    {
        private Link[] _links;

        [JsonProperty("entiteitnummer")]
        public long Entiteitnummer { get; set; }

        [JsonProperty("lijnnummer")]
        public long Lijnnummer { get; set; }

        [JsonProperty("lijnnummerPubliek")]
        public long LijnnummerPubliek { get; set; }

        [JsonProperty("omschrijving")]
        public string Omschrijving { get; set; }

        [JsonProperty("publiek")]
        public bool Publiek { get; set; }

        [JsonProperty("vervoertype")]
        public string Vervoertype { get; set; }

        [JsonProperty("bedieningtype")]
        public string Bedieningtype { get; set; }

        [JsonProperty("lijnGeldigVan")]
        public DateTimeOffset LijnGeldigVan { get; set; }

        [JsonProperty("lijnGeldigTot")]
        public DateTimeOffset LijnGeldigTot { get; set; }

        [JsonProperty("links")]
        public List<Link> Links
        {
            get;
            set;
        }
    }
}
