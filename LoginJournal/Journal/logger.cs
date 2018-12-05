using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    public class logger
    {

        public static void log(string level, object obj)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "/" + level + ".txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, obj.ToString() + "\n");
            }
            else
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(obj.ToString());
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
