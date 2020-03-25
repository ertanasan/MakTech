// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.StoreUpload;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.StoreUpload
{
    [RoutePrefix("api/StoreUpload/DataUpload")]
    public class DataUploadController : CRUDLApiController<Overtech.DataModels.StoreUpload.DataUpload, IDataUploadService, Overtech.ViewModels.StoreUpload.DataUpload>
    {
        /*Section="Constructor"*/
        public DataUploadController(
            ILoggerFactory loggerFactory,
            IDataUploadService dataUploadService)
            : base(loggerFactory, dataUploadService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}