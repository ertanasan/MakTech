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
    public interface IEInvoiceClientService : ICRUDLServiceContract<Overtech.DataModels.Accounting.EInvoiceClient>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        EInvoiceClient readEInvoice(long IdNo);

        [OperationContract]
        IdentityInfo ReadIdentityNo(string IdentityNo);

        
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

