using Journal;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
namespace JournalViewer
{
    [Serializable]
    public class settings
    {
        public string JournalFolder = @"C:\Журнал";
        public string NamemapPath = @"C:\Журнал\st.txt";
        public string PCPath = @"C:\Журнал\компьютеры.txt";
    }

    public class SettingLoader
    {
        public settings set { get; private set; }
        public string SettingsPath { get; private set; }
        public SettingLoader(string folderpath)
        {
            SettingsPath = folderpath + "settings.txt";
            set = new settings();
            try
            {
                load();
            }
            catch (Exception e) { logger.log("error", e); }
            try
            {
                save();
            }
            catch (Exception e) { logger.log("error", e); }

        }   

        public void load()
        {
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(SettingsPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            set = (settings)formatter.Deserialize(stream);
            stream.Close();
        }
        public void save()
        {
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream(SettingsPath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, set);
            stream.Close();
        }
    } 

}
