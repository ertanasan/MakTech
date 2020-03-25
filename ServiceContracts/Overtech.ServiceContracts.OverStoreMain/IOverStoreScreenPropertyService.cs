// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.OverStoreMain;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.OverStoreMain
{
    [ServiceContract]
    public interface IOverStoreScreenPropertyService : ICRUDLServiceContract<Overtech.DataModels.OverStoreMain.OverStoreScreenProperty>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        IEnumerable<OverStoreScreenProperty> ListScreenProperties(int screenId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

