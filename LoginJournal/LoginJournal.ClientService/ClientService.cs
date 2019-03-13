using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Security.Principal;
using Journal;
using System.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel;

namespace LoginJournal.ClientService
{
    public partial class ClientService : ServiceBase
    {
        private string journalForlder
        {
            get
            {
                ConfigurationManager.RefreshSection("appSettings");
                return ConfigurationManager.AppSettings["journalFolder"] ?? "";
            }
        }
        private bool isAdmin
        {
            get
            {
                ConfigurationManager.RefreshSection("appSettings");
                bool res = false;
                bool.TryParse(ConfigurationManager.AppSettings["isAdmin"], out res);
                return res;
            }
        }
        private string AdminEndpoint
        {
            get
            {
                ConfigurationManager.RefreshSection("appSettings");
                return ConfigurationManager.AppSettings["adminEndpoint"] ?? "";
            }
        }
        private ServiceHost adminHost;

        private string CurrentUser
        {
            get
            {
                var s1 = "";
                try { s1 = "s1:" + System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName; }
                catch (Exception e) { }
                var s2 = "";
                try { s2 = "s2:" + WindowsIdentity.GetCurrent().Name.ToString() + "|" + WindowsIdentity.GetCurrent().ToString(); }
                catch (Exception e) { }
                var s3 = "";
                try { s3 = "s3:" + Environment.UserName; }
                catch (Exception e) { }
                return s1 + s2 + s3;
            }
        }
        public ClientService()
        {
            InitializeComponent();
            CanPauseAndContinue = true;
            CanHandleSessionChangeEvent = true;
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("LoginJournal.ClientService"))
            {
                EventLog.CreateEventSource(
                     "LoginJournal.ClientService", "LoginJournalLog");
            }
            eventLog1.Source = "LoginJournal.ClientService";
            eventLog1.Log = "LoginJournalLog";
            try
            {
                SystemEvents.SessionEnded += SystemEvents_SessionEnded;
                SystemEvents.SessionEnding += SystemEvents_SessionEnding;
                SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            }
            catch (Exception e) { eventLog1.WriteEntry(e.ToString(), EventLogEntryType.Error); }
        }

        private void stupidThings(string str)
        {
            //try
            //{
            //    ProcessExtensions.StartProcessAsCurrentUser(@"C:\Users\kirill.gribkov\Documents\LJ\login-journal\LoginJournal\ConsoleTest\bin\Debug\ConsoleTest.exe", str);
            //}
            //catch (Exception e) { eventLog1.WriteEntry(e.ToString(), EventLogEntryType.Error); }
            try
            {
                //ProcessExtensions.StartProcessAsCurrentUser(@"C:\Users\kirill.gribkov\Documents\LJ\login-journal\LoginJournal\ConsoleTest\bin\Debug\ConsoleTest.exe", @"""C:\Users\kirill.gribkov\Documents\LJ\login-journal\LoginJournal\ConsoleTest\bin\Debug\ConsoleTest.exe"" " + str);
                //ProcessExtensions.StartProcessAsCurrentUser(@"notepad");
            }
            catch (Exception e) { eventLog1.WriteEntry(e.ToString(), EventLogEntryType.Error); }
        }
        //public static bool IsProcessOpen(string name)
        //{
        //    //here we're going to get a list of all running processes on
        //    //the computer
        //    foreach (Process clsProcess in Process.GetProcesses())
        //    {
        //        if (clsProcess.ProcessName.Contains(name))
        //        {
        //            //if the process is found to be running then we
        //            //return a true
        //            return true;
        //        }
        //    }
        //    //otherwise we return a false
        //    return false;
        //}

        ~ClientService()
        {
            //try
            //{
            //    SystemEvents.SessionEnded -= SystemEvents_SessionEnded;
            //    SystemEvents.SessionEnding -= SystemEvents_SessionEnding;
            //    SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
            //}
            //catch (Exception e) { eventLog1.WriteEntry(e.ToString(), EventLogEntryType.Error); }
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLogon:
                    OnSessionStart("SessionSwitchReason.SessionLogon " + sender.ToString());
                    break;
                case SessionSwitchReason.SessionLogoff:
                    OnSessionEnd("SessionSwitchReason.SessionLogoff " + sender.ToString());
                    break;
                case SessionSwitchReason.SessionLock:
                    OnSessionEnd("SessionSwitchReason.SessionLock " + sender.ToString());
                    break;
                case SessionSwitchReason.SessionUnlock:
                    OnSessionStart("SessionSwitchReason.SessionUnlock " + sender.ToString());
                    break;
            }
        }

        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionEndReasons.Logoff:
                    OnSessionEnd("SessionEndReasons.Logoff " + sender.ToString());
                    break;
                case SessionEndReasons.SystemShutdown:
                    OnSessionEnd("SessionEndReasons.SystemShutdown " + sender.ToString());
                    break;
            }
        }

        private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionEndReasons.Logoff:
                    OnSessionEnd("SessionEndedReasons.Logoff " + sender.ToString());
                    break;
                case SessionEndReasons.SystemShutdown:
                    OnSessionEnd("SessionEndedReasons.SystemShutdown " + sender.ToString());
                    break;
            }
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    OnSessionStart("SessionChangeReason.SessionLogon");
                    break;
                case SessionChangeReason.SessionLogoff:
                    OnSessionEnd("SessionChangeReason.SessionLogoff");
                    break;
                case SessionChangeReason.SessionLock:
                    OnSessionEnd("SessionChangeReason.SessionLock");
                    break;
                case SessionChangeReason.SessionUnlock:
                    OnSessionStart("SessionChangeReason.SessionUnlock");
                    break;
            }
        }

        private void OnSessionStart(string handledEvent)
        {
            try
            {
                write_log(JournalItem.EventType.ВХОД);
                //write_log("LOGIN handledEvent:" + handledEvent);
                //stupidThings(handledEvent);
            }
            catch (Exception e)
            {
                eventLog1.WriteEntry(e.ToString(), EventLogEntryType.Error);
            }
        }
        private void OnSessionEnd(string handledEvent)
        {
            try
            {
                write_log(JournalItem.EventType.ВЫХОД);
                //write_log("LOGOFF handledEvent:" + handledEvent);
            }
            catch (Exception e)
            {
                eventLog1.WriteEntry(e.ToString(), EventLogEntryType.Error);
            }
        }

        private void write_log(string message)
        {

            var res = DateTime.Now.ToLongTimeString() + " " + message + " CurrentUser:" + (ProcessExtensions.GetCurrentUsername() ?? "");
            res += "\t&\t" + hash(res);
            eventLog1.WriteEntry(res);
        }
        private void write_log(JournalItem.EventType eventType)
        {
            var cureitem = new JournalItem(DateTime.Now, eventType, ProcessExtensions.GetCurrentUsername() ?? "", Environment.MachineName);
            Journal.Journal.WriteLog(cureitem, journalForlder);
        }

        private string hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void ALLTASK()
        {
            AdminServiceSS();
            SendToAdmin();
        }

        private void AdminServiceSS()
        {
            try
            {
                if (isAdmin)
                {
                    if (adminHost == null)
                    {
                        adminHost = new ServiceHost(typeof(AdminService));
                        adminHost.Open();
                    }
                }
                else
                {
                    if (adminHost != null)
                    {
                        adminHost.Close();
                        adminHost = null;
                    }
                }
            }
            catch (Exception e) { }
        }

        private void SendToAdmin()
        {
            if (isAdmin)
                return;
            try
            {
                NetTcpBinding netTcpBinding = new NetTcpBinding();
                var endpoint = new EndpointAddress(AdminEndpoint);
                using (var channelFactory = new ChannelFactory<IAdminService>(netTcpBinding, endpoint))
                {
                    IAdminService service = channelFactory.CreateChannel(endpoint);
                    var tarInfos = service.GetCountByMachineByMonth(Environment.MachineName);
                    var curInfos = GetJournalInfos();
                    var newInfos = tarInfos.Where(x => !curInfos.Contains(x));
                    service.SendJournal(GetByInfos(newInfos));
                }
            }
            catch (Exception e) { }
        }

        private List<JournalInfo> GetJournalInfos()
        {
            var res = new List<JournalInfo>();

            var jw = new JournalViewer(journalForlder);
            foreach (var y in jw.GetAllJournals().Where(x => x.machineName == Environment.MachineName).GroupBy(x => x.date.Year))
            {
                foreach (var m in y.GroupBy(x => x.date.Month))
                {
                    res.Add(new JournalInfo { Year = y.Key, Month = m.Key, Count = m.Count() });
                }
            }
            return res;
        }

        private List<JournalItem> GetByInfos(IEnumerable<JournalInfo> ifs)
        {
            var res = new List<JournalItem>();
            var itms = new JournalViewer(journalForlder).GetAllJournals();
            foreach (var item in ifs)
            {
                res.AddRange(itms.Where(x => { return x.date.Year == item.Year && x.date.Month == item.Month; }));
            }
            return res;
        }

        protected override void OnStart(string[] args)
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            var timer = new System.Threading.Timer((e) =>
            {
                ALLTASK();
            }, null, startTimeSpan, periodTimeSpan);
        }

        protected override void OnStop()
        {

        }
    }
}
