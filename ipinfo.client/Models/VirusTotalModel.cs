using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpInfo.Models
{
    public class VirusTotalModel
    {
        public double Https_Certificate_Date { get; set; }
        public string Whois_Timestamp { get; set; }
        public double Asn { get; set; }
        public string As_Owner { get; set; }
        public int Response_Code { get; set; }
    }
}
