// Created by OverGenerator
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
    public interface IRequestAttributeService : ICRUDLServiceContract<Overtech.DataModels.Helpdesk.RequestAttribute>
    {

        /*Section="Method-ListAttributeChoices"*/
        [OperationContract]
        IEnumerable<AttributeChoice> ListAttributeChoices(long requestAttributeId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

