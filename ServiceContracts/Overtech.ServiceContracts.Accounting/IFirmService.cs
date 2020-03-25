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
    public interface IFirmService : ICRUDLServiceContract<Overtech.DataModels.Accounting.Firm>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Accounting.Firm Find(string name);
        /*Section="Method-CreateFirmContact"*/
        [OperationContract]
        void CreateFirmContact(FirmContact firmContact);

        /*Section="Method-ReadFirmContact"*/
        [OperationContract]
        FirmContact ReadFirmContact(long firm, long contact);

        /*Section="Method-UpdateFirmContact"*/
        [OperationContract]
        void UpdateFirmContact(FirmContact firmContact);

        /*Section="Method-DeleteFirmContact"*/
        [OperationContract]
        void DeleteFirmContact(long firm, long contact);

        /*Section="Method-ListFirmContacts"*/
        [OperationContract]
        IEnumerable<FirmContact> ListFirmContacts(long firmId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

