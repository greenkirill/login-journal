using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    public struct JournalInfo : IEquatable<JournalInfo>
    {
        public int Year;
        public int Month;
        public int Count;
        public string Hash;

        public bool Equals(JournalInfo o)
        {
            return (Year == o.Year) && (Month == o.Month) && (Count == o.Count);
        }
    }
}
