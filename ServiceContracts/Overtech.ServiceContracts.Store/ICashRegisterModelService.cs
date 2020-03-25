// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Store;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Store
{
    [ServiceContract]
    public interface ICashRegisterModelService : ICRUDLServiceContract<Overtech.DataModels.Store.CashRegisterModel>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Store.CashRegisterModel Find(string name);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

