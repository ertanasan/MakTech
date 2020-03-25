// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Store;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Store
{
    [ServiceContract]
    public interface IWorkingHoursService : ICRUDLServiceContract<Overtech.DataModels.Store.WorkingHours>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        string LoadWorkingHoursFile(byte[] formData);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

