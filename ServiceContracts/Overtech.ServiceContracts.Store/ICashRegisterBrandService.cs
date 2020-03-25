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
    public interface ICashRegisterBrandService : ICRUDLServiceContract<Overtech.DataModels.Store.CashRegisterBrand>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Store.CashRegisterBrand Find(string name);

        /*Section="Method-ListCashRegisterModels"*/
        [OperationContract]
        IEnumerable<CashRegisterModel> ListCashRegisterModels(long cashRegisterBrandId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

