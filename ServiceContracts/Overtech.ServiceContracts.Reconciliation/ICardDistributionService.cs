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
    public interface ICardDistributionService : ICRUDLServiceContract<Overtech.DataModels.Reconciliation.CardDistribution>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

