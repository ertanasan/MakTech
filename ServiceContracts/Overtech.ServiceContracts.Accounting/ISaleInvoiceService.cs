// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Accounting
{
    [ServiceContract]
    public interface ISaleInvoiceService : ICRUDLServiceContract<Overtech.DataModels.Accounting.SaleInvoice>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void SendEInvoice(SaleInvoice rec);

        [OperationContract]
        void TakeAction(DataModels.Accounting.SaleInvoice dataObject, long actionId, string choice, string comment);

        [OperationContract]
        bool checkIfTaxIdentifierExists(string vkn);

        [OperationContract]
        void UpdateStatus(long requestId, int statusId);

        [OperationContract]
        decimal StoreEInvoice(int storeId, DateTime invoiceDate);

        [OperationContract]
        void CreateCurrentAccount(IdentityInfo identityInfo);

        [OperationContract]
        void ProcessCashRegisterEInvoice();
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

