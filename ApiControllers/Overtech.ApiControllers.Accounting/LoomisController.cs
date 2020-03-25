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
using Overtech.ServiceContracts.Accounting;
using System.Net.Http;
using System.Web;
using System.Net;
using System;
using System.Runtime.Serialization;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Accounting
{
    public class MikroTransferLoomisListModel
    {
        [DataMember]
        public DateTime SaleDate { get; set; }

        [DataMember]
        public long[] LoomisIdList { get; set; }
    }

    [RoutePrefix("api/Accounting/Loomis")]
    public class LoomisController : CRUDLApiController<Overtech.DataModels.Accounting.Loomis, ILoomisService, Overtech.ViewModels.Accounting.Loomis>
    {
        /*Section="Constructor"*/
        public LoomisController(
            ILoggerFactory loggerFactory,
            ILoomisService loomisService)
            : base(loggerFactory, loomisService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpPost]
        [OTControllerAction("Create")]
        [Route("LoadLoomisFile")]
        public HttpResponseMessage LoadBankPOSFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string result = "";
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    int FileLen = httpRequest.Files[0].ContentLength;
                    byte[] data = new byte[FileLen];
                    System.IO.Stream fileStream = httpRequest.Files[0].InputStream;
                    fileStream.Read(data, 0, FileLen);
                    _dataService.LoadLoomisFile(data);

                }
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent(result);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent(ex.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("ListDay")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Accounting.Loomis> ListDay(DateTime saleDate)
        {
            return _dataService.ListDay(saleDate).Map<Overtech.DataModels.Accounting.Loomis, Overtech.ViewModels.Accounting.Loomis>();
        }

        [HttpPost]
        [Route("MikroTransfer")]
        [OTControllerAction("Create")]
        public HttpResponseMessage MikroTransfer(MikroTransferLoomisListModel viewModel)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.MikroTransfer(viewModel.SaleDate, viewModel.LoomisIdList);
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
        [Route("CancelMikroTransfer/{saleDate}")]
        [OTControllerAction("Update")]
        public HttpResponseMessage CancelMikroTransfer(DateTime saleDate)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.CancelMikroTransfer(saleDate);
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
        [Route("ClearDate/{saleDate}")]
        [OTControllerAction("Delete")]
        public HttpResponseMessage ClearDate(DateTime saleDate)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.ClearDate(saleDate);
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