using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IpInfo.Worker.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IpInfo.Worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpInfoController : ControllerBase
    {
        // GET: api/IpInfo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IpInfo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/IpInfo
        [HttpPost]
        public async Task<dynamic> PostAsync([FromBody] string value)
        {
            IpApiGetService ipService = new IpApiGetService();

            var result = await ipService.LoadIpInfoAsync(value);
  
            return Ok(result);
        }

        // PUT: api/IpInfo/5
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
