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
using Overtech.Core;
using System.Reflection;
using System;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/TransferProductDetail")]
    public class TransferProductDetailController : CRUDLApiController<Overtech.DataModels.Warehouse.TransferProductDetail, ITransferProductDetailService, Overtech.ViewModels.Warehouse.TransferProductDetail>
    {
        /*Section="Constructor"*/
        public TransferProductDetailController(
            ILoggerFactory loggerFactory,
            ITransferProductDetailService transferProductDetailService)
            : base(loggerFactory, transferProductDetailService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpPut]
        [Route("CreateAll")]
        [OTControllerAction("Create")]
        public IEnumerable<Overtech.ViewModels.Warehouse.TransferProductDetail> CreateAll(IEnumerable<Overtech.ViewModels.Warehouse.TransferProductDetail> transferDetails)
        {

            try
            {
                IEnumerable<Overtech.DataModels.Warehouse.TransferProductDetail> dataModel = transferDetails.Map<Overtech.DataModels.Warehouse.TransferProductDetail, Overtech.ViewModels.Warehouse.TransferProductDetail>();
                dataModel = _dataService.CreateAll(dataModel);
                IEnumerable<Overtech.ViewModels.Warehouse.TransferProductDetail> createdModel = dataModel.Map<Overtech.DataModels.Warehouse.TransferProductDetail, Overtech.ViewModels.Warehouse.TransferProductDetail>();

                return createdModel;
            }
            catch (Exception ex)
            {
                _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                throw CreateUserException(ex);
            }
        }

    

        [HttpPut]
        [Route("UpdateAll")]
        [OTControllerAction("Update")]
        public void UpdateAll(IEnumerable<Overtech.ViewModels.Warehouse.TransferProductDetail> transferDetails)
        {
            try
            {
                _dataService.UpdateAll(transferDetails.Map<Overtech.DataModels.Warehouse.TransferProductDetail, Overtech.ViewModels.Warehouse.TransferProductDetail>());
            }
            catch (Exception ex)
            {
                _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                throw CreateUserException(ex);
            }
        }
        [HttpPut]
        [Route("DeleteAll")]
        [OTControllerAction("Update")]
        public void DeleteAll(IEnumerable<long> transferDetailIds)
        {
            try
            {
                _dataService.DeleteAll(transferDetailIds);
            }
            catch (Exception ex)
            {
                _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                throw CreateUserException(ex);
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }

}