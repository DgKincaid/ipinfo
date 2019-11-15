using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpInfo.Models
{
    public class IpInfoModel
    {
        public GeolocationModel LocationInfo { get; set; }
        public VirusTotalModel VirusTotal { get; set; }
    }
}
