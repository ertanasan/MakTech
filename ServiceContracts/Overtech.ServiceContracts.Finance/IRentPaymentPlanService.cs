// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Finance;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Finance
{
    [ServiceContract]
    public interface IRentPaymentPlanService : ICRUDLServiceContract<Overtech.DataModels.Finance.RentPaymentPlan>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        long GenerateAllPayments(bool isKeepExistingRecords);

        [OperationContract]
        long ClonePayment(long templateRecordId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

