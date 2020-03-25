using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Data;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Store;
using Overtech.Core.Data;

namespace Overtech.ApiControllers.Store
{
    [RoutePrefix("api/Store/OverstoreShared")]
    public class OverstoreSharedController : CRUDLApiController<Overtech.DataModels.Store.BPMHistory, IOverstoreSharedService, Overtech.ViewModels.Store.BPMHistory>
    {
        public OverstoreSharedController(
            ILoggerFactory loggerFactory,
            IOverstoreSharedService sharedService)
            : base(loggerFactory, sharedService)
        {
        }

        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListBPMHistoryData")]
        public IEnumerable<Overtech.ViewModels.Store.BPMHistory> ListBPMHistoryData(long processInstanceId)
        {
            return _dataService.ListBPMHistoryData(processInstanceId).Map<DataModels.Store.BPMHistory, ViewModels.Store.BPMHistory>();
        }
    }
}


