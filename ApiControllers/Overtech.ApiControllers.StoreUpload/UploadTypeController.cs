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
    [RoutePrefix("api/StoreUpload/UploadType")]
    public class UploadTypeController : CRUDLApiController<Overtech.DataModels.StoreUpload.UploadType, IUploadTypeService, Overtech.ViewModels.StoreUpload.UploadType>
    {
        /*Section="Constructor"*/
        public UploadTypeController(
            ILoggerFactory loggerFactory,
            IUploadTypeService uploadTypeService)
            : base(loggerFactory, uploadTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}