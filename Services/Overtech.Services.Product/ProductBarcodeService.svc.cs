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

/*Section="ClassHeader"*/
namespace Overtech.Services.Product
{
    [OTInspectorBehavior]
    public class ProductBarcodeService : CRUDLDataService<Overtech.DataModels.Product.ProductBarcode>, IProductBarcodeService
    {
        /*Section="Constructor-1"*/
        public ProductBarcodeService()
        {
        }

        /*Section="Constructor-2"*/
        internal ProductBarcodeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.ProductBarcode Find(string barcodeText)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmBarcodeText = dal.CreateParameter("BarcodeText", barcodeText);
                return dal.Read<Overtech.DataModels.Product.ProductBarcode>("PRD_SEL_FINDBARCODE_SP", prmBarcodeText);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public IEnumerable<Overtech.DataModels.Product.ProductBarcode> ListBarcodeByProductId(long productId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter productPrm = dal.CreateParameter("Product", productId);
                return dal.List<ProductBarcode>("PRD_LST_BARCDEBYPRODUCTID_SP", productPrm).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}