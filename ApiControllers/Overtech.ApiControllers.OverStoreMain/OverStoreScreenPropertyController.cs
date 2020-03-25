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
    [RoutePrefix("api/OverStoreMain/OverStoreScreenProperty")]
    public class OverStoreScreenPropertyController : CRUDLApiController<Overtech.DataModels.OverStoreMain.OverStoreScreenProperty, IOverStoreScreenPropertyService, Overtech.ViewModels.OverStoreMain.OverStoreScreenProperty>
    {
        /*Section="Constructor"*/
        public OverStoreScreenPropertyController(
            ILoggerFactory loggerFactory,
            IOverStoreScreenPropertyService overStoreScreenPropertyService)
            : base(loggerFactory, overStoreScreenPropertyService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [Route("ListScreenProperties")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.OverStoreMain.OverStoreScreenProperty> ListScreenProperties(int screenId)
        {

            return _dataService.ListScreenProperties(screenId).Map<Overtech.DataModels.OverStoreMain.OverStoreScreenProperty, Overtech.ViewModels.OverStoreMain.OverStoreScreenProperty>();

        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}