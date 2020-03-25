// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Reconciliation;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Reconciliation
{
    [ServiceContract]
    public interface IAdjustmentService : ICRUDLServiceContract<Overtech.DataModels.Reconciliation.Adjustment>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        decimal Adjustment(long storeId, DateTime date);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

