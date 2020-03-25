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
    public interface ITransferProductDetailService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.TransferProductDetail>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        IEnumerable<Overtech.DataModels.Warehouse.TransferProductDetail> CreateAll(IEnumerable<Overtech.DataModels.Warehouse.TransferProductDetail> dataObject);
        [OperationContract]
        void UpdateAll(IEnumerable<Overtech.DataModels.Warehouse.TransferProductDetail> dataObject);
        [OperationContract]
        void DeleteAll(IEnumerable<long> objectId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

