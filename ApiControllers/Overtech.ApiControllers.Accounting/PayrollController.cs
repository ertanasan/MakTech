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
    public class MikroTransferPayrollListModel
    {
        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public int Month { get; set; }
    }

    [RoutePrefix("api/Accounting/Payroll")]
    public class PayrollController : CRUDLApiController<Overtech.DataModels.Accounting.Payroll, IPayrollService, Overtech.ViewModels.Accounting.Payroll>
    {
        /*Section="Constructor"*/
        public PayrollController(
            ILoggerFactory loggerFactory,
            IPayrollService payrollService)
            : base(loggerFactory, payrollService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpPost]
        [OTControllerAction("Create")]
        [Route("LoadHRFile")]
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
                    _dataService.LoadHRFile(data);

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
        [Route("ListMonth")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Accounting.Payroll> ListDay(int year, int month)
        {
            return _dataService.ListMonth(year, month).Map<Overtech.DataModels.Accounting.Payroll, Overtech.ViewModels.Accounting.Payroll>();
        }

        [HttpPost]
        [Route("MikroTransfer")]
        [OTControllerAction("Create")]
        public HttpResponseMessage MikroTransfer(MikroTransferPayrollListModel viewModel)
        {

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                _dataService.MikroTransfer(viewModel.Year, viewModel.Month);
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