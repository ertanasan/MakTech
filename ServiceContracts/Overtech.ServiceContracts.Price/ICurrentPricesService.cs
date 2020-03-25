// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Price;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Price
{
    [ServiceContract]
    public interface ICurrentPricesService : ICRUDLServiceContract<Overtech.DataModels.Price.CurrentPrices>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<CurrentPrices> ListStoreCurrentPrices(int storeId, int groupCode);

        [OperationContract]
        IEnumerable<PriceChangeHistory> ListPriceChanges();

        [OperationContract]
        void CheckedPricesChangesAsNotified(IEnumerable<PriceChangeHistory> priceChangesForStore);

        [OperationContract]
        CurrentPrices GetCurrentPriceByProductCode(string productCode);
        
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

