// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/ScaleBrand")]
    public class ScaleBrandController : CRUDLApiController<Overtech.DataModels.Store.ScaleBrand, IScaleBrandService, Overtech.ViewModels.Store.ScaleBrand>
    {
        /*Section="Constructor"*/
        public ScaleBrandController(
            ILoggerFactory loggerFactory,
            IScaleBrandService scaleBrandService)
            : base(loggerFactory, scaleBrandService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}