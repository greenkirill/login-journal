using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Journal;

namespace AdminService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in both code and config file together.
    public class AdminService : IAdminService
    {
        private static readonly Object obj = new Object();
        private string journalForlder
        {
            get
            {
                ConfigurationManager.RefreshSection("appSettings");
                return ConfigurationManager.AppSettings["journalFolder"] ?? "";
            }
        }

        public void DoWork()
        {

        }

        public DateTime getLastDate(string machine)
        {
            var m = new master(journalForlder);
            return m.getItem(machine).date;
        }

        public void pushItems(string machine, List<JournalItem> items)
        {
            lock (obj)
            {
                var m = new master(journalForlder);
                var mitem = m.getItem(machine);
                foreach (var item in items)
                {
                    if (item.date > mitem.date)
                        Journal.Journal.WriteLog(item, journalForlder);
                }
            }
        }
    }
}
