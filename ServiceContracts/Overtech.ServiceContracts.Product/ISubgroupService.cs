// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Product;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Product
{
    [ServiceContract]
    public interface ISubgroupService : ICRUDLServiceContract<Overtech.DataModels.Product.Subgroup>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.Subgroup Find(string subgroupName);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

