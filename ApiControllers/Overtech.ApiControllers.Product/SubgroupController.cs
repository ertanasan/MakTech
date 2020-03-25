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
using Overtech.ServiceContracts.Product;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Product
{
    [RoutePrefix("api/Product/Subgroup")]
    public class SubgroupController : CRUDLApiController<Overtech.DataModels.Product.Subgroup, ISubgroupService, Overtech.ViewModels.Product.Subgroup>
    {

        private readonly IProductCategoryService _productCategoryService;

        /*Section="Constructor"*/
        public SubgroupController(
            ILoggerFactory loggerFactory,
            ISubgroupService subgroupService,
            IProductCategoryService productCategoryService
)
            : base(loggerFactory, subgroupService)
        {
            _productCategoryService = productCategoryService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Product.Subgroup> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Product.Subgroup> dataModel = _productCategoryService.ListSubgroups(masterId);
            IEnumerable<Overtech.ViewModels.Product.Subgroup> viewModel = dataModel.Map<Overtech.DataModels.Product.Subgroup, Overtech.ViewModels.Product.Subgroup>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}