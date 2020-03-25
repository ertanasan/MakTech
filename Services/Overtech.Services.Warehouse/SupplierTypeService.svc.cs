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
    public class SupplierTypeService : CRUDLDataService<Overtech.DataModels.Warehouse.SupplierType>, ISupplierTypeService
    {
        /*Section="Constructor-1"*/
        public SupplierTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal SupplierTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.SupplierType Find(string supplierTypeName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSupplierTypeName = dal.CreateParameter("SupplierTypeName", supplierTypeName);
                return dal.Read<Overtech.DataModels.Warehouse.SupplierType>("WHS_SEL_FINDSUPPLIERTYPE_SP", prmSupplierTypeName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}