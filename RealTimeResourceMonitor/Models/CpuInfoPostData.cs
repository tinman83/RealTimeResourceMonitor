using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeResourceMonitor.Models
{
    public class CpuInfoPostData
    {
        public string MachineName
        {
            get;
            set;
        }
        public double Processor
        {
            get;
            set;
        }
        public ulong MemUsage
        {
            get;
            set;
        }
        public ulong TotalMemory
        {
            get;
            set;
        }
    }
}
