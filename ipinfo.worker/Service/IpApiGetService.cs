using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IpInfo.Worker.Service
{
    public class IpApiGetService
    {
        public async Task<dynamic> LoadIpInfoAsync(string url)
        {
            using (HttpResponseMessage response = await HttpHelper.client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    dynamic result = await response.Content.ReadAsAsync<dynamic>();
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
