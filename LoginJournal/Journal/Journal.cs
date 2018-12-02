using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    public class Journal
    {
        public string folderPath { get; private set; }
        //public List<JournalItem> Cache { get; private set; }

        public Journal(string folder)
        {
            folderPath = folder;
            //Cache = new List<JournalItem>();
        }

        public void WriteLog(JournalItem item)
        {
            var specialPath = Path.GetFullPath(Path.Combine(folderPath, item.date.ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU"))));
            var filePath = Path.GetFullPath(Path.Combine(specialPath, item.date.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU")) + ".journal"));
            CreateFolderIfNotExists(specialPath);
            write_log(filePath, item.ToString());
        }
        public static void WriteLog(JournalItem item, string folderPath)
        {
            var specialPath = Path.GetFullPath(Path.Combine(folderPath, item.date.ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU"))));
            var filePath = Path.GetFullPath(Path.Combine(specialPath, item.date.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU")) + ".journal"));
            CreateFolderIfNotExists(specialPath);
            write_log(filePath, item.ToString());
        }

        private static void CreateFolderIfNotExists(string folderPath)
        {
            Directory.CreateDirectory(folderPath);
        }
        private static void CreateFileIfNotExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        private static void write_log(string filepath, string message)
        {
            CreateFileIfNotExists(filepath);
            using(var sw = new StreamWriter(filepath, true))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }
    }
}
