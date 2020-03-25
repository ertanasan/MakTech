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
    public interface IPayrollService : ICRUDLServiceContract<Overtech.DataModels.Accounting.Payroll>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        void LoadHRFile(byte[] formData);

        [OperationContract]
        IEnumerable<Payroll> ListMonth(int year, int month);

        [OperationContract]
        void MikroTransfer(int year, int month);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

