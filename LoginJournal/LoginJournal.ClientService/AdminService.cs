using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Journal;

namespace LoginJournal.ClientService
{
    class AdminService : IAdminService
    {
        class JournalItemComparerByDate : IComparer<JournalItem>
        {
            public int Compare(JournalItem p1, JournalItem p2)
            {
                if (p1.date > p2.date)
                    return 1;
                else if (p1.date < p2.date)
                    return -1;
                else
                    return 0;
            }
        }
        object lockObj = new object();
        private DateTime reinit = DateTime.MinValue;

        private string journalForlder
        {
            get
            {
                ConfigurationManager.RefreshSection("appSettings");
                return ConfigurationManager.AppSettings["journalFolder"] ?? "";
            }
        }
        private Dictionary<string, Dictionary<int, Dictionary<int, int>>> infos = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>();


        public List<JournalInfo> GetCountByMachineByMonth(string machineName)
        {
            reinitInfos();
            if (!infos.ContainsKey(machineName))
                return new List<JournalInfo>();
            var res = new List<JournalInfo>();
            foreach (var item in infos[machineName])
            {
                var Year = item.Key;
                res.AddRange(item.Value.ToList().Select(x => new JournalInfo { Year = Year, Month = x.Key, Count = x.Value }));
            }
            return res;
        }

        public void SendJournal(List<JournalItem> items)
        {
            var jw = new JournalViewer(journalForlder);
            var cur = jw.GetAllJournals();
            var newItms = items.Where(x => !cur.Contains(x));
            foreach (var item in newItms)
            {
                Journal.Journal.WriteLog(item, journalForlder);
            }
        }

        private void reinitInfos()
        {
            lock (lockObj)
            {
                if ((DateTime.Now - reinit).Minutes < 5)
                    return;
                var jw = new JournalViewer(journalForlder);
                infos = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>();
                var items = jw.GetAllJournals().GroupBy(x => x.machineName);
                foreach (var item in items)
                {
                    infos[item.Key] = new Dictionary<int, Dictionary<int, int>>();
                    foreach (var y in item.GroupBy(x => x.date.Year))
                    {
                        infos[item.Key][y.Key] = new Dictionary<int, int>();
                        foreach (var m in y.GroupBy(x => x.date.Month))
                            infos[item.Key][y.Key][m.Key] = m.Count();
                    }
                }
                reinit = DateTime.Now;
            }
        }
    }
}
