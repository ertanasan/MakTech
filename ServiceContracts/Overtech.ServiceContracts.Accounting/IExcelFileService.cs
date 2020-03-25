// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Accounting
{
    [ServiceContract]
    public interface IExcelFileService : ICRUDLServiceContract<Overtech.DataModels.Accounting.ExcelFile>
    {

        /*Section="Method-ListExcelFileColumnss"*/
        [OperationContract]
        IEnumerable<ExcelFileColumns> ListExcelFileColumnss(long excelFileId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

