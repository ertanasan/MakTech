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
    public interface IGatheringDetailService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.GatheringDetail>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        IEnumerable<Overtech.DataModels.Warehouse.GatheringDetail> ListGatheringDetail(long gatheringId);

        [OperationContract]
        IEnumerable<Overtech.DataModels.Product.Product> ListGatheringControlAddProduct(long GatheringId, int PalletNo);

        [OperationContract]
        void AddProducttoControlList(long GatheringId, int PalletNo, int ProductId);

        [OperationContract]
        void LogControlZero(long GatheringPalletId, long GatheringDetailId, decimal? PreviousQuantity);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

