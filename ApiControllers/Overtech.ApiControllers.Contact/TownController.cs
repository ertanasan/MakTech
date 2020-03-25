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
using Overtech.ServiceContracts.Contact;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Contact
{
    [RoutePrefix("api/Contact/Town")]
    public class TownController : CRUDLApiController<Overtech.DataModels.Contact.Town, ITownService, Overtech.ViewModels.Contact.Town>
    {
        /*Section="Constructor"*/
        public TownController(
            ILoggerFactory loggerFactory,
            ITownService townService)
            : base(loggerFactory, townService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}