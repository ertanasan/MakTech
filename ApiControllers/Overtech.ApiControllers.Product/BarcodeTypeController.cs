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
using Overtech.ServiceContracts.Product;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Product
{
    [RoutePrefix("api/Product/BarcodeType")]
    public class BarcodeTypeController : CRUDLApiController<Overtech.DataModels.Product.BarcodeType, IBarcodeTypeService, Overtech.ViewModels.Product.BarcodeType>
    {
        /*Section="Constructor"*/
        public BarcodeTypeController(
            ILoggerFactory loggerFactory,
            IBarcodeTypeService barcodeTypeService)
            : base(loggerFactory, barcodeTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}