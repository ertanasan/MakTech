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
    [RoutePrefix("api/Sale/PosTrxType")]
    public class PosTrxTypeController : CRUDLApiController<Overtech.DataModels.Sale.PosTrxType, IPosTrxTypeService, Overtech.ViewModels.Sale.PosTrxType>
    {
        /*Section="Constructor"*/
        public PosTrxTypeController(
            ILoggerFactory loggerFactory,
            IPosTrxTypeService posTrxTypeService)
            : base(loggerFactory, posTrxTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}