using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification
{
    public interface IDisplayText
    {
        string DisplayText { get; }
        DateTime Time { get; set; }
        bool Status { get; set; }
        int Count { get; }
    }
}
