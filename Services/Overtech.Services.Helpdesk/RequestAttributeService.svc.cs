// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Helpdesk;
using Overtech.ServiceContracts.Helpdesk;

/*Section="ClassHeader"*/
namespace Overtech.Services.Helpdesk
{
    [OTInspectorBehavior]
    public class RequestAttributeService : CRUDLDataService<Overtech.DataModels.Helpdesk.RequestAttribute>, IRequestAttributeService
    {
        /*Section="Constructor-1"*/
        public RequestAttributeService()
        {
        }

        /*Section="Constructor-2"*/
        internal RequestAttributeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListAttributeChoices"*/
        public IEnumerable<AttributeChoice> ListAttributeChoices(long requestAttributeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmAttribute = dal.CreateParameter("Attribute", requestAttributeId);
                return dal.List<AttributeChoice>("HDK_LST_ATTRIBUTECHOICE_SP", prmAttribute).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}