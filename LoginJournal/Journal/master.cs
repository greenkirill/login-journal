using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    public class master
    {
        public List<masterItem> items { get; private set; }
        private string folderPath { get; set; }
        private string masterPath { get; set; }
        public master(string folderPath)
        {
            this.folderPath = folderPath;
            this.masterPath = folderPath + "/аудит.txt";
            CreateFolderIfNotExists(folderPath);
            reload();
        }

        private static void CreateFolderIfNotExists(string folderPath)
        {
            Directory.CreateDirectory(folderPath);
        }

        public void reload()
        {
            items = new List<masterItem>();
            if (!File.Exists(masterPath))
            {
                File.Create(masterPath).Close();
            }
            using(var sr = new StreamReader(masterPath))
            {
                string nl;
                while ((nl = sr.ReadLine()) != null)
                {
                    try
                    {
                        items.Add(masterItem.StringToMasterItem(nl));
                    }
                    catch (Exception e) { }
                }
            }
        }

        public void resave()
        {
            if (!File.Exists(masterPath))
            {
                File.Create(masterPath).Close();
            }
            using(var sw = new StreamWriter(masterPath))
            {
                foreach (var item in items)
                {
                    sw.WriteLine(item.ToString());
                }
            }
        }

        public masterItem getItem(string machine)
        {
            foreach (var item in items)
            {
                if (item.machine == machine)
                    return item;
            }
            return new masterItem(machine, DateTime.MinValue.Date);
        }

    }
}
