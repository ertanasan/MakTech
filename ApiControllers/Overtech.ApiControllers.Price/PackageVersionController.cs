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
    [RoutePrefix("api/Price/PackageVersion")]
    public class PackageVersionController : CRUDLApiController<Overtech.DataModels.Price.PackageVersion, IPackageVersionService, Overtech.ViewModels.Price.PackageVersion>
    {

        private readonly IPricePackageService _pricePackageService;

        /*Section="Constructor"*/
        public PackageVersionController(
            ILoggerFactory loggerFactory,
            IPackageVersionService packageVersionService,
            IPricePackageService pricePackageService
)
            : base(loggerFactory, packageVersionService)
        {
            _pricePackageService = pricePackageService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Price.PackageVersion> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Price.PackageVersion> dataModel = _pricePackageService.ListPackageVersions(masterId);
            IEnumerable<Overtech.ViewModels.Price.PackageVersion> viewModel = dataModel.Map<Overtech.DataModels.Price.PackageVersion, Overtech.ViewModels.Price.PackageVersion>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}