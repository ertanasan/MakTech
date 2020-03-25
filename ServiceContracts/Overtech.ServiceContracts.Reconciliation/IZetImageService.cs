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
    public interface IZetImageService : ICRUDLServiceContract<Overtech.DataModels.Reconciliation.ZetImage>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        bool UploadZetImage(Overtech.DataModels.Reconciliation.ZetImage zetImage);

        [OperationContract]
        bool DeleteZetImage(long zetImageId, long documentId);

        [OperationContract]
        IEnumerable<Overtech.DataModels.Reconciliation.ZetImage> ListZetImages(long reconciliationId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

