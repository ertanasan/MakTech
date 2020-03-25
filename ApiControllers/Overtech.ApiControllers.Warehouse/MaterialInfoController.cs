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
    [RoutePrefix("api/Warehouse/MaterialInfo")]
    public class MaterialInfoController : CRUDLApiController<Overtech.DataModels.Warehouse.MaterialInfo, IMaterialInfoService, Overtech.ViewModels.Warehouse.MaterialInfo>
    {

        private readonly IMaterialService _materialService;

        /*Section="Constructor"*/
        public MaterialInfoController(
            ILoggerFactory loggerFactory,
            IMaterialInfoService materialInfoService,
            IMaterialService materialService
)
            : base(loggerFactory, materialInfoService)
        {
            _materialService = materialService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Warehouse.MaterialInfo> dataModel = _materialService.ListMaterialInfoes(masterId);
            IEnumerable<Overtech.ViewModels.Warehouse.MaterialInfo> viewModel = dataModel.Map<Overtech.DataModels.Warehouse.MaterialInfo, Overtech.ViewModels.Warehouse.MaterialInfo>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.MaterialInfo> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Warehouse.MaterialInfo> dataModel = _materialService.ListMaterialInfoes(masterId);
            IEnumerable<Overtech.ViewModels.Warehouse.MaterialInfo> viewModel = dataModel.Map<Overtech.DataModels.Warehouse.MaterialInfo, Overtech.ViewModels.Warehouse.MaterialInfo>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}