// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Reconciliation;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Reconciliation
{
    [ServiceContract]
    public interface IVatGroupService : ICRUDLServiceContract<Overtech.DataModels.Reconciliation.VatGroup>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Reconciliation.VatGroup Find(string vatRate);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

