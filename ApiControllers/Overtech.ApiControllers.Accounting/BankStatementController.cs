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
    [RoutePrefix("api/Accounting/BankStatement")]
    public class BankStatementController : CRUDLApiController<Overtech.DataModels.Accounting.BankStatement, IBankStatementService, Overtech.ViewModels.Accounting.BankStatement>
    {
        /*Section="Constructor"*/
        public BankStatementController(
            ILoggerFactory loggerFactory,
            IBankStatementService bankStatementService)
            : base(loggerFactory, bankStatementService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        [HttpPost]
        [OTControllerAction("Create")]
        [Route("LoadIngBankStatementFile")]
        public HttpResponseMessage LoadIngBankStatementFile()
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
                    result = _dataService.LoadBankStatementFile(data, "ING Bank"); 

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
        [Route("LoadTebBankStatementFile")]
        public HttpResponseMessage LoadTebBankStatementFile()
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
                    result = _dataService.LoadBankStatementFile(data, "TEB");

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
        [Route("LoadVakifBankStatementFile")]
        public HttpResponseMessage LoadVakifBankStatementFile()
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
                    result = _dataService.LoadBankStatementFile(data, "Vakıfbank");

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
        public IEnumerable<Overtech.ViewModels.Accounting.BankStatement> TransactionList(DateTime transactionDate)
        {
            return _dataService.ListDay(transactionDate).Map<Overtech.DataModels.Accounting.BankStatement, Overtech.ViewModels.Accounting.BankStatement>();
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}