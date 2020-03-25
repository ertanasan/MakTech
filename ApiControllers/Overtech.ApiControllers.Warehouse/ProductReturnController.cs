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
using System.Web.Http.ModelBinding;
using System;
using System.Reflection;
using Overtech.Core;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/ProductReturn")]
    public class ProductReturnController : CRUDLApiController<Overtech.DataModels.Warehouse.ProductReturn, IProductReturnService, Overtech.ViewModels.Warehouse.ProductReturn>
    {
        /*Section="Constructor"*/
        public ProductReturnController(
            ILoggerFactory loggerFactory,
            IProductReturnService productReturnService)
            : base(loggerFactory, productReturnService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        IMapperConfig mapperConfig = MapperConfig.Init().CreateMap<Overtech.DataModels.Warehouse.ProductReturn, Overtech.ViewModels.Warehouse.ProductReturn>()
                                            .CreateMap<Overtech.DataModels.Warehouse.ProductReturnReason, Overtech.ViewModels.Warehouse.ProductReturnReason>();

        [HttpGet]
        [OTControllerAction("List")]
        [Route("ListStatus")]
        public IEnumerable<Overtech.ViewModels.Warehouse.ProductReturn> ListStatus(int statusCode)
        {
            return _dataService.ListStatus(statusCode).Map<DataModels.Warehouse.ProductReturn, ViewModels.Warehouse.ProductReturn>(mapperConfig);
        }

        [HttpPost]
        [OTControllerAction("Update")]
        [Route("ApproveProductReturn")]
        public void ApproveProductReturn(ViewModels.Warehouse.ProductReturn rec)
        {
            DataModels.Warehouse.ProductReturn dmrec = rec.Map<DataModels.Warehouse.ProductReturn, ViewModels.Warehouse.ProductReturn>(mapperConfig);
            _dataService.ApproveProductReturn(dmrec);
        }

        [HttpPost]
        [OTControllerAction("Update")]
        [Route("SaveProductReturn")]
        public long SaveProductReturn(ViewModels.Warehouse.ProductReturn rec)
        {
            DataModels.Warehouse.ProductReturn dmrec = rec.Map<DataModels.Warehouse.ProductReturn, ViewModels.Warehouse.ProductReturn>(mapperConfig);
            return _dataService.SaveProductReturn(dmrec);
        }

        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Warehouse.ProductReturn viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Warehouse.ProductReturn, ViewModels.Warehouse.ProductReturn>();
                    DataModels.Warehouse.ProductReturn dataModel = viewModel.Map<DataModels.Warehouse.ProductReturn, ViewModels.Warehouse.ProductReturn>(mapperConfig);

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
        [OTControllerAction("List")]
        [Route("ListHistoryData")]
        public IEnumerable<Overtech.ViewModels.Warehouse.ProductReturnHistory> ListHistoryData(long productReturnId)
        {
            return _dataService.ListHistoryData(productReturnId).Map<DataModels.Warehouse.ProductReturnHistory, ViewModels.Warehouse.ProductReturnHistory>(mapperConfig);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}