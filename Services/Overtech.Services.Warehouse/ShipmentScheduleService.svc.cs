// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class ShipmentScheduleService : CRUDLDataService<Overtech.DataModels.Warehouse.ShipmentSchedule>, IShipmentScheduleService
    {
        /*Section="Constructor-1"*/
        public ShipmentScheduleService()
        {
        }

        /*Section="Constructor-2"*/
        internal ShipmentScheduleService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        /*Section="Method-ListShipmentSchedules"*/
        public IEnumerable<ShipmentSchedule> ListShipmentSchedules(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                return dal.List<ShipmentSchedule>("WHS_LST_SHIPMENTSCHEDULE_SP", prmStore).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}