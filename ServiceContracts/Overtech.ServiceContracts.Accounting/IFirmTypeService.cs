// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Accounting
{
    [ServiceContract]
    public interface IFirmTypeService : ICRUDLServiceContract<Overtech.DataModels.Accounting.FirmType>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Accounting.FirmType Find(string name);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

