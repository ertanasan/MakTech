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
    public class RequestDefinitionService : CRUDLDataService<Overtech.DataModels.Helpdesk.RequestDefinition>, IRequestDefinitionService
    {
        /*Section="Constructor-1"*/
        public RequestDefinitionService()
        {
        }

        /*Section="Constructor-2"*/
        internal RequestDefinitionService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}