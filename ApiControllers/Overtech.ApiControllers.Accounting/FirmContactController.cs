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

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Accounting
{
    [RoutePrefix("api/Accounting/FirmContact")]
    public class FirmContactController : OTRelationApiController<Overtech.DataModels.Accounting.FirmContact, IFirmContactService, Overtech.ViewModels.Accounting.FirmContact>
    {
        /*Section="Constructor"*/
        public FirmContactController(
            ILoggerFactory loggerFactory,
            IFirmContactService firmContactService)
            : base(loggerFactory, firmContactService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpGet]
        [Route("ListAllContactByFirmId")]
        [OTControllerAction("List")]
        public IEnumerable<FirmContact> ListAllContactByFirmId(int firmId)
        {
            return _dataService.ListAllContactByFirmId(firmId).Map<DataModels.Accounting.FirmContact, FirmContact>();
        }

        public override FirmContact AddLeft([FromBody] FirmContact viewModel)
        {
            try
            {
                IMapperConfig mapperConfig = MapperConfig.Init().CreateMap<Overtech.DataModels.Accounting.FirmContact, Overtech.ViewModels.Accounting.FirmContact>()
                                                              .CreateMap<Overtech.DataModels.Contact.Contact, Overtech.ViewModels.Contact.Contact>()
                                                              .CreateMap<Overtech.DataModels.Contact.Address, Overtech.ViewModels.Contact.Address>()
                                                              .CreateMap<Overtech.DataModels.Contact.Web, Overtech.ViewModels.Contact.Web>()
                                                              .CreateMap<Overtech.DataModels.Contact.Phone, Overtech.ViewModels.Contact.Phone>();

                DataModels.Accounting.FirmContact dataModel = viewModel.Map<DataModels.Accounting.FirmContact, FirmContact>(mapperConfig);
                dataModel = _dataService.Create(dataModel);
                FirmContact createdModel = dataModel.Map<DataModels.Accounting.FirmContact, FirmContact>(mapperConfig);

                return createdModel;
            }
            catch (Exception ex)
            {
                throw CreateUserException(ex, MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}