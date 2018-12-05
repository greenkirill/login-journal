using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Journal.namemap;

namespace Journal
{
    public class pcmap
    {

        public string Path { get; private set; }
        private List<mapitem<string, string>> map { get; set; } = new List<mapitem<string, string>>();
        public pcmap(string path)
        {
            Path = path;
            initMap();

        }

        private void initMap()
        {
            try
            {
                using (var sr = new StreamReader(Path))
                {
                    string nl;
                    while ((nl = sr.ReadLine()) != null)
                    {
                        try
                        {
                            var splt = nl.Split(',');
                            var ni = new mapitem<string, string>(splt[0].Trim(), splt[1].Trim());
                            map.Add(ni);
                        }
                        catch (Exception e) { }
                    }
                }
            }
            catch (Exception e) { }
        }

        public string GetCurName(string name)
        {
            foreach (var item in map)
            {
                if (item.item2 == name)
                    return item.item1;
            }
            return name;
        }
        public string GetViewName(string username)
        {
            foreach (var item in map)
            {
                if (item.item1 == username)
                    return item.item2;
            }
            return username;
        }
    }
}
