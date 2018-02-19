using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RealTimeResourceMonitor.Models;
using Microsoft.AspNetCore.SignalR;
using RealTimeResourceMonitor.Hubs;
using RealTimeResourceMonitor.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeResourceMonitor.Api
{
    [Route("api/[controller]")]
    public class CpuInfoController : Controller
    {
        IHubContext<CpuInfoHub, ICpuInfoHubClient> _cpuInfoHubContext;
        public CpuInfoController(IHubContext<CpuInfoHub, ICpuInfoHubClient> cpuInfoHubContext)
        {
            _cpuInfoHubContext = cpuInfoHubContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] CpuInfoPostData cpuInfo)
        {
            _cpuInfoHubContext.Clients.All.cpuInfoMessage(cpuInfo.MachineName, cpuInfo.Processor, cpuInfo.MemUsage, cpuInfo.TotalMemory);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
