using System;
using System.Globalization;

namespace Journal {
    public class JournalItem_View {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public TimeSpan duration { get; set; }
        public string durationView {
            get {
                if (duration != null) {
                    var d = duration.Days > 0 ? duration.Days.ToString() + "д " : "";
                    var h = duration.Hours > 0 || d != "" ? duration.Hours.ToString() + "ч " : "";
                    var m = duration.Minutes > 0 || h != "" ? duration.Minutes.ToString() + "м " : "";
                    var s = duration.Seconds > 0 || m != "" ? duration.Seconds.ToString() + "с" : "";
                    return d + h + m + s;
                }
                if (to == null && from != null) {
                    return "сессия еще идет";
                }
                if (to != null && from == null) {
                    return "неполная сессия";
                }
                return "";
            }
        }
        public string dateView {
            get {
                if (from != DateTime.MinValue) {
                    return from.ToString("d MMMM", CultureInfo.CreateSpecificCulture("ru-RU"));
                } else if (to != DateTime.MinValue) {
                    return to.ToString("d MMMM", CultureInfo.CreateSpecificCulture("ru-RU"));
                }
                return "";
            }
        }
        public string machineName { get; set; }
        public string mappedMachineName { get; set; }
        public string machineView {
            get {
                if (mappedMachineName != null && mappedMachineName != "")
                    return mappedMachineName;
                if (machineName != null)
                    return machineName;
                return "";
            }
        }
        public string FromTime {
            get {
                return from.ToString("H:mm");
            }
        }
        public string ToTime {
            get {
                return to.ToString("H:mm");
            }
        }
        public string TimeView {
            get {
                return from.ToString("H:mm") + "-" + to.ToString("H:mm");
            }
        }
        public string username { get; set; }
        public string RealName { get; set; }
        public string nameView {
            get {
                if (RealName != null && RealName != "")
                    return RealName;
                if (username != null)
                    return username;
                return "";
            }
        }
        public string purpose { get; set; }
        public bool isValid{ get; set; }
    }
}
