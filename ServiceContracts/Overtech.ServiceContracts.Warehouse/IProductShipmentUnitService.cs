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
    public interface IProductShipmentUnitService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.ProductShipmentUnit>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Warehouse.ProductShipmentUnit Find(string product);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        IEnumerable<Overtech.DataModels.Warehouse.ProductShipmentUnit> ListProductShipmentUnit(long productId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

