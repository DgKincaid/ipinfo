using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IpInfo.Models
{
    public class ServerSelection
    {
        public string Ip { get; set; }
        public List<string> Servers { get; set; }
    }
}
