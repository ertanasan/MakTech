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
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/IntakeStatus")]
    public class IntakeStatusController : CRUDLApiController<Overtech.DataModels.Warehouse.IntakeStatus, IIntakeStatusService, Overtech.ViewModels.Warehouse.IntakeStatus>
    {
        /*Section="Constructor"*/
        public IntakeStatusController(
            ILoggerFactory loggerFactory,
            IIntakeStatusService intakeStatusService)
            : base(loggerFactory, intakeStatusService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        [HttpPut]
        [Route("TransferToMikro")]
        [OTControllerAction("Update")]
        public void TransferToMikro(long[] storeOrderDetailIds)
        {
            _dataService.TransferToMikro(storeOrderDetailIds);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}