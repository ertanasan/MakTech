// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Reconciliation;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Reconciliation
{
    [ServiceContract]
    public interface IExpenseService : ICRUDLServiceContract<Overtech.DataModels.Reconciliation.Expense>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized

        [OperationContract]
        IEnumerable<Expense> OpenExpenses(long storeId, DateTime date);

        [OperationContract]
        IEnumerable<Expense> PaidExpenses(long storeId, DateTime date);

        [OperationContract]
        IEnumerable<Expense> ReadDate(DateTime startDate, DateTime endDate);

        [OperationContract]
        DataTable ExpenseReport(DateTime startDate, DateTime endDate, string storeList, string expenseTypeList, string managerList);

        [OperationContract]
        DataTable ExpenseReportDetail(DateTime startDate, DateTime endDate, string storeList, string expenseTypeList, string managerList);

        [OperationContract]
        DataTable ExpenseReportChart(string storeList, string expenseTypeList, string managerList);

        [OperationContract]
        IEnumerable<Expense> MikroTransferList(long regionManagerId);

        [OperationContract]
        long MikroTransfer(long regionManagerId, string expenseList);

        [OperationContract]
        DataTable ListExpenseLog(long expenseId);

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

