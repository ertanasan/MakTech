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
    public interface IFirmContactService : ICRUDRServiceContract<Overtech.DataModels.Accounting.FirmContact>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        IEnumerable<DataModels.Accounting.FirmContact> ListAllContactByFirmId(int firmId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

