using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeResourceMonitor.Interfaces
{
   public interface ICpuInfoHubClient
    {
        Task cpuInfoMessage(string MachineName, double Processor, ulong MemUsage, ulong TotalMemory);
    }
}
