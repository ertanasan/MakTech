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
    public class ShipmentPackageTypeService : CRUDLDataService<Overtech.DataModels.Warehouse.ShipmentPackageType>, IShipmentPackageTypeService
    {
        /*Section="Constructor-1"*/
        public ShipmentPackageTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal ShipmentPackageTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.ShipmentPackageType Find(string packageTypeName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPackageTypeName = dal.CreateParameter("PackageTypeName", packageTypeName);
                return dal.Read<Overtech.DataModels.Warehouse.ShipmentPackageType>("WHS_SEL_FINDPACKAGETYPE_SP", prmPackageTypeName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}