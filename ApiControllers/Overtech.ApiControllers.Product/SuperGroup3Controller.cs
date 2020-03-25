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
    [RoutePrefix("api/Product/SuperGroup3")]
    public class SuperGroup3Controller : CRUDLApiController<Overtech.DataModels.Product.SuperGroup3, ISuperGroup3Service, Overtech.ViewModels.Product.SuperGroup3>
    {
        /*Section="Constructor"*/
        public SuperGroup3Controller(
            ILoggerFactory loggerFactory,
            ISuperGroup3Service superGroup3Service)
            : base(loggerFactory, superGroup3Service)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}