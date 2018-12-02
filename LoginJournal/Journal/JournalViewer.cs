using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    public class JournalViewer
    {
        public string folderPath { get; private set; }
        public List<string> files { get; private set; }
        public List<JournalItem> items { get; private set; }

        public JournalViewer(string folder)
        {
            folderPath = folder;
            files = new List<string>();
            items = new List<JournalItem>();
        }

        public string[] FLDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        public FileInfo[] SLFiles(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path);
            return d.GetFiles("*.journal");
        }

        public List<JournalItem> TLItems(string path)
        {
            var res = new List<JournalItem>();
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var sr = new StreamReader(fs))
            {
                string nl;
                while((nl = sr.ReadLine())!=null)
                {
                    try
                    {
                        res.Add(JournalItem.StringToJournalItem(nl));
                    }catch (Exception e) { }
                }
            }
            return res;
        }

        public List<JournalItem> GetAllJournals()
        {
            var path = folderPath;
            var res = new List<JournalItem>();
            foreach (var folder in FLDirectories(path))
            {
                foreach(var file in SLFiles(folder))
                {
                    res = res.Concat(TLItems(file.FullName)).ToList() ;
                }
            }
            return res;
        }

        public static List<JournalItem_View> ItemToView(List<JournalItem> jis)
        {
            var tmp = new Dictionary<string, JournalItem>();
            jis.Sort();
            var res = new List<JournalItem_View>();
            //var tmp = new List<JournalItem_View>();
            foreach (var item in jis)
            {
                var key = item.username + item.machineName;
                if (item.eventType == JournalItem.EventType.ВХОД)
                {
                    tmp.Add(key, item);
                }
                else if(item.eventType == JournalItem.EventType.ВЫХОД)
                {
                    if (tmp.ContainsKey(key))
                    {
                        res.Add(ItemsToView(tmp[key], item));
                        tmp.Remove(key);
                    }
                    else
                    {
                        //res.Add(ItemToToView(item));
                    }
                }
            }
            return res;
        }

        public static JournalItem_View ItemsToView(JournalItem from, JournalItem to)
        {
            return new JournalItem_View()
            {
                from = from.date,
                to = to.date,
                duration = to.date - from.date,
                machineName = from.machineName,
                username = from.username,
                RealName = "",
                purpose = from.purpose
            };
        }
        public static JournalItem_View ItemToToView(JournalItem to)
        {
            return new JournalItem_View()
            {
                to = to.date,
                machineName = to.machineName,
                username = to.username,
                RealName = "",
                purpose = to.purpose
            };
        }
    }
}
