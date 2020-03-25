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
    public interface ISuperGroup1Service : ICRUDLServiceContract<Overtech.DataModels.Product.SuperGroup1>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.SuperGroup1 Find(string superGroup1Name);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

