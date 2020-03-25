// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Data;

using Overtech.Core.Contract;
using Overtech.DataModels.Price;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Price
{
    [ServiceContract]
    public interface IPriceLabelPrintService : ICRUDLServiceContract<Overtech.DataModels.Price.PriceLabelPrint>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        void InsertPrintedLabels(IEnumerable<Overtech.DataModels.Price.PriceLabelPrint> printedLabels);

        [OperationContract]
        DataTable ListPrintedLabels();

        [OperationContract]
        DataTable ListPrintedLabelDetailsByStore(long storeId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

