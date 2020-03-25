﻿// Created by OverGenerator
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
    public interface IStorageConditionService : ICRUDLServiceContract<Overtech.DataModels.Product.StorageCondition>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.StorageCondition Find(string condition);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

