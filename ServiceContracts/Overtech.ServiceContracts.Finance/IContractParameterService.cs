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
    public interface IContractParameterService : ICRUDLServiceContract<Overtech.DataModels.Finance.ContractParameter>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Finance.ContractParameter Find(string parameterName);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

