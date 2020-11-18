using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LijnTijd.Models;
using LijnTijd.Models.Doorkomsten;
using LijnTijd.Models.Halte;
using LijnTijd.Models.Lijn;
using Newtonsoft.Json;

namespace LijnTijd.Repositories
{
    public static class LineRpository
    {

        public const string _URI = "https://api.delijn.be/DLKernOpenData/v1/beta/";

        private static HttpClient getHttpClient()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "d464fe14cef04884b8b734f2fc0779a4");
            return client;

        }

        public static async Task<Halte> getHalte(long entiteit, string halte)
        {
            try
            {

                string url = $"{_URI}haltes/{entiteit}/{halte}";

                using (HttpClient client = getHttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    Halte halteGroup = JsonConvert.DeserializeObject<Halte>(json);

                    return halteGroup;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<HalteGroup> getHaltesNearby(double latitude, double longtitude, double distance)
        {
            try
            {
                
                string url = $"{_URI}haltes/indebuurt/{latitude},{longtitude}?radius={distance}";

                using (HttpClient client = getHttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    HalteGroup halteGroup = JsonConvert.DeserializeObject<HalteGroup>(json);
                    
                    return halteGroup;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            

        }

        public static async Task<string> GetLijnHex(string url2)
        {
            try
            {
                string url = url2;

                using (HttpClient client = getHttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    HexKleur halteGroup = JsonConvert.DeserializeObject<HexKleur>(json);




                    return "#" +  halteGroup.Hex;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public static async Task<string> getLijnKleur(long entiteit, long lijn)
        {
            try
            {
                string url = $"https://api.delijn.be/DLKernOpenData/v1/beta/lijnen/{entiteit}/{lijn}/lijnkleuren";

                using (HttpClient client = getHttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    LijnKleuren halteGroup = JsonConvert.DeserializeObject<LijnKleuren>(json);

                    string hexurl = "";

                    foreach (Link link in halteGroup.Achtergrond.Links)
                    {
                        if (link.rel.Equals("detail")) hexurl = link.url;
                    }

                    string hex = await GetLijnHex(hexurl);


                    return hex;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }



        public static async Task<Lijn> GetLijn(long entiteit, long lijn)
        {
            try
            {
                string url = $"{_URI}lijnen/{entiteit}/{lijn}";

                using (HttpClient client = getHttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    Lijn halteGroup = JsonConvert.DeserializeObject<Lijn>(json);
                    return halteGroup;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        public static async Task<string> GetAddress(float longt, float lat)
        {
            try
            {
                string url = $"https://api.opencagedata.com/geocode/v1/json?q={longt}+{lat}&key=daef7b806a7947eda3da3e8746e8658d";

                using (HttpClient client = getHttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    GeoResultGroup halteGroup = JsonConvert.DeserializeObject<GeoResultGroup>(json);
                    return halteGroup.Results[0].Formatted;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        public static async Task<HalteGroup> GetHaltes(DoorkomstProperties properties)
        {
            try
            {
                string url = $"{_URI}lijnen/{properties.Entiteitnummer}/{properties.Lijnnummer}/lijnrichtingen/{properties.Richting}/haltes";

                using (HttpClient client = getHttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    HalteGroup halteGroup = JsonConvert.DeserializeObject<HalteGroup>(json);

                    List<Halte> haltes = new List<Halte>();
                    foreach (Halte halte in halteGroup.Haltes)
                    {

                        Halte h = await getHalte(properties.Entiteitnummer, halte.HalteNummer);
                        haltes.Add(h);
                    }

                    halteGroup.Haltes = haltes;

                    foreach (Halte halte in halteGroup.Haltes)
                    {
                        Console.WriteLine(halte.geoCoordinaat.Latitude + " " + halte.geoCoordinaat.Longitude);
                        halte.Address = await LineRpository.GetAddress(halte.geoCoordinaat.Latitude, halte.geoCoordinaat.Longitude);
                    }


                    
                    return halteGroup;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        public static async Task<DoorkomstGroup> GetDoorKomsten(Halte halte)
        {

            try
            {
                string url = "";

                foreach (Link link in halte.links)
                {

                    if (link.rel.Equals("dienstregelingen")) url = link.url;

                }
                
                using (HttpClient client = getHttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    DoorkomstGroup halteGroup = JsonConvert.DeserializeObject<DoorkomstGroup>(json);

                    foreach (Doorkomst doorkomst in halteGroup.Doorkomsten)
                    {
                        foreach (DoorkomstProperties doorkomstPropertiese in doorkomst.Doorkomsts)
                        {
                            Lijn lijn = await GetLijn(doorkomstPropertiese.Entiteitnummer,
                                doorkomstPropertiese.Lijnnummer);

                            string color = await getLijnKleur(lijn.Entiteitnummer, lijn.Lijnnummer);

                            doorkomstPropertiese.Color = color;
                            doorkomstPropertiese.Lijn = lijn;

                        }
                    }



                    return halteGroup;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
