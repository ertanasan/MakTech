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
    public class ShipmentTypeService : CRUDLDataService<Overtech.DataModels.Warehouse.ShipmentType>, IShipmentTypeService
    {
        /*Section="Constructor-1"*/
        public ShipmentTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal ShipmentTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.ShipmentType Find(string shipmentTypeName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmShipmentTypeName = dal.CreateParameter("ShipmentTypeName", shipmentTypeName);
                return dal.Read<Overtech.DataModels.Warehouse.ShipmentType>("WHS_SEL_FINDSHIPMENTTYPE_SP", prmShipmentTypeName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}