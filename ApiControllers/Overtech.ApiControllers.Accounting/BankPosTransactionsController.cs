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
using System.Web.Http.ModelBinding;
using Overtech.ViewModels.Accounting;
using System.Web;
using System.Net.Http;
using System.Net;
using System;
using System.Runtime.Serialization;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Accounting
{

    public class MikroTransferListModel
    {
        [DataMember]
        public DateTime BlockedDate { get; set; }

        [DataMember]
        public long[] BankPosTransactionsIdList { get; set; }
    }

    [RoutePrefix("api/Accounting/BankPosTransactions")]
    public class BankPosTransactionsController : CRUDLApiController<Overtech.DataModels.Accounting.BankPosTransactions, IBankPosTransactionsService, Overtech.ViewModels.Accounting.BankPosTransactions>
    {
        /*Section="Constructor"*/
        public BankPosTransactionsController(
            ILoggerFactory loggerFactory,
            IBankPosTransactionsService bankPosTransactionsService)
            : base(loggerFactory, bankPosTransactionsService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        [HttpPost]
        [OTControllerAction("Create")]
        [Route("LoadBankPOSFile")]
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
                    result = _dataService.LoadBankPOSFile(data);

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

        [HttpPost]
        [OTControllerAction("Create")]
        [Route("ZiraatLoadBankPOSFile")]
        public HttpResponseMessage ZiraatLoadBankPOSFile()
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
                    result = _dataService.ZiraatLoadBankPOSFile(data);

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
        public IEnumerable<Overtech.ViewModels.Accounting.BankPosTransactions> MikroTransferList(DateTime blockedDate)
        {
            return _dataService.ListDay(blockedDate).Map<Overtech.DataModels.Accounting.BankPosTransactions, Overtech.ViewModels.Accounting.BankPosTransactions>();
        }

        [HttpPost]
        [Route("MikroTransfer")]
        [OTControllerAction("Create")]
        public HttpResponseMessage MikroTransfer(MikroTransferListModel viewModel)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.MikroTransfer(viewModel.BlockedDate, viewModel.BankPosTransactionsIdList);
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
        [Route("CancelMikroTransfer/{blockedDate}")]
        [OTControllerAction("Update")]
        public HttpResponseMessage CancelMikroTransfer(DateTime blockedDate)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.CancelMikroTransfer(blockedDate);
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
        [Route("ClearDate/{blockedDate}")]
        [OTControllerAction("Delete")]
        public HttpResponseMessage ClearDate(DateTime blockedDate)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.ClearDate(blockedDate);
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