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
using Overtech.ServiceContracts.Sale;
using Overtech.ViewModels.Sale;
using System.Net.Http;
using System;
using System.Net;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Sale
{
    [RoutePrefix("api/Sale/CancelReason")]
    public class CancelReasonController : CRUDLApiController<Overtech.DataModels.Sale.CancelReason, ICancelReasonService, Overtech.ViewModels.Sale.CancelReason>
    {
        /*Section="Constructor"*/
        public CancelReasonController(
            ILoggerFactory loggerFactory,
            ICancelReasonService cancelReasonService)
            : base(loggerFactory, cancelReasonService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        [HttpGet]
        [Route("ListRecCancelsByDate")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Sale.CancelReason> ListRecCancelsByDate(DateTime recDate, int storeId = -1)
        {
            return _dataService.ListRecCancelsByDate(recDate, storeId).Map<Overtech.DataModels.Sale.CancelReason, Overtech.ViewModels.Sale.CancelReason>();
        }

        [HttpPost]
        [Route("SaveCancelReasons")]
        [OTControllerAction("Create")]
        public HttpResponseMessage SaveCancelReasons(IEnumerable<CancelReason> viewModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.SaveCancelReasons(viewModel.Map<Overtech.DataModels.Sale.CancelReason, Overtech.ViewModels.Sale.CancelReason>());
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(ex.Message);
            }
            return response;
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}