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
    public interface IEstateRentPeriodService : ICRUDLServiceContract<Overtech.DataModels.Finance.EstateRentPeriod>
    {

        /*Section="Method-ListRentPaymentPlans"*/
        [OperationContract]
        IEnumerable<RentPaymentPlan> ListRentPaymentPlans(long estateRentPeriodId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        long GenerateAllPeriods(bool isKeepExistingRecords);

        [OperationContract]
        long ClonePeriod(long templateRecordId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

