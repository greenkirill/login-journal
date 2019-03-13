using System.Globalization;
using System.IO;

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
        static object lockObj = new object();
        public static void WriteLog(JournalItem item, string folderPath)
        {
            lock (lockObj)
            {
                var specialPath = Path.GetFullPath(Path.Combine(folderPath, item.date.ToString("MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU"))));
                var filePath = Path.GetFullPath(Path.Combine(specialPath, item.date.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("ru-RU")) + ".journal"));
                CreateFolderIfNotExists(specialPath);
                write_log(filePath, item.ToString());
            }
        }

        private static void CreateFolderIfNotExists(string folderPath)
        {
            Directory.CreateDirectory(folderPath);
        }
        private static void CreateFileIfNotExists(string folderPath)
        {
            //using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            //{
            //    fileStream.Flush();
            //    file
            //}
        }
        private static void write_log(string filepath, string message)
        {
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
                File.WriteAllText(filepath, message + "\n");
            }
            else
            { 
                using (var sw = new StreamWriter(filepath, true))
                {
                    sw.WriteLine(message);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
