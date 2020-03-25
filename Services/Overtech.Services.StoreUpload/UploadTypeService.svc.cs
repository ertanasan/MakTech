// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.StoreUpload;
using Overtech.ServiceContracts.StoreUpload;

/*Section="ClassHeader"*/
namespace Overtech.Services.StoreUpload
{
    [OTInspectorBehavior]
    public class UploadTypeService : CRUDLDataService<Overtech.DataModels.StoreUpload.UploadType>, IUploadTypeService
    {
        /*Section="Constructor-1"*/
        public UploadTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal UploadTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}