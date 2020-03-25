﻿// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Product;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Product
{
    [RoutePrefix("api/Product/Package")]
    public class PackageController : CRUDLApiController<Overtech.DataModels.Product.Package, IPackageService, Overtech.ViewModels.Product.Package>
    {
        /*Section="Constructor"*/
        public PackageController(
            ILoggerFactory loggerFactory,
            IPackageService packageService)
            : base(loggerFactory, packageService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}