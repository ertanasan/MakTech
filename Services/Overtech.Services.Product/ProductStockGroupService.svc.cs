﻿// Created by OverGenerator
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
    public class ProductStockGroupService : CRUDLDataService<Overtech.DataModels.Product.ProductStockGroup>, IProductStockGroupService
    {
        /*Section="Constructor-1"*/
        public ProductStockGroupService()
        {
        }

        /*Section="Constructor-2"*/
        internal ProductStockGroupService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}