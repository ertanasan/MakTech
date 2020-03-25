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
    public interface IGatheringPalletPhotoService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.GatheringPalletPhoto>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        bool UploadPalletPhoto(Overtech.DataModels.Warehouse.GatheringPalletPhoto palletPhoto);

        [OperationContract]
        bool DeletePalletPhoto(long gatheringPalletPhotoId);

        [OperationContract]
        IEnumerable<Overtech.DataModels.Warehouse.GatheringPalletPhoto> ListPalletPhoto(long storeOrderId, long? gatheringPalletId);

        [OperationContract]
        Overtech.DataModels.Warehouse.GatheringPalletPhoto GetPhotoByIndex(long storeOrderId, int photoIndex, long? gatheringPalletId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

