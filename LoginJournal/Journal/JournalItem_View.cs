using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    public class JournalItem_View
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public TimeSpan duration { get; set; }
        public string machineName { get; set; }
        public string username { get; set; }
        public string RealName { get; set; }
        public string purpose { get; set; }
    }
}
