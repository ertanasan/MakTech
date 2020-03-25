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
    public interface IAccountingDepartmentService : ICRUDLServiceContract<Overtech.DataModels.Accounting.AccountingDepartment>
    {
        /*Section="Method-Find"*/
        [OperationContract]
        Overtech.DataModels.Accounting.AccountingDepartment Find(string departmentName);

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

