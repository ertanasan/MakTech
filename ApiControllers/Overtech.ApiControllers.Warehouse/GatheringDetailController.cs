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

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    public class PostList
    {
        [DataMember]
        public long GatheringId { get; set; }

        [DataMember]
        public int PalletNo { get; set; }

        [DataMember]
        public int ProductId { get; set; }
    }

    [RoutePrefix("api/Warehouse/GatheringDetail")]
    public class GatheringDetailController : CRUDLApiController<Overtech.DataModels.Warehouse.GatheringDetail, IGatheringDetailService, Overtech.ViewModels.Warehouse.GatheringDetail>
    {
        /*Section="Constructor"*/
        public GatheringDetailController(
            ILoggerFactory loggerFactory,
            IGatheringDetailService gatheringDetailService)
            : base(loggerFactory, gatheringDetailService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpGet]
        [Route("ListGatheringDetail")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.GatheringDetail> ListGatheringDetail(long gatheringId)
        {
            return _dataService.ListGatheringDetail(gatheringId).Map<Overtech.DataModels.Warehouse.GatheringDetail, Overtech.ViewModels.Warehouse.GatheringDetail>();
        }

        [HttpGet]
        [Route("ListGatheringControlAddProduct")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Product.Product> ListGatheringControlAddProduct(long GatheringId, int PalletNo)
        {
            return _dataService.ListGatheringControlAddProduct(GatheringId, PalletNo).Map<Overtech.DataModels.Product.Product, Overtech.ViewModels.Product.Product>();
        }

        [HttpPost]
        [Route("AddProducttoControlList")]
        [OTControllerAction("Create")]
        public HttpResponseMessage AddProducttoControlList(PostList viewModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.AddProducttoControlList(viewModel.GatheringId, viewModel.PalletNo, viewModel.ProductId);
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
        [Route("LogControlZero")]
        [OTControllerAction("Create")]
        public HttpResponseMessage LogControlZero(long GatheringPalletId, long GatheringDetailId, decimal? PreviousQuantity)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.LogControlZero(GatheringPalletId, GatheringDetailId, PreviousQuantity);
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