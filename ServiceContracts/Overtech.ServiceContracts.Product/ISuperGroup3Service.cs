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
    public interface ISuperGroup3Service : ICRUDLServiceContract<Overtech.DataModels.Product.SuperGroup3>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Product.SuperGroup3 Find(string superGroup3Name);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

