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
using Overtech.ServiceContracts.Store;

using System.Web;
using System.Net.Http;
using System.Net;
using System;
using System.Runtime.Serialization;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/WorkingHours")]
    public class WorkingHoursController : CRUDLApiController<Overtech.DataModels.Store.WorkingHours, IWorkingHoursService, Overtech.ViewModels.Store.WorkingHours>
    {
        /*Section="Constructor"*/
        public WorkingHoursController(
            ILoggerFactory loggerFactory,
            IWorkingHoursService workingHoursService)
            : base(loggerFactory, workingHoursService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpPost]
        [OTControllerAction("Create")]
        [Route("LoadWorkingHoursFile")]
        public HttpResponseMessage LoadWorkingHoursFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                string result = "";
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    int fileLen = httpRequest.Files[0].ContentLength;
                    byte[] data = new byte[fileLen];
                    System.IO.Stream fileStream = httpRequest.Files[0].InputStream;
                    fileStream.Read(data, 0, fileLen);
                    result = _dataService.LoadWorkingHoursFile(data);

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

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}