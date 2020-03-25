// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Warehouse
{
    [ServiceContract]
    public interface IProductReturnService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.ProductReturn>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OperationContract]
        void UpdateStatus(long requestId, int statusId);

        [OperationContract]
        void ApproveProductReturn(ProductReturn rec);

        [OperationContract]
        long SaveProductReturn(ProductReturn rec);

        [OperationContract]
        IEnumerable<ProductReturn> ListStatus(int statusCode);

        [OperationContract]
        void TakeAction(DataModels.Warehouse.ProductReturn dataObject, long actionId, string choice, string comment);

        [OperationContract]
        IEnumerable<ProductReturnHistory> ListHistoryData(long productReturnId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

