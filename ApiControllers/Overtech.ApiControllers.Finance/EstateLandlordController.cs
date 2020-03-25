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
using Overtech.ServiceContracts.Finance;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Finance
{
    [RoutePrefix("api/Finance/EstateLandlord")]
    public class EstateLandlordController : OTRelationApiController<Overtech.DataModels.Finance.EstateLandlord, IEstateLandlordService, Overtech.ViewModels.Finance.EstateLandlord>
    {
        /*Section="Constructor"*/
        public EstateLandlordController(
            ILoggerFactory loggerFactory,
            IEstateLandlordService estateLandlordService)
            : base(loggerFactory, estateLandlordService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpPost]
        [OTControllerAction("Update")]
        [Route("SendNegotiationReminderNotification")]
        public void SendNegotiationReminderNotification(long estateRentPeriodId) 
        {
            _dataService.SendNegotiationReminderNotification(estateRentPeriodId);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}