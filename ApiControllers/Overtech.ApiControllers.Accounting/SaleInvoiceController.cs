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
using Overtech.ServiceContracts.Accounting;
using Overtech.ViewModels.Accounting;
using System;
using System.Reflection;
using Overtech.Core;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Accounting
{
    [RoutePrefix("api/Accounting/SaleInvoice")]
    public class SaleInvoiceController : CRUDLApiController<Overtech.DataModels.Accounting.SaleInvoice, ISaleInvoiceService, Overtech.ViewModels.Accounting.SaleInvoice>
    {
        /*Section="Constructor"*/

        
        public SaleInvoiceController(
            ILoggerFactory loggerFactory,
            ISaleInvoiceService saleInvoiceService)
            : base(loggerFactory, saleInvoiceService)
        {
            
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public override SaleInvoice Create([FromBody] SaleInvoice viewModel)
        {
            return base.Create(viewModel);
        }

        [HttpPost]
        [OTControllerAction("Update")]
        [Route("SendEInvoice")]
        public void ApproveProductReturn(ViewModels.Accounting.SaleInvoice rec)
        {
            DataModels.Accounting.SaleInvoice dmrec = rec.Map<DataModels.Accounting.SaleInvoice, ViewModels.Accounting.SaleInvoice>();
            _dataService.SendEInvoice(dmrec);
        }

        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.Accounting.SaleInvoice viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.Accounting.SaleInvoice, ViewModels.Accounting.SaleInvoice>();
                    DataModels.Accounting.SaleInvoice dataModel = viewModel.Map<DataModels.Accounting.SaleInvoice, ViewModels.Accounting.SaleInvoice>();

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
        [Route("CheckIfTaxIdentifierExists")]
        [OTControllerAction("Read")]
        public bool CheckIfTaxIdentifierExists(string vkn)
        {
            return _dataService.checkIfTaxIdentifierExists(vkn);
        }

        [HttpGet]
        [Route("StoreEInvoice")]
        [OTControllerAction("Read")]
        public decimal StoreEInvoice(int storeId, DateTime invoiceDate)
        {
            return _dataService.StoreEInvoice(storeId, invoiceDate);
        }

        [HttpPost]
        [Route("CreateCurrentAccount")]
        [OTControllerAction("Create")]
        public void CreateCurrentAccount(IdentityInfo identityInfo)
        {
            _dataService.CreateCurrentAccount(identityInfo.Map<Overtech.DataModels.Accounting.IdentityInfo, IdentityInfo>());
        }


        #endregion Customized

        /*Section="ClassFooter"*/
    }
}