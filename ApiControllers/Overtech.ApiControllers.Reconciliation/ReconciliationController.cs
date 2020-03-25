using System.Web.Http;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Reconciliation;
using Overtech.Core.Data;
using Overtech.ViewModels.Reconciliation;
using System;
using System.Collections.Generic;
using Overtech.DataModels.Document;
using Overtech.Core.DataSource;
using System.Data;
using Overtech.UI.DataSource;
using Overtech.Core.Application;

namespace Overtech.ApiControllers.Reconciliation
{
    [RoutePrefix("api/Reconciliation/Reconciliation")]
    public class ReconciliationController : CRUDLApiController<Overtech.DataModels.Reconciliation.Reconciliation, IReconciliationService, Overtech.ViewModels.Reconciliation.Reconciliation>
    {
        private IZetImageService _zetImageService; 

        /*Section="Constructor"*/
        public ReconciliationController(
            ILoggerFactory loggerFactory,
            IReconciliationService reconciliationService,
            IZetImageService zetImageService)
            : base(loggerFactory, reconciliationService)
        {
            _zetImageService = zetImageService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        IMapperConfig mapperConfig = MapperConfig.Init().CreateMap<Overtech.DataModels.Reconciliation.Reconciliation, Overtech.ViewModels.Reconciliation.Reconciliation>()
                                            .CreateMap<Overtech.DataModels.Reconciliation.CashDistribution, Overtech.ViewModels.Reconciliation.CashDistribution>()
                                            .CreateMap<Overtech.DataModels.Reconciliation.CardDistribution, Overtech.ViewModels.Reconciliation.CardDistribution>()
                                            .CreateMap<Overtech.DataModels.Reconciliation.RecLog, Overtech.ViewModels.Reconciliation.RecLog>()
                                            .CreateMap<Overtech.DataModels.Sale.CancelReason, Overtech.ViewModels.Sale.CancelReason>();

        [HttpGet]
        [Route("ReconciliationDate")]
        [OTControllerAction("Read")]
        public Overtech.ViewModels.Reconciliation.Reconciliation ReconciliationDate(long storeId)
        {
            return _dataService.ReconciliationDate(storeId).Map<Overtech.DataModels.Reconciliation.Reconciliation, Overtech.ViewModels.Reconciliation.Reconciliation>();
        }

        [HttpGet]
        [OTControllerAction("Read")]
        [Route("ReadReconciliationDetails")]
        public Overtech.ViewModels.Reconciliation.Reconciliation ReadReconciliationDetails(long storeId)
        {
            return _dataService.ReadDetails(storeId).Map<DataModels.Reconciliation.Reconciliation, ViewModels.Reconciliation.Reconciliation>(mapperConfig);
        }

        [HttpPost]
        [OTControllerAction("Create")]
        [Route("SaveReconciliation")]
        public long SaveReconciliation(ViewModels.Reconciliation.Reconciliation rec)
        {
            DataModels.Reconciliation.Reconciliation dmrec = rec.Map<DataModels.Reconciliation.Reconciliation, ViewModels.Reconciliation.Reconciliation>(mapperConfig);
            return _dataService.SaveReconciliation(dmrec);
        }

        [HttpPut]
        [OTControllerAction("Update")]
        [Route("Recalculate")]
        public void Recalculate(long storeId)
        {
            _dataService.Recalculate(storeId);
        }

        [HttpGet]
        [OTControllerAction("List")]
        [Route("ReconciliationStoreDate")]
        public IEnumerable<Overtech.ViewModels.Reconciliation.Reconciliation> ReconciliationStoreDate(long storeId, DateTime startDate, DateTime endDate)
        {
            return _dataService.ReconciliationStoreDate(storeId, startDate, endDate).Map<DataModels.Reconciliation.Reconciliation, ViewModels.Reconciliation.Reconciliation>();
        }

        [HttpPost]
        [OTControllerAction("Create")]
        [Route("UploadZetImage")]
        public bool UploadZetImage([FromBody] Overtech.ViewModels.Reconciliation.ZetImage zetImage)
        {
            zetImage.Organization = OTApplication.Context.Organization.Id;
            try
            {
                DataModels.Reconciliation.ZetImage dmZetImage = zetImage.Map<DataModels.Reconciliation.ZetImage, ViewModels.Reconciliation.ZetImage>(mapperConfig);
                _zetImageService.UploadZetImage(dmZetImage);
                _logger.Debug($"UploadZetImage: ReconciliationId={ zetImage.Reconciliation }, CashregisterId={ zetImage.CashRegister } completed.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error("UploadZetImage failed.", ex);
                return false;
            }            
        }

        [HttpGet]
        [OTControllerAction("Delete")]
        [Route("DeleteZetImage")]
        public bool DeleteZetImage(long zetImageId, long documentId, long reconciliationId, long cashRegisterId)
        {
            try
            {
                //ZetImage tmpZetImage = _zetImageService.Read(zetImageId).Map<DataModels.Reconciliation.ZetImage, ViewModels.Reconciliation.ZetImage>();
                bool deletedDocumenntFlag = _zetImageService.DeleteZetImage(zetImageId, documentId);
                if(deletedDocumenntFlag)
                {
                    _logger.Debug($"DeleteZetImage: ReconciliationId={ reconciliationId }, CashregisterId={ cashRegisterId } completed.");
                    return true;
                }
                else
                {
                    _logger.Error("DeleteZetImage failed in service.");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                _logger.Error("DeleteZetImage failed.", ex);
                return false;
            }
        }

        //public override void Delete(long id)
        //{
        //    base.Delete(id);
        //}

        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListZetImages")]
        public IEnumerable<Overtech.ViewModels.Reconciliation.ZetImage> ListZetImages(long reconciliationId)
        {
            return _zetImageService.ListZetImages(reconciliationId).Map<Overtech.DataModels.Reconciliation.ZetImage, Overtech.ViewModels.Reconciliation.ZetImage>();
        }

        [HttpGet]
        [Route("NotReconStores")]
        [OTControllerAction("List")]
        public DataSourceResult NotReconStores(DateTime startDate, DateTime endDate)
        {
            DataSourceRequest request = new DataSourceRequest();
            DataSourceResult result;
            DataTable dtReport = null;
            dtReport = _dataService.NotReconStores(startDate, endDate);
            result = dtReport.ToDataSourceResult(request);
            return result;
        }

        [HttpPost]
        [OTControllerAction("Create")]
        [Route("CreateZControlLog")]
        public long CreateZControlLog([FromBody] Overtech.ViewModels.Reconciliation.ZControlLog dataObject)
        {
            try
            {
                DataModels.Reconciliation.ZControlLog rec = new DataModels.Reconciliation.ZControlLog();
                rec.ZControlLogId = dataObject.ZControlLogId;
                rec.Store = dataObject.Store;
                rec.ReconciliationDate = dataObject.ReconciliationDate;
                rec.ZetAmount = dataObject.ZetAmount;
                return _dataService.createZControlLog(rec);
            }
            catch (Exception ex)
            {
                _logger.Error("UploadZetImage failed.", ex);
                return 0;
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}