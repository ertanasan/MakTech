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
    public interface IShipmentPackageTypeService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.ShipmentPackageType>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Warehouse.ShipmentPackageType Find(string packageTypeName);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

