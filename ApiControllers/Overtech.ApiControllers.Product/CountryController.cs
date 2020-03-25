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
    [RoutePrefix("api/Product/ProductCountry")]
    public class ProductCountryController : CRUDLApiController<Overtech.DataModels.Product.Country, ICountryService, Overtech.ViewModels.Product.Country>
    {
        /*Section="Constructor"*/
        public ProductCountryController(
            ILoggerFactory loggerFactory,
            ICountryService countryService)
            : base(loggerFactory, countryService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}