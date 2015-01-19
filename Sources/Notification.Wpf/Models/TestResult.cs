using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Wpf.Models
{
    public class TestResult
    {
        public string Method { get; set; }
        public int ObjectCount { get; set; }
        public int IterationCount { get; set; }
        public long ConstructionMilliseconds { get; set; }
        public long ExecutionMilliseconds { get; set; }
        public long TotalMilliseconds { get { return ConstructionMilliseconds + ExecutionMilliseconds; } }
    }
}
