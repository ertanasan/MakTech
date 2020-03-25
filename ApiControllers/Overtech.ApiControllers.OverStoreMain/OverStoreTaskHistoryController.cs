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
    [RoutePrefix("api/OverStoreMain/OverStoreTaskHistory")]
    public class OverStoreTaskHistoryController : CRUDLApiController<Overtech.DataModels.OverStoreMain.OverStoreTaskHistory, IOverStoreTaskHistoryService, Overtech.ViewModels.OverStoreMain.OverStoreTaskHistory>
    {
        /*Section="Constructor"*/
        public OverStoreTaskHistoryController(
            ILoggerFactory loggerFactory,
            IOverStoreTaskHistoryService overStoreTaskHistoryService)
            : base(loggerFactory, overStoreTaskHistoryService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}