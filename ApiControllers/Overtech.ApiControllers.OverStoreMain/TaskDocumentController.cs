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
using Overtech.ServiceContracts.OverStoreMain;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.OverStoreMain
{
    [RoutePrefix("api/OverStoreMain/TaskDocument")]
    public class TaskDocumentController : OTRelationApiController<Overtech.DataModels.OverStoreMain.TaskDocument, ITaskDocumentService, Overtech.ViewModels.OverStoreMain.TaskDocument>
    {
        /*Section="Constructor"*/
        public TaskDocumentController(
            ILoggerFactory loggerFactory,
            ITaskDocumentService taskDocumentService)
            : base(loggerFactory, taskDocumentService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}