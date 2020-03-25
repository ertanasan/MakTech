// Created by OverGenerator
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
using Overtech.ServiceContracts.Price;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Price
{
    [RoutePrefix("api/Price/PackageType")]
    public class PackageTypeController : CRUDLApiController<Overtech.DataModels.Price.PackageType, IPackageTypeService, Overtech.ViewModels.Price.PackageType>
    {
        /*Section="Constructor"*/
        public PackageTypeController(
            ILoggerFactory loggerFactory,
            IPackageTypeService packageTypeService)
            : base(loggerFactory, packageTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}