// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Contact;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Contact
{
    [ServiceContract]
    public interface ITownService : ICRUDLServiceContract<Overtech.DataModels.Contact.Town>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Contact.Town Find(string townName);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

