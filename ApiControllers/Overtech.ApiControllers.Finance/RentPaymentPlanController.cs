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
    [RoutePrefix("api/Finance/RentPaymentPlan")]
    public class RentPaymentPlanController : CRUDLApiController<Overtech.DataModels.Finance.RentPaymentPlan, IRentPaymentPlanService, Overtech.ViewModels.Finance.RentPaymentPlan>
    {

        private readonly IEstateRentPeriodService _estateRentPeriodService;

        /*Section="Constructor"*/
        public RentPaymentPlanController(
            ILoggerFactory loggerFactory,
            IRentPaymentPlanService rentPaymentPlanService,
            IEstateRentPeriodService estateRentPeriodService
)
            : base(loggerFactory, rentPaymentPlanService)
        {
            _estateRentPeriodService = estateRentPeriodService;
        }

        /*Section="Method-ListByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListByMaster")]
        [OTControllerAction("List")]
        public DataSourceResult ListByMaster([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request, long masterId)
        {
            IEnumerable<Overtech.DataModels.Finance.RentPaymentPlan> dataModel = _estateRentPeriodService.ListRentPaymentPlans(masterId);
            IEnumerable<Overtech.ViewModels.Finance.RentPaymentPlan> viewModel = dataModel.Map<Overtech.DataModels.Finance.RentPaymentPlan, Overtech.ViewModels.Finance.RentPaymentPlan>();
            return viewModel.ToDataSourceResult(request);
        }

        /*Section="Method-ListAllByMaster"*/
        [HttpGet, ActionName("ListByMaster")]
        [Route("ListAllByMaster")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Finance.RentPaymentPlan> ListAllByMaster(long masterId)
        {
            IEnumerable<Overtech.DataModels.Finance.RentPaymentPlan> dataModel = _estateRentPeriodService.ListRentPaymentPlans(masterId);
            IEnumerable<Overtech.ViewModels.Finance.RentPaymentPlan> viewModel = dataModel.Map<Overtech.DataModels.Finance.RentPaymentPlan, Overtech.ViewModels.Finance.RentPaymentPlan>();
            return viewModel;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpGet]
        [Route("GenerateAllPayments")]
        [OTControllerAction("Create")]
        public long GenerateAllPayments(bool isKeepExistingRecords)
        {
            return _dataService.GenerateAllPayments(isKeepExistingRecords);
        }

        [HttpGet]
        [Route("ClonePayment")]
        [OTControllerAction("Create")]
        public long ClonePayment(long templateRecordId)
        {
            return _dataService.ClonePayment(templateRecordId);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}