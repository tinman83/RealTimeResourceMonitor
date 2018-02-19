using Microsoft.AspNetCore.SignalR;
using RealTimeResourceMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeResourceMonitor.Hubs
{
    public class CpuInfoHub: Hub<ICpuInfoHubClient>
    {
        public async Task SendCpuInfo(string machineName, double processor, ulong memUsage, ulong totalMemory)
        {
            await this.Clients.All.cpuInfoMessage(machineName, processor, memUsage, totalMemory);
        }
    }
}
