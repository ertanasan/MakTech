// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Sale
{
    [RoutePrefix("api/Sale/PosBankType")]
    public class PosBankTypeController : CRUDLApiController<Overtech.DataModels.Sale.PosBankType, IPosBankTypeService, Overtech.ViewModels.Sale.PosBankType>
    {
        /*Section="Constructor"*/
        public PosBankTypeController(
            ILoggerFactory loggerFactory,
            IPosBankTypeService posBankTypeService)
            : base(loggerFactory, posBankTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}