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
    public class BarcodeTypeIntService : CRUDLDataService<Overtech.DataModels.Product.BarcodeTypeInt>, IBarcodeTypeIntService
    {
        /*Section="Constructor-1"*/
        public BarcodeTypeIntService()
        {
        }

        /*Section="Constructor-2"*/
        internal BarcodeTypeIntService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.BarcodeTypeInt Find(string barcodeType)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmBarcodeType = dal.CreateParameter("BarcodeType", barcodeType);
                return dal.Read<Overtech.DataModels.Product.BarcodeTypeInt>("PRD_SEL_FINDBARCODETYPEINT_SP", prmBarcodeType);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}