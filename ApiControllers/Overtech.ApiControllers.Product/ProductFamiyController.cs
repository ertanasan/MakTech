﻿// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Product;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Product
{
    [RoutePrefix("api/Product/ProductFamiy")]
    public class ProductFamiyController : CRUDLApiController<Overtech.DataModels.Product.ProductFamiy, IProductFamiyService, Overtech.ViewModels.Product.ProductFamiy>
    {
        /*Section="Constructor"*/
        public ProductFamiyController(
            ILoggerFactory loggerFactory,
            IProductFamiyService productFamiyService)
            : base(loggerFactory, productFamiyService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}