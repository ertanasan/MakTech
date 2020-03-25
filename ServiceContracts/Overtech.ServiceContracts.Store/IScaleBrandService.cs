// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Store;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Store
{
    [ServiceContract]
    public interface IScaleBrandService : ICRUDLServiceContract<Overtech.DataModels.Store.ScaleBrand>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Store.ScaleBrand Find(string name);

        /*Section="Method-ListScaleModels"*/
        [OperationContract]
        IEnumerable<ScaleModel> ListScaleModels(long scaleBrandId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

