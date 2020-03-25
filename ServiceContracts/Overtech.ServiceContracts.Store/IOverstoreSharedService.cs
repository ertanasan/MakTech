using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Store;

namespace Overtech.ServiceContracts.Store
{
    [ServiceContract]
    public interface IOverstoreSharedService : ICRUDLServiceContract<Overtech.DataModels.Store.BPMHistory>
    {

        [OperationContract]
        IEnumerable<BPMHistory> ListBPMHistoryData(long processInstanceId);

    }
}