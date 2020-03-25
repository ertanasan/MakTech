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
    public interface IPosMovementService : ICRUDLServiceContract<Overtech.DataModels.Store.PosMovement>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void PosMoveInitial();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

