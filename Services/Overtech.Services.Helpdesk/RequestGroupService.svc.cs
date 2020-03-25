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
    public class RequestGroupService : CRUDLDataService<Overtech.DataModels.Helpdesk.RequestGroup>, IRequestGroupService
    {
        /*Section="Constructor-1"*/
        public RequestGroupService()
        {
        }

        /*Section="Constructor-2"*/
        internal RequestGroupService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListRequestDefinitions"*/
        public IEnumerable<RequestDefinition> ListRequestDefinitions(long requestGroupId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmRequestGroup = dal.CreateParameter("RequestGroup", requestGroupId);
                return dal.List<RequestDefinition>("HDK_LST_REQUESTDEF_SP", prmRequestGroup).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}