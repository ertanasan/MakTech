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
    [RoutePrefix("api/Product/SuperGroup2")]
    public class SuperGroup2Controller : CRUDLApiController<Overtech.DataModels.Product.SuperGroup2, ISuperGroup2Service, Overtech.ViewModels.Product.SuperGroup2>
    {
        /*Section="Constructor"*/
        public SuperGroup2Controller(
            ILoggerFactory loggerFactory,
            ISuperGroup2Service superGroup2Service)
            : base(loggerFactory, superGroup2Service)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}