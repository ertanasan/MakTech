// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Sale
{
    [ServiceContract]
    public interface ICancelReasonService : ICRUDLServiceContract<Overtech.DataModels.Sale.CancelReason>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<CancelReason> ListRecCancelsByDate(DateTime recDate, int storeId);

        [OperationContract]
        void SaveCancelReasons(IEnumerable<CancelReason> rec);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

