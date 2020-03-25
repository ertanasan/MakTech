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
using Overtech.ServiceContracts.Reconciliation;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Reconciliation
{
    [RoutePrefix("api/Reconciliation/CardDistribution")]
    public class CardDistributionController : CRUDLApiController<Overtech.DataModels.Reconciliation.CardDistribution, ICardDistributionService, Overtech.ViewModels.Reconciliation.CardDistribution>
    {
        /*Section="Constructor"*/
        public CardDistributionController(
            ILoggerFactory loggerFactory,
            ICardDistributionService cardDistributionService)
            : base(loggerFactory, cardDistributionService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}