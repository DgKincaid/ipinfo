using IpInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IpInfo.Services
{
    public class GeoIpService
    {
        private HttpClient _client;
        private string _url = "https://freegeoip.app/json/{0}";

        public GeoIpService(HttpClient client)
        {
            _client = client;
        }

        public async Task<GeolocationModel> RequestGeoInfoAsync(string ip)
        {
            StringBuilder sb = new StringBuilder();
            string apiUrl = sb.AppendFormat(_url, ip).ToString();

            using (HttpResponseMessage response = await _client.PostAsJsonAsync("https://localhost:44316/api/IpInfo", apiUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    GeolocationModel result = await response.Content.ReadAsAsync<GeolocationModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
