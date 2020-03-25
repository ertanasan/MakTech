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
    [RoutePrefix("api/Finance/Landlord")]
    public class LandlordController : CRUDLApiController<Overtech.DataModels.Finance.Landlord, ILandlordService, Overtech.ViewModels.Finance.Landlord>
    {
        /*Section="Constructor"*/
        public LandlordController(
            ILoggerFactory loggerFactory,
            ILandlordService landlordService)
            : base(loggerFactory, landlordService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpGet]
        [OTControllerAction("Update")]
        public IEnumerable<ViewModels.Finance.LandlordMikro> ListAllLandlordsFromMikro()
        {
            return _dataService.ListAllLandlordsFromMikro().Map<DataModels.Finance.LandlordMikro, ViewModels.Finance.LandlordMikro>();
        }

        public override ViewModels.Finance.Landlord Create([FromBody] ViewModels.Finance.Landlord viewModel)
        {
            if(ModelState.IsValid)
            {
                return base.Create(viewModel);
            }
            else
            {
                return base.Create(viewModel);
            }
            
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}