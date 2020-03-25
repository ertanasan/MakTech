// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Product;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Product
{
    [RoutePrefix("api/Product/PropertyType")]
    public class PropertyTypeController : CRUDLApiController<Overtech.DataModels.Product.PropertyType, IPropertyTypeService, Overtech.ViewModels.Product.PropertyType>
    {
        /*Section="Constructor"*/
        public PropertyTypeController(
            ILoggerFactory loggerFactory,
            IPropertyTypeService propertyTypeService)
            : base(loggerFactory, propertyTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}