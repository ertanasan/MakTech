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
    public interface IShipmentScheduleService : ICRUDLServiceContract<Overtech.DataModels.Warehouse.ShipmentSchedule>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        /*Section="Method-ListShipmentSchedules"*/
        [OperationContract]
        IEnumerable<ShipmentSchedule> ListShipmentSchedules(long storeId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

