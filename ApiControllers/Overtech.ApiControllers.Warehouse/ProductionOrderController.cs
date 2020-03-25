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
using Overtech.ServiceContracts.Parameter;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Warehouse;
using System;
using Overtech.Core;
using System.Reflection;
using Overtech.ViewModels.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/ProductionOrder")]
    public class ProductionOrderController : CRUDLApiController<Overtech.DataModels.Warehouse.ProductionOrder, IProductionOrderService, Overtech.ViewModels.Warehouse.ProductionOrder>
    {
        ISystemParameterService _parameterService;
        
        /*Section="Constructor"*/
        public ProductionOrderController(
            ILoggerFactory loggerFactory,
            IProductionOrderService productionOrderService,
            ISystemParameterService paramaterService)
            : base(loggerFactory, productionOrderService)
        {
            _parameterService = paramaterService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized

        public override ProductionOrder Create([FromBody] ProductionOrder viewModel)
        {
            if (ModelState.IsValid)
            {
                return base.Create(viewModel);
            } else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw CreateUserException(new OTException(OTErrors.ModelStateInvalid, true, null, errors));
            }

        }

        IMapperConfig mapperConfig = MapperConfig.Init().CreateMap<Overtech.DataModels.Warehouse.ProductionOrder, Overtech.ViewModels.Warehouse.ProductionOrder>()
                                        .CreateMap<Overtech.DataModels.Warehouse.ProductionContent, Overtech.ViewModels.Warehouse.ProductionContent>();
        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Warehouse.ProductionOrder viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Warehouse.ProductionOrder, ViewModels.Warehouse.ProductionOrder>();
                    DataModels.Warehouse.ProductionOrder dataModel = viewModel.Map<DataModels.Warehouse.ProductionOrder, ViewModels.Warehouse.ProductionOrder>(mapperConfig);

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

        [HttpGet]
        [Route("GetTolerancePct")]
        [OTControllerAction("Read")]
        public double GetTolerancePct()
        {
            return double.Parse(_parameterService.GetParameterValue("ProductionTolerancePercentage")) / 100;
        }
            #endregion Customized

            /*Section="ClassFooter"*/
        }
}