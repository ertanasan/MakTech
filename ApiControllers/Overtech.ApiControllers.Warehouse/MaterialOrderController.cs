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
using System.Runtime.Serialization;
using System.Net.Http;
using System.Net;
using System;
using Overtech.ViewModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{

    public class MaterialOrderUpdateList
    {
        [DataMember]
        public int OrderStatusCode { get; set; }

        [DataMember]
        public long[] MaterialOrderIdList { get; set; }
    }

    [RoutePrefix("api/Warehouse/MaterialOrder")]
    public class MaterialOrderController : CRUDLApiController<Overtech.DataModels.Warehouse.MaterialOrder, IMaterialOrderService, Overtech.ViewModels.Warehouse.MaterialOrder>
    {
        /*Section="Constructor"*/
        public MaterialOrderController(
            ILoggerFactory loggerFactory,
            IMaterialOrderService materialOrderService)
            : base(loggerFactory, materialOrderService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpPost]
        [Route("UpdateStatus")]
        [OTControllerAction("Update")]
        public HttpResponseMessage MikroTransfer(MaterialOrderUpdateList viewModel)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.UpdateStatus(viewModel.OrderStatusCode, viewModel.MaterialOrderIdList);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(ex.Message);
            }
            return response;

        }

        [HttpPost]
        [Route("TakeOrderAction")]
        [OTControllerAction("Update")]
        public HttpResponseMessage TakeOrderAction(MaterialOrderUpdateList viewModel)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.TakeOrderAction(viewModel.OrderStatusCode, viewModel.MaterialOrderIdList);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(ex.Message);
            }
            return response;

        }

        [HttpGet]
        [Route("ListOrders")]
        [OTControllerAction("List")]
        public IEnumerable<MaterialOrder> ListOrders(DateTime StartDate, Boolean AllRecords)
        {
            return _dataService.ListOrders(StartDate, AllRecords).Map<DataModels.Warehouse.MaterialOrder, MaterialOrder>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}