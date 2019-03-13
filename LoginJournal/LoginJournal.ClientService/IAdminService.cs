using Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LoginJournal.ClientService
{
    [ServiceContract]
    interface IAdminService
    {
        [OperationContract]
        List<JournalInfo> GetCountByMachineByMonth(string machineName);

        [OperationContract]
        void SendJournal(List<JournalItem> items);
    }
}