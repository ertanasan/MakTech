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
using Overtech.ServiceContracts.Finance;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Finance
{
    [RoutePrefix("api/Finance/ContractParameter")]
    public class ContractParameterController : CRUDLApiController<Overtech.DataModels.Finance.ContractParameter, IContractParameterService, Overtech.ViewModels.Finance.ContractParameter>
    {
        /*Section="Constructor"*/
        public ContractParameterController(
            ILoggerFactory loggerFactory,
            IContractParameterService contractParameterService)
            : base(loggerFactory, contractParameterService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}