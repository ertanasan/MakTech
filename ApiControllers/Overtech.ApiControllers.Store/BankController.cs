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

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/Bank")]
    public class BankController : CRUDLApiController<Overtech.DataModels.Store.Bank, IBankService, Overtech.ViewModels.Store.Bank>
    {
        /*Section="Constructor"*/
        public BankController(
            ILoggerFactory loggerFactory,
            IBankService bankService)
            : base(loggerFactory, bankService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}