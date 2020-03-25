// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.StoreUpload;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.StoreUpload
{
    [ServiceContract]
    public interface IUploadTypeService : ICRUDLServiceContract<Overtech.DataModels.StoreUpload.UploadType>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

