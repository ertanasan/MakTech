// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Reflection;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core;
using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Warehouse;
using Overtech.ViewModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/TransferProduct")]
    public class TransferProductController : CRUDLApiController<Overtech.DataModels.Warehouse.TransferProduct, ITransferProductService, Overtech.ViewModels.Warehouse.TransferProduct>
    {
        /*Section="Constructor"*/
        public TransferProductController(
            ILoggerFactory loggerFactory,
            ITransferProductService transferProductService)
            : base(loggerFactory, transferProductService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
       IMapperConfig mapperConfig = MapperConfig.Init().CreateMap<Overtech.DataModels.Warehouse.TransferProduct, Overtech.ViewModels.Warehouse.TransferProduct>()
                                          .CreateMap<Overtech.DataModels.Warehouse.TransferProductDetail, Overtech.ViewModels.Warehouse.TransferProductDetail>();

        [HttpPost]
        [Route("StartTransferProcess")]
        [OTControllerAction("Create")]
        public void StartTransferProcess([FromBody] ViewModels.Warehouse.TransferProduct viewModel)
        {
            _dataService.TriggerTransferProcess(viewModel.Map<Overtech.DataModels.Warehouse.TransferProduct, Overtech.ViewModels.Warehouse.TransferProduct>());
        }

        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Warehouse.TransferProduct viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Warehouse.TransferProduct, ViewModels.Warehouse.TransferProduct>();
                    DataModels.Warehouse.TransferProduct dataModel = viewModel.Map<DataModels.Warehouse.TransferProduct, ViewModels.Warehouse.TransferProduct>(mapperConfig);

                    _dataService.TakeAction(dataModel, viewModel.action, viewModel.actionChoice, viewModel.actionComment);

                }
                catch (Exception ex)
                {
                    _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                    throw CreateUserException(ex);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw CreateUserException(new OTException(OTErrors.ModelStateInvalid, true, null, errors));
            }
        }

        [HttpPost]
        [Route("Create")]
        public override  ViewModels.Warehouse.TransferProduct Create([FromBody]  ViewModels.Warehouse.TransferProduct viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DataModels.Warehouse.TransferProduct dataModel = viewModel.Map<DataModels.Warehouse.TransferProduct, ViewModels.Warehouse.TransferProduct>(mapperConfig);
                    dataModel = _dataService.Create(dataModel);
                    ViewModels.Warehouse.TransferProduct createdModel = dataModel.Map<DataModels.Warehouse.TransferProduct, ViewModels.Warehouse.TransferProduct>();

                    return createdModel;
                }
                catch (Exception ex)
                {
                    _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                    throw CreateUserException(ex);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw CreateUserException(new OTException(OTErrors.ModelStateInvalid, true, null, errors));
            }
        }

        public override TransferProduct Read(long id)
        {
            var a = base.Read(id);
            return a;
        }


        #endregion Customized

        /*Section="ClassFooter"*/
    }
}