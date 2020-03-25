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
using Overtech.ViewModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/Production")]
    public class ProductionController : CRUDLApiController<Overtech.DataModels.Warehouse.Production, IProductionService, Overtech.ViewModels.Warehouse.Production>
    {
        /*Section="Constructor"*/
        public ProductionController(
            ILoggerFactory loggerFactory,
            IProductionService productionService)
            : base(loggerFactory, productionService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListProductionContentswithStocks")]
        public IEnumerable<ProductionContent> ListProductionContentswithStocks(long productionId)
        {
            return _dataService.ListProductionContentswithStocks(productionId).Map<Overtech.DataModels.Warehouse.ProductionContent, ProductionContent>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}