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
    public class AssignUserService : CRUDLDataService<Overtech.DataModels.Helpdesk.AssignUser>, IAssignUserService
    {
        /*Section="Constructor-1"*/
        public AssignUserService()
        {
        }

        /*Section="Constructor-2"*/
        internal AssignUserService(IDAL dal)
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