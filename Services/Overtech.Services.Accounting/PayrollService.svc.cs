// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Accounting;
using Overtech.ServiceContracts.Accounting;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.Core.Logger;
using Overtech.Mutual.Accounting;
using Overtech.Core.Application;
using System.Data;
using Overtech.DataModels.Store;
using System.Threading;
using Overtech.Mutual.Store;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class PayrollService : CRUDLDataService<Overtech.DataModels.Accounting.Payroll>, IPayrollService
    {
        /*Section="Constructor-1"*/
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        private ILogger _logger;

        public PayrollService(IParameterReader parameterReader,
            IOTResolver resolver,
            ILoggerFactory loggerFactory)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
            _logger = loggerFactory.GetLogger(typeof(PayrollService));
        }

        /*Section="Constructor-2"*/
        internal PayrollService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        private Payroll readEmployeePayroll (IDAL dal, long employeeId, int year, int month)
        {
            try
            {
                IUniParameter prmEmployeeId = dal.CreateParameter("EmployeeId", employeeId);
                IUniParameter prmYear = dal.CreateParameter("Year", year);
                IUniParameter prmMonth = dal.CreateParameter("Month", month);
                return dal.Read<Payroll>("ACC_SEL_EMPLOYEEPAYROLL_SP", prmEmployeeId, prmYear, prmMonth);
            }
            catch (Exception ex)
            {
                _logger.Error($" ServiceName : PayrollService, MethodName : readEmployeePayroll, EmployeeId : {employeeId} Year : {year} Month : {month} Exception : {ex.ToString()}");
                throw ex;
            }
        }

        public void LoadHRFile(byte[] formData)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("tr-TR");
            
            using (IDAL dal = this.DAL)
            {
                long employeeId = 0;
                DataRow processrow = null;
                try
                {
                    
                    ExcelOperations exOp = new ExcelOperations(dal);
                    long eventId = _parameterReader.ReadEventId("System");
                    long organizationId = OTApplication.Context.Organization.Id;
                    string result = exOp.ReadExceltoDataTable(formData, "Payroll", 1);
                    _logger.Debug($" Excel loaded to data table");
                    DataTable dt = exOp.ExcelTable;

                    

                    if (result.Length == 0 && dt.Rows.Count > 0) // if no error and there are records in excel
                    {
                        // Get All Departments
                        IEnumerable <AccountingDepartment> departments = dal.List<AccountingDepartment>().ToList();
                        // process all rows to Maktech DB
                        foreach (DataRow dr in dt.Rows)
                        {

                            processrow = dr;
                            if (dr["SICILNO"] != DBNull.Value)
                            {
                                dal.BeginTransaction();
                                StoreOperations sop = new StoreOperations(dal);

                                // check if employee exists, if not exists create it or update
                                employeeId = long.Parse(dr["SICILNO"].ToString());
                                Employee e = dal.Read<Employee>(employeeId);

                                // find department code
                                string departmentName = dr["DEPARTMENT_NM"].ToString();
                                AccountingDepartment d = departments.Where(row => (row.DepartmentName.ToUpper() == departmentName.ToUpper())).FirstOrDefault();

                                #region create employee
                                if (e == null)
                                {
                                    try
                                    {
                                        Employee newEmployee = new Employee();
                                        newEmployee.EmployeeId = employeeId;
                                        newEmployee.EmployeeName = dr["EMPLOYEE"].ToString();
                                        newEmployee.Organization = organizationId;
                                        newEmployee.StartDate = (DateTime)dr["START_DT"];
                                        if (dr["QUIT_DT"] != DBNull.Value)
                                        {
                                            newEmployee.QuitDate = (DateTime)dr["QUIT_DT"];
                                        }
                                        if (dr["INCENTIVEACT_CD"] != DBNull.Value)
                                        {
                                            newEmployee.IncentiveActCode = int.Parse(dr["INCENTIVEACT_CD"].ToString());
                                        }
                                        newEmployee.WorkingType = dr["WORKINGTYPE_DSC"].ToString();
                                        newEmployee.DepartmentName = departmentName;
                                        if (d != null)
                                        {
                                            newEmployee.DepartmentCode = (int)d.AccountingDepartmentId;
                                        }
                                        sop.CreateEmployee(newEmployee);
                                        // dal.Create(newEmployee);
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error($" ServiceName : PayrollService, MethodName : create employee, EmployeeId : {employeeId} Exception : {ex.ToString()}");
                                        throw ex;
                                    }
                                }
                                #endregion create employee


                                #region update employee
                                else
                                {
                                    try
                                    {
                                        e.EmployeeName = dr["EMPLOYEE"].ToString();
                                        e.StartDate = (DateTime)dr["START_DT"];
                                        if (dr["QUIT_DT"] != DBNull.Value)
                                        {
                                            e.QuitDate = (DateTime)dr["QUIT_DT"];
                                        } else
                                        {
                                            e.QuitDate = null;
                                        }
                                        if (dr["INCENTIVEACT_CD"] != DBNull.Value)
                                        {
                                            e.IncentiveActCode = int.Parse(dr["INCENTIVEACT_CD"].ToString());
                                        } else
                                        {
                                            e.IncentiveActCode = null;
                                        }
                                        e.WorkingType = dr["WORKINGTYPE_DSC"].ToString();
                                        e.DepartmentName = departmentName;
                                        if (d != null)
                                        {
                                            e.DepartmentCode = (int)d.AccountingDepartmentId;
                                        }
                                        sop.UpdateEmployee(e);
                                        // dal.Update(e);
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error($" ServiceName : PayrollService, MethodName : update employee, EmployeeId : {employeeId} Exception : {ex.ToString()}");
                                        throw ex;
                                    }
                                }
                                #endregion update employee
                                dal.CommitTransaction();
                            }
                        }
                       
                        foreach (DataRow dr in dt.Rows)
                        {
                            processrow = dr;
                            if (dr["SICILNO"] != DBNull.Value)
                            {

                                // check if payroll record exist
                                employeeId = long.Parse(dr["SICILNO"].ToString());
                                int yr = int.Parse(dr["YEAR_CD"].ToString());
                                int month = int.Parse(dr["MONTH_CD"].ToString());
                                Payroll p = readEmployeePayroll(dal, employeeId, yr, month);
                                dal.BeginTransaction();
                                #region update payroll
                                if (p != null)
                                {
                                    try
                                    {
                                        if (dr["WORKINGDAY_CNT"] != DBNull.Value) p.WorkingDay = int.Parse(dr["WORKINGDAY_CNT"].ToString());
                                        if (dr["WORKINGHOURS_AMT"] != DBNull.Value) p.WorkingHours = (decimal)dr["WORKINGHOURS_AMT"];
                                        if (dr["PAY_AMT"] != DBNull.Value) p.PayAmount = (decimal)dr["PAY_AMT"];
                                        if (dr["ANNUALLEAVEDAY_CNT"] != DBNull.Value) p.AnnualLeave = int.Parse(dr["ANNUALLEAVEDAY_CNT"].ToString());
                                        if (dr["ANNUALLEAVEHOURS_AMT"] != DBNull.Value) p.AnnualLeaveHours = (decimal)dr["ANNUALLEAVEHOURS_AMT"];
                                        if (dr["ANNUALLEAVEPAY_AMT"] != DBNull.Value) p.AnnualLeavePay = (decimal)dr["ANNUALLEAVEPAY_AMT"];
                                        if (dr["PAIDLEAVEWEXCUSEDAY_CNT"] != DBNull.Value) p.PaidLeavewithExcuseDayCount = int.Parse(dr["PAIDLEAVEWEXCUSEDAY_CNT"].ToString());
                                        if (dr["PAIDLEAVEWEXCUSEHOURS_AMT"] != DBNull.Value) p.PaidLeavewithExcuseHours = (decimal)dr["PAIDLEAVEWEXCUSEHOURS_AMT"];
                                        if (dr["PAIDLEAVEWEXCUSEPAY_AMT"] != DBNull.Value) p.PaidLeavewithExcusePayAmount = (decimal)dr["PAIDLEAVEWEXCUSEPAY_AMT"];
                                        if (dr["LEAVENOPAYWMEDREPDAY_CNT"] != DBNull.Value) p.LeaveNoPaywithMedicalReportDayCount = int.Parse(dr["LEAVENOPAYWMEDREPDAY_CNT"].ToString());
                                        if (dr["LEAVENOPAYWMEDREPHOURS_AMT"] != DBNull.Value) p.LeaveNoPaywithMedicalReportHours = (decimal)dr["LEAVENOPAYWMEDREPHOURS_AMT"];
                                        if (dr["LEAVENOPAYWOUTEXCUSEDAY_CNT"] != DBNull.Value) p.LeaveNoPaywithoutExcuseDayCount = int.Parse(dr["LEAVENOPAYWOUTEXCUSEDAY_CNT"].ToString());
                                        if (dr["LEAVENOPAYWOUTEXCUSEHOURS_AMT"] != DBNull.Value) p.LeaveNoPaywithoutExcuseHours = (decimal)dr["LEAVENOPAYWOUTEXCUSEHOURS_AMT"];
                                        if (dr["ABSENCEDAY_CNT"] != DBNull.Value) p.AbsenceDayCount = int.Parse(dr["ABSENCEDAY_CNT"].ToString());
                                        if (dr["ABSENCEHOURS_AMT"] != DBNull.Value) p.AbsenceHours = (decimal)dr["ABSENCEHOURS_AMT"];
                                        if (dr["LEGALHOLIDAYHOURS_AMT"] != DBNull.Value) p.LegalHolidayHours = (decimal)dr["LEGALHOLIDAYHOURS_AMT"];
                                        if (dr["LEGALHOLIDAYPAY_AMT"] != DBNull.Value) p.LegalHolidayPayAmount = (decimal)dr["LEGALHOLIDAYPAY_AMT"];
                                        if (dr["OVERTIMEHOURS_AMT"] != DBNull.Value) p.OvertimeHours = (decimal)dr["OVERTIMEHOURS_AMT"];
                                        if (dr["OVERTIMEPAY_AMT"] != DBNull.Value) p.OvertimePayAmount = (decimal)dr["OVERTIMEPAY_AMT"];
                                        if (dr["CASHINDEMNITY_AMT"] != DBNull.Value) p.CashIndemnityAmount = (decimal)dr["CASHINDEMNITY_AMT"];
                                        if (dr["FOODALLOWANCE_AMT"] != DBNull.Value) p.FoodAllowanceAmount = (decimal)dr["FOODALLOWANCE_AMT"];
                                        if (dr["FOODALLOWANCEDAY_CNT"] != DBNull.Value) p.FoodAllowanceDayCount = Convert.ToInt32((decimal)dr["FOODALLOWANCEDAY_CNT"]);
                                        if (dr["LEAVEPAY_AMT"] != DBNull.Value) p.LeavePayAmount = (decimal)dr["LEAVEPAY_AMT"];
                                        if (dr["ADVANCE_AMT"] != DBNull.Value) p.AdvanceAmount = (decimal)dr["ADVANCE_AMT"];
                                        if (dr["PAYCUT_AMT"] != DBNull.Value) p.PayCutAmount = (decimal)dr["PAYCUT_AMT"];
                                        if (dr["INSTALLMENTPAYCUT_AMT"] != DBNull.Value) p.InstallmentPayCutAmount = (decimal)dr["INSTALLMENTPAYCUT_AMT"];
                                        if (dr["INSURANCECUT_AMT"] != DBNull.Value) p.InsuranceCutAmount = (decimal)dr["INSURANCECUT_AMT"];
                                        if (dr["ALIMONYCUT_AMT"] != DBNull.Value) p.AlimonyCutAmount = (decimal)dr["ALIMONYCUT_AMT"];
                                        if (dr["EXECUTIONDEDUCTION1_AMT"] != DBNull.Value) p.ExecutionDeduction1Amount = (decimal)dr["EXECUTIONDEDUCTION1_AMT"];
                                        if (dr["EXECUTIONDEDUCTION2_AMT"] != DBNull.Value) p.ExecutionDeduction2Amount = (decimal)dr["EXECUTIONDEDUCTION2_AMT"];
                                        if (dr["EXECUTIONDEDUCTION3_AMT"] != DBNull.Value) p.ExecutionDeduction3Amount = (decimal)dr["EXECUTIONDEDUCTION3_AMT"];
                                        if (dr["INSURANCEDAY_CNT"] != DBNull.Value) p.InsuranceDayCount = int.Parse(dr["INSURANCEDAY_CNT"].ToString());
                                        if (dr["ASSESSMENT_AMT"] != DBNull.Value) p.AssessmentAmount = (decimal)dr["ASSESSMENT_AMT"];
                                        if (dr["INSURANCECUTWORKER_AMT"] != DBNull.Value) p.InsuranceCutWorkerAmount = (decimal)dr["INSURANCECUTWORKER_AMT"];
                                        if (dr["INSURANCECUTEMPLOYER_AMT"] != DBNull.Value) p.InsuranceCutEmployerAmount = (decimal)dr["INSURANCECUTEMPLOYER_AMT"];
                                        if (dr["UNEMPLOYMENTPREMIUMWORKER_AMT"] != DBNull.Value) p.UnemploymentPremiumWorkerAmount = (decimal)dr["UNEMPLOYMENTPREMIUMWORKER_AMT"];
                                        if (dr["UNEMPLOYMENTPREMIUMEMPLOYER_AMT"] != DBNull.Value) p.UnemploymentPremiumEmployerAmount = (decimal)dr["UNEMPLOYMENTPREMIUMEMPLOYER_AMT"];
                                        if (dr["STAMPTAX_AMT"] != DBNull.Value) p.StampTaxAmount = (decimal)dr["STAMPTAX_AMT"];
                                        if (dr["TAXINCENTIVE_AMT"] != DBNull.Value) p.TaxIncentiveAmount = (decimal)dr["TAXINCENTIVE_AMT"];
                                        if (dr["PREVTAXASSESSMENT_AMT"] != DBNull.Value) p.PreviousTaxAssessmentAmount = (decimal)dr["PREVTAXASSESSMENT_AMT"];
                                        if (dr["TAXASSESSMENT_AMT"] != DBNull.Value) p.TaxAssessmentAmount = (decimal)dr["TAXASSESSMENT_AMT"];
                                        if (dr["INCOMETAX_AMT"] != DBNull.Value) p.IncomeTaxAmount = (decimal)dr["INCOMETAX_AMT"];
                                        if (dr["INCOMETAX_RT"] != DBNull.Value) p.IncomeTaxRate = (decimal)dr["INCOMETAX_RT"];
                                        if (dr["TOTALWITHHOLDING_AMT"] != DBNull.Value) p.TotalWithholdingAmount = (decimal)dr["TOTALWITHHOLDING_AMT"];
                                        if (dr["MINLIVINGALLOWANCE_AMT"] != DBNull.Value) p.MinimumLivingAllowanceAmount = (decimal)dr["MINLIVINGALLOWANCE_AMT"];
                                        if (dr["NET_AMT"] != DBNull.Value) p.NetAmount = (decimal)dr["NET_AMT"];
                                        if (dr["TOTALGROSSREVENUE_AMT"] != DBNull.Value) p.TotalGrossRevenueAmount = (decimal)dr["TOTALGROSSREVENUE_AMT"];
                                        if (dr["INCENTIVESHARE5510_AMT"] != DBNull.Value) p.IncentiveShare5510Amount = (decimal)dr["INCENTIVESHARE5510_AMT"];
                                        if (dr["INCENTIVESHARE6111_AMT"] != DBNull.Value) p.IncentiveShare6111Amount = (decimal)dr["INCENTIVESHARE6111_AMT"];
                                        if (dr["INCENTIVESHARE2828_AMT"] != DBNull.Value) p.IncentiveShare2828Amount = (decimal)dr["INCENTIVESHARE2828_AMT"];
                                        if (dr["INCENTIVESHARE27103_AMT"] != DBNull.Value) p.IncentiveShare27103Amount = (decimal)dr["INCENTIVESHARE27103_AMT"];
                                        if (dr["INCENTIVESHARE14857_AMT"] != DBNull.Value) p.IncentiveShare14857Amount = (decimal)dr["INCENTIVESHARE14857_AMT"];
                                        if (dr["INCOMETAXINCENTIVESHARE_AMT"] != DBNull.Value) p.IncomeTaxIncentiveShareAmount = (decimal)dr["INCOMETAXINCENTIVESHARE_AMT"];
                                        if (dr["UNEMPLOYMENTINCENTIVESHARE_AMT"] != DBNull.Value) p.UnemploymentIncentiveShareAmount = (decimal)dr["UNEMPLOYMENTINCENTIVESHARE_AMT"];
                                        if (dr["SEVERANCEPAY_AMT"] != DBNull.Value) p.SeverancePayAmount = (decimal)dr["SEVERANCEPAY_AMT"];
                                        if (dr["UNEMPLOYMENTINCENTIVE687_AMT"] != DBNull.Value) p.UnemploymentIncentive687Amount = (decimal)dr["UNEMPLOYMENTINCENTIVE687_AMT"];
                                        if (dr["TOTALINSURANCEPREM_AMT"] != DBNull.Value) p.TotalInsurancePremAmount = (decimal)dr["TOTALINSURANCEPREM_AMT"];
                                        if (dr["TOTALUNEMPLOYMENTPREM_AMT"] != DBNull.Value) p.TotalUnemploymentPremAmount = (decimal)dr["TOTALUNEMPLOYMENTPREM_AMT"];
                                        if (dr["CASHDEFICIT_AMT"] != DBNull.Value) p.CashDeficitAmount = (decimal)dr["CASHDEFICIT_AMT"];
                                        dal.Update(p);
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error($" ServiceName : PayrollService, MethodName : update payroll, EmployeeId : {employeeId} Exception : {ex.ToString()}");
                                        throw ex;
                                    }
                                }
                                #endregion update payroll

                                #region create payroll
                                else
                                {
                                    try
                                    {
                                        Payroll newp = new Payroll();
                                        newp.Employee = employeeId;
                                        newp.YearCode = yr;
                                        newp.MonthCode = month;
                                        newp.Organization = organizationId;
                                        newp.Event = eventId;
                                        if (dr["WORKINGDAY_CNT"] != DBNull.Value) newp.WorkingDay = int.Parse(dr["WORKINGDAY_CNT"].ToString());
                                        if (dr["WORKINGHOURS_AMT"] != DBNull.Value) newp.WorkingHours = (decimal)dr["WORKINGHOURS_AMT"];
                                        if (dr["PAY_AMT"] != DBNull.Value) newp.PayAmount = (decimal)dr["PAY_AMT"];
                                        if (dr["ANNUALLEAVEDAY_CNT"] != DBNull.Value) newp.AnnualLeave = int.Parse(dr["ANNUALLEAVEDAY_CNT"].ToString());
                                        if (dr["ANNUALLEAVEHOURS_AMT"] != DBNull.Value) newp.AnnualLeaveHours = (decimal)dr["ANNUALLEAVEHOURS_AMT"];
                                        if (dr["ANNUALLEAVEPAY_AMT"] != DBNull.Value) newp.AnnualLeavePay = (decimal)dr["ANNUALLEAVEPAY_AMT"];
                                        if (dr["PAIDLEAVEWEXCUSEDAY_CNT"] != DBNull.Value) newp.PaidLeavewithExcuseDayCount = int.Parse(dr["PAIDLEAVEWEXCUSEDAY_CNT"].ToString());
                                        if (dr["PAIDLEAVEWEXCUSEHOURS_AMT"] != DBNull.Value) newp.PaidLeavewithExcuseHours = (decimal)dr["PAIDLEAVEWEXCUSEHOURS_AMT"];
                                        if (dr["PAIDLEAVEWEXCUSEPAY_AMT"] != DBNull.Value) newp.PaidLeavewithExcusePayAmount = (decimal)dr["PAIDLEAVEWEXCUSEPAY_AMT"];
                                        if (dr["LEAVENOPAYWMEDREPDAY_CNT"] != DBNull.Value) newp.LeaveNoPaywithMedicalReportDayCount = int.Parse(dr["LEAVENOPAYWMEDREPDAY_CNT"].ToString());
                                        if (dr["LEAVENOPAYWMEDREPHOURS_AMT"] != DBNull.Value) newp.LeaveNoPaywithMedicalReportHours = (decimal)dr["LEAVENOPAYWMEDREPHOURS_AMT"];
                                        if (dr["LEAVENOPAYWOUTEXCUSEDAY_CNT"] != DBNull.Value) newp.LeaveNoPaywithoutExcuseDayCount = int.Parse(dr["LEAVENOPAYWOUTEXCUSEDAY_CNT"].ToString());
                                        if (dr["LEAVENOPAYWOUTEXCUSEHOURS_AMT"] != DBNull.Value) newp.LeaveNoPaywithoutExcuseHours = (decimal)dr["LEAVENOPAYWOUTEXCUSEHOURS_AMT"];
                                        if (dr["ABSENCEDAY_CNT"] != DBNull.Value) newp.AbsenceDayCount = int.Parse(dr["ABSENCEDAY_CNT"].ToString());
                                        if (dr["ABSENCEHOURS_AMT"] != DBNull.Value) newp.AbsenceHours = (decimal)dr["ABSENCEHOURS_AMT"];
                                        if (dr["LEGALHOLIDAYHOURS_AMT"] != DBNull.Value) newp.LegalHolidayHours = (decimal)dr["LEGALHOLIDAYHOURS_AMT"];
                                        if (dr["LEGALHOLIDAYPAY_AMT"] != DBNull.Value) newp.LegalHolidayPayAmount = (decimal)dr["LEGALHOLIDAYPAY_AMT"];
                                        if (dr["OVERTIMEHOURS_AMT"] != DBNull.Value) newp.OvertimeHours = (decimal)dr["OVERTIMEHOURS_AMT"];
                                        if (dr["OVERTIMEPAY_AMT"] != DBNull.Value) newp.OvertimePayAmount = (decimal)dr["OVERTIMEPAY_AMT"];
                                        if (dr["CASHINDEMNITY_AMT"] != DBNull.Value) newp.CashIndemnityAmount = (decimal)dr["CASHINDEMNITY_AMT"];
                                        if (dr["FOODALLOWANCE_AMT"] != DBNull.Value) newp.FoodAllowanceAmount = (decimal)dr["FOODALLOWANCE_AMT"];
                                        if (dr["FOODALLOWANCEDAY_CNT"] != DBNull.Value) newp.FoodAllowanceDayCount = Convert.ToInt32((decimal)dr["FOODALLOWANCEDAY_CNT"]);
                                        if (dr["LEAVEPAY_AMT"] != DBNull.Value) newp.LeavePayAmount = (decimal)dr["LEAVEPAY_AMT"];
                                        if (dr["ADVANCE_AMT"] != DBNull.Value) newp.AdvanceAmount = (decimal)dr["ADVANCE_AMT"];
                                        if (dr["PAYCUT_AMT"] != DBNull.Value) newp.PayCutAmount = (decimal)dr["PAYCUT_AMT"];
                                        if (dr["INSTALLMENTPAYCUT_AMT"] != DBNull.Value) newp.InstallmentPayCutAmount = (decimal)dr["INSTALLMENTPAYCUT_AMT"];
                                        if (dr["INSURANCECUT_AMT"] != DBNull.Value) newp.InsuranceCutAmount = (decimal)dr["INSURANCECUT_AMT"];
                                        if (dr["ALIMONYCUT_AMT"] != DBNull.Value) newp.AlimonyCutAmount = (decimal)dr["ALIMONYCUT_AMT"];
                                        if (dr["EXECUTIONDEDUCTION1_AMT"] != DBNull.Value) newp.ExecutionDeduction1Amount = (decimal)dr["EXECUTIONDEDUCTION1_AMT"];
                                        if (dr["EXECUTIONDEDUCTION2_AMT"] != DBNull.Value) newp.ExecutionDeduction2Amount = (decimal)dr["EXECUTIONDEDUCTION2_AMT"];
                                        if (dr["EXECUTIONDEDUCTION3_AMT"] != DBNull.Value) newp.ExecutionDeduction3Amount = (decimal)dr["EXECUTIONDEDUCTION3_AMT"];
                                        if (dr["INSURANCEDAY_CNT"] != DBNull.Value) newp.InsuranceDayCount = int.Parse(dr["INSURANCEDAY_CNT"].ToString());
                                        if (dr["ASSESSMENT_AMT"] != DBNull.Value) newp.AssessmentAmount = (decimal)dr["ASSESSMENT_AMT"];
                                        if (dr["INSURANCECUTWORKER_AMT"] != DBNull.Value) newp.InsuranceCutWorkerAmount = (decimal)dr["INSURANCECUTWORKER_AMT"];
                                        if (dr["INSURANCECUTEMPLOYER_AMT"] != DBNull.Value) newp.InsuranceCutEmployerAmount = (decimal)dr["INSURANCECUTEMPLOYER_AMT"];
                                        if (dr["UNEMPLOYMENTPREMIUMWORKER_AMT"] != DBNull.Value) newp.UnemploymentPremiumWorkerAmount = (decimal)dr["UNEMPLOYMENTPREMIUMWORKER_AMT"];
                                        if (dr["UNEMPLOYMENTPREMIUMEMPLOYER_AMT"] != DBNull.Value) newp.UnemploymentPremiumEmployerAmount = (decimal)dr["UNEMPLOYMENTPREMIUMEMPLOYER_AMT"];
                                        if (dr["STAMPTAX_AMT"] != DBNull.Value) newp.StampTaxAmount = (decimal)dr["STAMPTAX_AMT"];
                                        if (dr["TAXINCENTIVE_AMT"] != DBNull.Value) newp.TaxIncentiveAmount = (decimal)dr["TAXINCENTIVE_AMT"];
                                        if (dr["PREVTAXASSESSMENT_AMT"] != DBNull.Value) newp.PreviousTaxAssessmentAmount = (decimal)dr["PREVTAXASSESSMENT_AMT"];
                                        if (dr["TAXASSESSMENT_AMT"] != DBNull.Value) newp.TaxAssessmentAmount = (decimal)dr["TAXASSESSMENT_AMT"];
                                        if (dr["INCOMETAX_AMT"] != DBNull.Value) newp.IncomeTaxAmount = (decimal)dr["INCOMETAX_AMT"];
                                        if (dr["INCOMETAX_RT"] != DBNull.Value) newp.IncomeTaxRate = (decimal)dr["INCOMETAX_RT"];
                                        if (dr["TOTALWITHHOLDING_AMT"] != DBNull.Value) newp.TotalWithholdingAmount = (decimal)dr["TOTALWITHHOLDING_AMT"];
                                        if (dr["MINLIVINGALLOWANCE_AMT"] != DBNull.Value) newp.MinimumLivingAllowanceAmount = (decimal)dr["MINLIVINGALLOWANCE_AMT"];
                                        if (dr["NET_AMT"] != DBNull.Value) newp.NetAmount = (decimal)dr["NET_AMT"];
                                        if (dr["TOTALGROSSREVENUE_AMT"] != DBNull.Value) newp.TotalGrossRevenueAmount = (decimal)dr["TOTALGROSSREVENUE_AMT"];
                                        if (dr["INCENTIVESHARE5510_AMT"] != DBNull.Value) newp.IncentiveShare5510Amount = (decimal)dr["INCENTIVESHARE5510_AMT"];
                                        if (dr["INCENTIVESHARE6111_AMT"] != DBNull.Value) newp.IncentiveShare6111Amount = (decimal)dr["INCENTIVESHARE6111_AMT"];
                                        if (dr["INCENTIVESHARE2828_AMT"] != DBNull.Value) newp.IncentiveShare2828Amount = (decimal)dr["INCENTIVESHARE2828_AMT"];
                                        if (dr["INCENTIVESHARE27103_AMT"] != DBNull.Value) newp.IncentiveShare27103Amount = (decimal)dr["INCENTIVESHARE27103_AMT"];
                                        if (dr["INCENTIVESHARE14857_AMT"] != DBNull.Value) newp.IncentiveShare14857Amount = (decimal)dr["INCENTIVESHARE14857_AMT"];
                                        if (dr["INCOMETAXINCENTIVESHARE_AMT"] != DBNull.Value) newp.IncomeTaxIncentiveShareAmount = (decimal)dr["INCOMETAXINCENTIVESHARE_AMT"];
                                        if (dr["UNEMPLOYMENTINCENTIVESHARE_AMT"] != DBNull.Value) newp.UnemploymentIncentiveShareAmount = (decimal)dr["UNEMPLOYMENTINCENTIVESHARE_AMT"];
                                        if (dr["SEVERANCEPAY_AMT"] != DBNull.Value) newp.SeverancePayAmount = (decimal)dr["SEVERANCEPAY_AMT"];
                                        if (dr["UNEMPLOYMENTINCENTIVE687_AMT"] != DBNull.Value) newp.UnemploymentIncentive687Amount = (decimal)dr["UNEMPLOYMENTINCENTIVE687_AMT"];
                                        if (dr["TOTALINSURANCEPREM_AMT"] != DBNull.Value) newp.TotalInsurancePremAmount = (decimal)dr["TOTALINSURANCEPREM_AMT"];
                                        if (dr["TOTALUNEMPLOYMENTPREM_AMT"] != DBNull.Value) newp.TotalUnemploymentPremAmount = (decimal)dr["TOTALUNEMPLOYMENTPREM_AMT"];
                                        if (dr["CASHDEFICIT_AMT"] != DBNull.Value) newp.CashDeficitAmount = (decimal)dr["CASHDEFICIT_AMT"];
                                        // _logger.Debug($"Payroll will be created EmployeeId : {Newtonsoft.Json.JsonConvert.SerializeObject(newp)}");
                                        dal.Create(newp);
                                        // _logger.Debug($"Payroll created EmployeeId : {Newtonsoft.Json.JsonConvert.SerializeObject(newp)}");
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error($" ServiceName : PayrollService, MethodName : create payroll, EmployeeId : {employeeId} Exception : {ex.ToString()}");
                                        throw ex;
                                    }
                                }
                                #endregion create payroll
                                dal.CommitTransaction();
                            }

                        }

                        
                    }
                    else if (result.Length > 0)
                    {
                        throw new Exception(result);
                    }

                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($" ServiceName : PayrollService, MethodName : LoadHRFile, EmployeeId : {employeeId} Datarow : {Newtonsoft.Json.JsonConvert.SerializeObject(processrow)} Exception : {ex.ToString()}");
                    throw ex;
                }
            }

        }

        public IEnumerable<Payroll> ListMonth(int year, int month)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmYear = dal.CreateParameter("Year", year);
                IUniParameter prmMonth = dal.CreateParameter("Month", month);
                return dal.List<Payroll>("ACC_LST_PAYROLL_SP", prmYear, prmMonth).ToList();
            }
        }

        public void MikroTransfer(int year, int month)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmYear = dal.CreateParameter("Year", year);
                    IUniParameter prmMonth = dal.CreateParameter("Month", month);
                    dal.ExecuteNonQuery("MIK_INS_PAYROLL_SP", prmYear, prmMonth);

                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($" ServiceName : PayrollService, MethodName : MikroTransfer, Year : {year} Month : {month} Exception : {ex.ToString()}");
                    throw ex;
                }

            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}