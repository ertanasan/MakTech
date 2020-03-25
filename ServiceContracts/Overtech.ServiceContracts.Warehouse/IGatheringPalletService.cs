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
    public interface IGatheringPalletService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.GatheringPallet>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<GatheringPallet> ActiveControlPallets();

        [OperationContract]
        int StartControl(long gatheringPalletId, Boolean allowReControl);

        [OperationContract]
        GatheringPallet GetPalletByGatheringId(long gatheringId, int palletNo);

        [OperationContract]
        IEnumerable<GatheringPallet> ListPalletByGatheringId(long gatheringId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

