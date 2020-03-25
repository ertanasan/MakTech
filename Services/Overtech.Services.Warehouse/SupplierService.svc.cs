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
    public class SupplierService : CRUDLDataService<Overtech.DataModels.Warehouse.Supplier>, ISupplierService
    {
        /*Section="Constructor-1"*/
        public SupplierService()
        {
        }

        /*Section="Constructor-2"*/
        internal SupplierService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.Supplier Find(string supplierName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSupplierName = dal.CreateParameter("SupplierName", supplierName);
                return dal.Read<Overtech.DataModels.Warehouse.Supplier>("WHS_SEL_FINDSUPPLIER_SP", prmSupplierName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}