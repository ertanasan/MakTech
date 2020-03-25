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
    [RoutePrefix("api/Sale/TransactionType")]
    public class TransactionTypeController : CRUDLApiController<Overtech.DataModels.Sale.TransactionType, ITransactionTypeService, Overtech.ViewModels.Sale.TransactionType>
    {
        /*Section="Constructor"*/
        public TransactionTypeController(
            ILoggerFactory loggerFactory,
            ITransactionTypeService transactionTypeService)
            : base(loggerFactory, transactionTypeService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}