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
    public interface IStoreCashRegisterService : ICRUDLServiceContract<Overtech.DataModels.Store.StoreCashRegister>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<StoreCashRegister> StoreCashRegisters(long storeId);

        [OperationContract]
        IEnumerable<StoreCashRegister> GetUserCashRegister();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

