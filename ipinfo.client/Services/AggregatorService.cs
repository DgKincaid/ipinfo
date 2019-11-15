using IpInfo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IpInfo.Services
{
    public class AggregatorService
    {
        private HttpClient _client;

        public AggregatorService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IpInfoModel> GetAllIpInfo(ServerSelection servers)
        {
            Task<GeolocationModel> geolocationTask = Task.Factory.StartNew<GeolocationModel>(() => {
                if (servers.Servers == null || servers.Servers.Contains("geolocation"))
                {
                    GeoIpService geoService = new GeoIpService(_client);
                    return geoService.RequestGeoInfoAsync(servers.Ip).Result;
                }
                else
                {
                    return null;
                }
            });

            Task<VirusTotalModel> virusTotalTask = Task.Factory.StartNew<VirusTotalModel>(() => {
                if (servers.Servers == null || servers.Servers.Contains("virustotal"))
                {
                    VirusTotalService virusTotalService = new VirusTotalService(_client);
                    return virusTotalService.RequestVirusInfoAsync(servers.Ip).Result;
                }
                else
                {
                    return null;
                }
            });


            await Task.WhenAll(geolocationTask, virusTotalTask);

            IpInfoModel results = new IpInfoModel();

            results.LocationInfo = await geolocationTask;
            
            results.VirusTotal = await virusTotalTask;

            return results;
        }
    }
}
