// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Product;
using Overtech.ServiceContracts.Product;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Product
{
    [OTInspectorBehavior]
    public class ProductService : CRUDLDataService<Overtech.DataModels.Product.Product>, IProductService
    {
        /*Section="Constructor-1"*/
        public ProductService()
        {
        }

        /*Section="Constructor-2"*/
        internal ProductService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.Product Find(string name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmName = dal.CreateParameter("Name", name);
                return dal.Read<Overtech.DataModels.Product.Product>("PRD_SEL_FINDPRODUCT_SP", prmName);
            }
        }

        /*Section="Method-ListProductProperties"*/
        public IEnumerable<ProductProperty> ListProductProperties(long productId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProduct = dal.CreateParameter("Product", productId);
                return dal.List<ProductProperty>("PRD_LST_PROPERTY_SP", prmProduct).ToList();
            }
        }

        /*Section="Method-ListProductBarcodes"*/
        public IEnumerable<ProductBarcode> ListProductBarcodes(long productId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProduct = dal.CreateParameter("Product", productId);
                return dal.List<ProductBarcode>("PRD_LST_BARCODE_SP", prmProduct).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public DataTable ListHotKeys()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("PRD_LST_HOTKEYS_SP").Tables[0];
            }
        }

        public DataTable ListHotKeys32()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("PRD_LST_HOTKEYS32_SP").Tables[0];
            }
        }

        public DataTable ListHotKeys56()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.ExecuteDataset("PRD_LST_HOTKEYS56_SP").Tables[0];
            }
        }

        public IEnumerable<Overtech.DataModels.Product.Product> ListConsignmentGoods()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<Overtech.DataModels.Product.Product>("PRD_LST_CONSIGNMENTGOODS_SP").ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}