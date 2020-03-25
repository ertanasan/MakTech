// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Reconciliation;
using Overtech.ServiceContracts.Reconciliation;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Reconciliation
{
    [OTInspectorBehavior]
    public class ExpenseService : CRUDLDataService<Overtech.DataModels.Reconciliation.Expense>, IExpenseService
    {
        /*Section="Constructor-1"*/
        public ExpenseService()
        {
        }

        /*Section="Constructor-2"*/
        internal ExpenseService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<Expense> OpenExpenses(long storeId, DateTime date)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmDate = dal.CreateParameter("Date", date);
                return dal.List<Expense>("RCL_LST_OPENEXPENSES_SP", prmStoreId, prmDate).ToList();
            }
        }

        public IEnumerable<Expense> PaidExpenses(long storeId, DateTime date)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                IUniParameter prmDate = dal.CreateParameter("Date", date);
                return dal.List<Expense>("RCL_LST_PAIDEXPENSES_SP", prmStoreId, prmDate).ToList();
            }
        }

        public IEnumerable<Expense> MikroTransferList(long regionManagerId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmRMId = dal.CreateParameter("RegionManagerId", regionManagerId);
                return dal.List<Expense>("RCL_LST_EXPENSETRANSFER_SP", prmRMId).ToList();
            }
        }

        public void InsertException(string messageText, string parametersText)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    IUniParameter prmLogId = dal.CreateParameter("ExceptionLogId", 4, ParameterDirection.Output, 0);
                    IUniParameter prmEvent = dal.CreateParameter("Event", 1);
                    IUniParameter prmOrganization = dal.CreateParameter("Organization", 1);
                    IUniParameter prmExceptionMessage = dal.CreateParameter("ExceptionMessage", messageText);
                    IUniParameter prmParameters = dal.CreateParameter("Parameters", parametersText);
                    dal.ExecuteNonQuery("RCL_INS_EXCEPTION_SP", prmLogId, prmEvent, prmOrganization, prmExceptionMessage, prmParameters);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public long MikroTransfer(long regionManagerId, string expenseList)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmRMId = dal.CreateParameter("RegionManagerId", regionManagerId);
                    IUniParameter prmExpenseList = dal.CreateParameter("ExpenseIdList", expenseList);
                    IUniParameter prmTranNo = dal.CreateParameter("TranNo", 4, ParameterDirection.Output, 0);
                    dal.ExecuteNonQuery("MIK_INS_EXPENSE_SP", prmRMId, prmExpenseList, prmTranNo);
                    dal.CommitTransaction();
                    return prmTranNo.Value.To<long>();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    InsertException(ex.ToString(), $"{regionManagerId.ToString()};{expenseList}");
                    throw ex;
                }
                
            }
        }

        public IEnumerable<Expense> ReadDate(DateTime startDate, DateTime endDate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                return dal.List<Expense>("RCL_LST_EXPENSE_SP", prmStartDate, prmEndDate).ToList();
            }
        }

        public DataTable ExpenseReport(DateTime startDate, DateTime endDate, string storeList, string expenseTypeList, string managerList)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmStoreList = dal.CreateParameter("StoreList", storeList);
                IUniParameter prmExpenseTypeList = dal.CreateParameter("ExpenseTypeList", expenseTypeList);
                IUniParameter prmManagerList = dal.CreateParameter("ManagerList", managerList);
                return dal.ExecuteDataset("RCL_LST_EXPENSEREPORT_SP", prmStartDate, prmEndDate, prmStoreList, prmExpenseTypeList, prmManagerList).Tables[0];
            }
        }


        public DataTable ExpenseReportDetail(DateTime startDate, DateTime endDate, string storeList, string expenseTypeList, string managerList)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStartDate = dal.CreateParameter("StartDate", startDate);
                IUniParameter prmEndDate = dal.CreateParameter("EndDate", endDate);
                IUniParameter prmStoreList = dal.CreateParameter("StoreList", storeList);
                IUniParameter prmExpenseTypeList = dal.CreateParameter("ExpenseTypeList", expenseTypeList);
                IUniParameter prmManagerList = dal.CreateParameter("ManagerList", managerList);
                return dal.ExecuteDataset("RCL_LST_EXPENSEREPORTDETAIL_SP", prmStartDate, prmEndDate, prmStoreList, prmExpenseTypeList, prmManagerList).Tables[0];
            }
        }

        public DataTable ExpenseReportChart(string storeList, string expenseTypeList, string managerList)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreList = dal.CreateParameter("StoreList", storeList);
                IUniParameter prmExpenseTypeList = dal.CreateParameter("ExpenseTypeList", expenseTypeList);
                IUniParameter prmManagerList = dal.CreateParameter("ManagerList", managerList);
                return dal.ExecuteDataset("RCL_LST_EXPENSECHART_SP", prmStoreList, prmExpenseTypeList, prmManagerList).Tables[0];
            }
        }

        public DataTable ListExpenseLog(long expenseId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmExpenseId = dal.CreateParameter("ExpenseId", expenseId);
                return dal.ExecuteDataset("RCL_LST_EXPENSELOG_SP", prmExpenseId).Tables[0];
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}