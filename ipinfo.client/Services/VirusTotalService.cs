using IpInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IpInfo.Services
{
    public class VirusTotalService
    {
        // Virus Total API Key
        private string _apiKey = "VIRUS_TOTAL_API_KEY";
        private string _url = "https://www.virustotal.com/vtapi/v2/ip-address/report?apikey={0}&ip={1}";
        private HttpClient _client;

        public VirusTotalService(HttpClient client)
        {
            _client = client;
        }

        // One issue with this api is if the ip is not in the DB will return missing ip address message
        public async Task<VirusTotalModel> RequestVirusInfoAsync(string ip)
        {
            StringBuilder sb = new StringBuilder();
            string apiUrl = sb.AppendFormat(_url, _apiKey, ip).ToString();
            try
            {
                using (HttpResponseMessage response = await _client.PostAsJsonAsync("https://localhost:44316/api/IpInfo", apiUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        VirusTotalModel result = await response.Content.ReadAsAsync<VirusTotalModel>();
                        return result;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
