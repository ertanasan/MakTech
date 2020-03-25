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
using Overtech.ViewModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/StorageZones")]
    public class StorageZonesController : CRUDLApiController<Overtech.DataModels.Warehouse.StorageZones, IStorageZonesService, Overtech.ViewModels.Warehouse.StorageZones>
    {
        /*Section="Constructor"*/
        public StorageZonesController(
            ILoggerFactory loggerFactory,
            IStorageZonesService storageZonesService)
            : base(loggerFactory, storageZonesService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpGet]
        [OTControllerAction("List")]
        [Route("List")]
        public IEnumerable<StorageZones> ZoneList(int store)
        {
            return _dataService.ZoneList(store).Map<Overtech.DataModels.Warehouse.StorageZones, StorageZones>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}