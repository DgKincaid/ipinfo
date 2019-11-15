using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IpInfo.Models;
using IpInfo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IpInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpController : ControllerBase
    {
        // GET: api/Ip
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ip/5
        [HttpGet("{value}", Name = "Get")]
        public async Task<dynamic> GetAsync(string value)
        {
            IPAddress ip;
            var address = Dns.GetHostAddresses(value).FirstOrDefault().ToString();
            bool valid = IPAddress.TryParse(address, out ip);

            if(valid)
            {
                AggregatorService service = new AggregatorService(HttpHelper.client);
                ServerSelection server = new ServerSelection();
                server.Ip = ip.ToString();
                dynamic results = await service.GetAllIpInfo(server);
                return Ok(results);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Ip
        [HttpPost]
        public async Task<dynamic> PostAsync([FromBody] ServerSelection value)
        {
            IPAddress ip;
            var address = Dns.GetHostAddresses(value.Ip).FirstOrDefault().ToString();
            bool valid = IPAddress.TryParse(address, out ip);

            if (valid)
            {
                AggregatorService service = new AggregatorService(HttpHelper.client);
                ServerSelection server = value;
                server.Ip = ip.ToString();
                dynamic results = await service.GetAllIpInfo(server);
                return Ok(results);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Ip/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
