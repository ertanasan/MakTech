﻿// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Helpdesk;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Helpdesk
{
    [ServiceContract]
    public interface IRequestGroupService : ICRUDLServiceContract<Overtech.DataModels.Helpdesk.RequestGroup>
    {

        /*Section="Method-ListRequestDefinitions"*/
        [OperationContract]
        IEnumerable<RequestDefinition> ListRequestDefinitions(long requestGroupId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

