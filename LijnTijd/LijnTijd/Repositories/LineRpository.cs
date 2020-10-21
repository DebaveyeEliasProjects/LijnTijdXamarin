using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LijnTijd.Models.Halte;
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

    }
}
