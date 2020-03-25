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
    [RoutePrefix("api/Product/SuperGroup1")]
    public class SuperGroup1Controller : CRUDLApiController<Overtech.DataModels.Product.SuperGroup1, ISuperGroup1Service, Overtech.ViewModels.Product.SuperGroup1>
    {
        /*Section="Constructor"*/
        public SuperGroup1Controller(
            ILoggerFactory loggerFactory,
            ISuperGroup1Service superGroup1Service)
            : base(loggerFactory, superGroup1Service)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}