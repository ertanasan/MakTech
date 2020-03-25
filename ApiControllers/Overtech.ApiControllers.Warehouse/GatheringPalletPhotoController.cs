// Created by OverGenerator
/*Section="Usings"*/
using System;
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
    [RoutePrefix("api/Warehouse/GatheringPalletPhoto")]
    public class GatheringPalletPhotoController : CRUDLApiController<Overtech.DataModels.Warehouse.GatheringPalletPhoto, IGatheringPalletPhotoService, Overtech.ViewModels.Warehouse.GatheringPalletPhoto>
    {
        /*Section="Constructor"*/
        public GatheringPalletPhotoController(
            ILoggerFactory loggerFactory,
            IGatheringPalletPhotoService gatheringPalletPhotoService)
            : base(loggerFactory, gatheringPalletPhotoService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpPost]
        [Route("UploadPalletPhoto")]
        [OTControllerAction("Create")]
        public bool UploadPalletPhoto(Overtech.ViewModels.Warehouse.GatheringPalletPhoto palletPhoto)
        {
            try
            {
                return _dataService.UploadPalletPhoto(palletPhoto.Map<Overtech.DataModels.Warehouse.GatheringPalletPhoto, Overtech.ViewModels.Warehouse.GatheringPalletPhoto>());
            }
            catch (Exception ex)
            {
                string photoContentExists = palletPhoto.PhotoContent.Length > 0 ? "PhotoContent Exists" : "PhotoContent Null";
                _logger.Error($"UploadPalletPhoto failed ({ photoContentExists }).  Exception Message=", ex);
                return false;
            }
        }

        [HttpDelete]
        [Route("DeletePalletPhoto")]
        [OTControllerAction("Update")]
        public bool DeletePalletPhoto(long gatheringPalletPhotoId)
        {
            try
            {
                return _dataService.DeletePalletPhoto(gatheringPalletPhotoId);
            }
            catch (Exception ex)
            {
                _logger.Error("DeletePalletPhoto failed.", ex);
                return false;
            }
        }

        [HttpGet]
        [Route("ListPalletPhoto")]
        [OTControllerAction("List")]
        public IEnumerable<Overtech.ViewModels.Warehouse.GatheringPalletPhoto> ListPalletPhoto(long storeOrderId, long? gatheringPalletId)
        {
            return _dataService.ListPalletPhoto(storeOrderId, gatheringPalletId).Map<Overtech.DataModels.Warehouse.GatheringPalletPhoto, Overtech.ViewModels.Warehouse.GatheringPalletPhoto>();
        }

        [HttpGet]
        [Route("GetPhotoByIndex")]
        [OTControllerAction("Read")]
        public Overtech.ViewModels.Warehouse.GatheringPalletPhoto GetPhotoByIndex(long storeOrderId, int photoIndex, long? gatheringPalletId)
        {
            return _dataService.GetPhotoByIndex(storeOrderId, photoIndex, gatheringPalletId).Map<Overtech.DataModels.Warehouse.GatheringPalletPhoto, Overtech.ViewModels.Warehouse.GatheringPalletPhoto>();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}