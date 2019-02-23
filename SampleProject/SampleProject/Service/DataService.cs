using Newtonsoft.Json;
using SampleProject.Model;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleProject.Service
{
    public class DataService : IDataService
    {
        private const string Uri = "https://api.binance.com/api/v1/depth?symbol=ETHBTC&limit=1000";
        private readonly HttpClient client;
        public DataService()
        {
            client = new HttpClient();
        }

        public async Task<Info> GetInfo()
        {
            var info = new Info();
            try
            {
                var response = await client.GetAsync(Uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    info = JsonConvert.DeserializeObject<Info>(content, new CustomDeserialization());
                }
            }
            catch (Exception ex)
            {
                //TODO
                Debug.WriteLine("Something went wrong...");
            }

            return info;
        }
    }
}
