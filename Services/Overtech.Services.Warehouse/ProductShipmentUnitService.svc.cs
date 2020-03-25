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
    public class ProductShipmentUnitService : CRUDLDataService<Overtech.DataModels.Warehouse.ProductShipmentUnit>, IProductShipmentUnitService
    {
        /*Section="Constructor-1"*/
        public ProductShipmentUnitService()
        {
        }

        /*Section="Constructor-2"*/
        internal ProductShipmentUnitService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.ProductShipmentUnit Find(string product)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProduct = dal.CreateParameter("Product", product);
                return dal.Read<Overtech.DataModels.Warehouse.ProductShipmentUnit>("WHS_SEL_FINDPRODUCTSHIPMENTUNIT_SP", prmProduct);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        public IEnumerable<Overtech.DataModels.Warehouse.ProductShipmentUnit> ListProductShipmentUnit(long productId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProduct = dal.CreateParameter("Product", productId);
                return dal.List<Overtech.DataModels.Warehouse.ProductShipmentUnit>("WHS_LST_PRODUCTSHIPMENTUNIT_SP", prmProduct).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}