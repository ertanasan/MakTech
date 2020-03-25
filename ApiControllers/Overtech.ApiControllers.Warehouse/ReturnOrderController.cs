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
using System;
using System.Reflection;
using Overtech.Core;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/ReturnOrder")]
    public class ReturnOrderController : CRUDLApiController<Overtech.DataModels.Warehouse.ReturnOrder, IReturnOrderService, Overtech.ViewModels.Warehouse.ReturnOrder>
    {
        /*Section="Constructor"*/
        public ReturnOrderController(
            ILoggerFactory loggerFactory,
            IReturnOrderService returnOrderService)
            : base(loggerFactory, returnOrderService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Warehouse.ReturnOrder viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Warehouse.ReturnOrder, ViewModels.Warehouse.ReturnOrder>();
                    DataModels.Warehouse.ReturnOrder dataModel = viewModel.Map<DataModels.Warehouse.ReturnOrder, ViewModels.Warehouse.ReturnOrder>(mapperConfig);

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
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}