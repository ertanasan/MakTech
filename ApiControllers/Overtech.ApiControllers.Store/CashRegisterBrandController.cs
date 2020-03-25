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
    [RoutePrefix("api/Store/CashRegisterBrand")]
    public class CashRegisterBrandController : CRUDLApiController<Overtech.DataModels.Store.CashRegisterBrand, ICashRegisterBrandService, Overtech.ViewModels.Store.CashRegisterBrand>
    {
        /*Section="Constructor"*/
        public CashRegisterBrandController(
            ILoggerFactory loggerFactory,
            ICashRegisterBrandService cashRegisterBrandService)
            : base(loggerFactory, cashRegisterBrandService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}