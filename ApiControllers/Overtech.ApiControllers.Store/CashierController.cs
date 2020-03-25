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
using Overtech.ServiceContracts.Store;
using Overtech.ViewModels.Store;
using Overtech.Core;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/Cashier")]
    public class CashierController : CRUDLApiController<Overtech.DataModels.Store.Cashier, ICashierService, Overtech.ViewModels.Store.Cashier>
    {
        /*Section="Constructor"*/
        public CashierController(
            ILoggerFactory loggerFactory,
            ICashierService cashierService)
            : base(loggerFactory, cashierService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public override Cashier Create([FromBody] Cashier viewModel)
        {
            if (ModelState.IsValid)
            {
                return base.Create(viewModel);
            } else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw CreateUserException(new OTException(OTErrors.ModelStateInvalid, true, null, errors));
            }
            //return base.Create(viewModel);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}