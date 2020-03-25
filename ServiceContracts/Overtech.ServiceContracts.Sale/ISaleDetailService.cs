// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Sale
{
    [ServiceContract]
    public interface ISaleDetailService : ICRUDLServiceContract<Overtech.DataModels.Sale.SaleDetail>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<SaleDetail> ListSaleDetail(long saleId);

        [OperationContract]
        DataTable GetCancelDetailData(DateTime start,DateTime end);

        [OperationContract]
        DataTable GetCancelData(DateTime start, DateTime end, int storeId);

        [OperationContract]
        DataTable WeeklyCancels(DateTime prm_start, DateTime prm_end);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

