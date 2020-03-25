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
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/ProductionContent")]
    public class ProductionContentController : CRUDLApiController<Overtech.DataModels.Warehouse.ProductionContent, IProductionContentService, Overtech.ViewModels.Warehouse.ProductionContent>
    {
        private readonly IProductionService _productionService;

        /*Section="Constructor"*/
        public ProductionContentController(
            ILoggerFactory loggerFactory,
            IProductionContentService productionContentService,
            IProductionService productionService)
            : base(loggerFactory, productionContentService)
        {
            _productionService = productionService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.ProductionContent> ListByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Warehouse.ProductionContent> dataModel = _productionService.ListProductionContents(masterId);
            IEnumerable<Overtech.ViewModels.Warehouse.ProductionContent> viewModel = dataModel.Map<Overtech.DataModels.Warehouse.ProductionContent, Overtech.ViewModels.Warehouse.ProductionContent>();
            return viewModel;
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}