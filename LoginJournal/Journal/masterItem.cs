using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    public class masterItem
    {
        public string machine { get; set; }
        public DateTime date { get; set; }

        public masterItem(string machine, DateTime date)
        {
            this.machine = machine;
            this.date = date;
        }

        public override string ToString()
        {
            return string.Format("{0,30}{1,20}", date.ToString("F", CultureInfo.CreateSpecificCulture("ru-RU")), machine);
        }

        public static masterItem StringToMasterItem(string line)
        {
            var _date = "";
            var machineName = "";
            DateTime date = DateTime.Now;
            try
            {
                _date = line.Substring(0, 30).Trim();
                machineName = line.Substring(30, 20).Trim();
                if (!DateTime.TryParse(_date, CultureInfo.CreateSpecificCulture("ru-RU"), DateTimeStyles.None, out date))
                {
                    throw new FormatException(_date);
                }
            }
            catch (Exception e) { }
            return new masterItem(machineName, date);
        }
    }
}
