using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpInfo.Models
{
    public class GeolocationModel
    {
        public string Ip { get; set; }
        public string Country_Code { get; set; }
        public string Country_Name { get; set; }
        public string Region_Code { get; set; }
        public string Region_Name { get; set; }
        public string City { get; set; }
        public string Zip_Code { get; set; }
        public string Time_Zone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Metro_code { get; set; }
    }
}
