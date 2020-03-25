// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Sale;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Sale
{
    [ServiceContract]
    public interface IPosTrxTypeService : ICRUDLServiceContract<Overtech.DataModels.Sale.PosTrxType>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Sale.PosTrxType Find(string trxType);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

