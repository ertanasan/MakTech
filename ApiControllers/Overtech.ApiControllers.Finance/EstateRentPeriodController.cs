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
using Overtech.ServiceContracts.Finance;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Finance
{
    [RoutePrefix("api/Finance/EstateRentPeriod")]
    public class EstateRentPeriodController : CRUDLApiController<Overtech.DataModels.Finance.EstateRentPeriod, IEstateRentPeriodService, Overtech.ViewModels.Finance.EstateRentPeriod>
    {

        private readonly IEstateRentService _estateRentService;

        /*Section="Constructor"*/
        public EstateRentPeriodController(
            ILoggerFactory loggerFactory,
            IEstateRentPeriodService estateRentPeriodService,
            IEstateRentService estateRentService
)
            : base(loggerFactory, estateRentPeriodService)
        {
            _estateRentService = estateRentService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Finance.EstateRentPeriod> dataModel = _estateRentService.ListEstateRentPeriods(masterId);
            IEnumerable<Overtech.ViewModels.Finance.EstateRentPeriod> viewModel = dataModel.Map<Overtech.DataModels.Finance.EstateRentPeriod, Overtech.ViewModels.Finance.EstateRentPeriod>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Finance.EstateRentPeriod> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Finance.EstateRentPeriod> dataModel = _estateRentService.ListEstateRentPeriods(masterId);
            IEnumerable<Overtech.ViewModels.Finance.EstateRentPeriod> viewModel = dataModel.Map<Overtech.DataModels.Finance.EstateRentPeriod, Overtech.ViewModels.Finance.EstateRentPeriod>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpGet]
        [Route("GenerateAllPeriods")]
        [OTControllerAction("Create")]
        public long GenerateAllPeriods(bool isKeepExistingRecords)
        {
            return _dataService.GenerateAllPeriods(isKeepExistingRecords);
        }

        [HttpGet]
        [Route("ClonePeriod")]
        [OTControllerAction("Create")]
        public long ClonePeriod(long templateRecordId)
        {
            return _dataService.ClonePeriod(templateRecordId);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}