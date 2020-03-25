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
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/RegionManagers")]
    public class RegionManagersController : CRUDLApiController<Overtech.DataModels.Store.RegionManagers, IRegionManagersService, Overtech.ViewModels.Store.RegionManagers>
    {
        /*Section="Constructor"*/
        public RegionManagersController(
            ILoggerFactory loggerFactory,
            IRegionManagersService regionManagersService)
            : base(loggerFactory, regionManagersService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}