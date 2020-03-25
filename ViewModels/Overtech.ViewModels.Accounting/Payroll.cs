// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Accounting
{
    [OTDisplayName("Payroll")]
    [DataContract]
    public class Payroll : ViewModelObject
    {
        private long _payrollId;
        private long _event;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private long _employee;
        private int _yearCode;
        private int _monthCode;
        private Nullable<int> _workingDay;
        private Nullable<decimal> _workingHours;
        private Nullable<decimal> _payAmount;
        private Nullable<int> _annualLeave;
        private Nullable<decimal> _annualLeaveHours;
        private Nullable<decimal> _annualLeavePay;
        private Nullable<int> _paidLeavewithExcuseDayCount;
        private Nullable<decimal> _paidLeavewithExcuseHours;
        private Nullable<decimal> _paidLeavewithExcusePayAmount;
        private Nullable<int> _leaveNoPaywithMedicalReportDayCount;
        private Nullable<decimal> _leaveNoPaywithMedicalReportHours;
        private Nullable<int> _leaveNoPaywithoutExcuseDayCount;
        private Nullable<decimal> _leaveNoPaywithoutExcuseHours;
        private Nullable<int> _absenceDayCount;
        private Nullable<decimal> _absenceHours;
        private Nullable<decimal> _legalHolidayHours;
        private Nullable<decimal> _legalHolidayPayAmount;
        private Nullable<decimal> _overtimeHours;
        private Nullable<decimal> _overtimePayAmount;
        private Nullable<decimal> _cashIndemnityAmount;
        private Nullable<decimal> _foodAllowanceAmount;
        private Nullable<int> _foodAllowanceDayCount;
        private Nullable<decimal> _leavePayAmount;
        private Nullable<decimal> _advanceAmount;
        private Nullable<decimal> _payCutAmount;
        private Nullable<decimal> _installmentPayCutAmount;
        private Nullable<decimal> _insuranceCutAmount;
        private Nullable<decimal> _alimonyCutAmount;
        private Nullable<decimal> _executionDeduction1Amount;
        private Nullable<decimal> _executionDeduction2Amount;
        private Nullable<decimal> _executionDeduction3Amount;
        private Nullable<int> _insuranceDayCount;
        private Nullable<decimal> _assessmentAmount;
        private Nullable<decimal> _insuranceCutWorkerAmount;
        private Nullable<decimal> _insuranceCutEmployerAmount;
        private Nullable<decimal> _unemploymentPremiumWorkerAmount;
        private Nullable<decimal> _unemploymentPremiumEmployerAmount;
        private Nullable<decimal> _stampTaxAmount;
        private Nullable<decimal> _previousTaxAssessmentAmount;
        private Nullable<decimal> _taxAssessmentAmount;
        private Nullable<decimal> _incomeTaxAmount;
        private Nullable<decimal> _incomeTaxRate;
        private Nullable<decimal> _totalWithholdingAmount;
        private Nullable<decimal> _minimumLivingAllowanceAmount;
        private Nullable<decimal> _netAmount;
        private Nullable<decimal> _totalGrossRevenueAmount;
        private Nullable<decimal> _incentiveShare5510Amount;
        private Nullable<decimal> _incentiveShare6111Amount;
        private Nullable<decimal> _incentiveShare2828Amount;
        private Nullable<decimal> _incentiveShare27103Amount;
        private Nullable<decimal> _incentiveShare14857Amount;
        private Nullable<decimal> _incomeTaxIncentiveShareAmount;
        private Nullable<decimal> _unemploymentIncentiveShareAmount;
        private Nullable<decimal> _taxIncentiveAmount;
        

        /*Section="Field-PayrollId"*/
        [ScaffoldColumn(false)]
        [OTRequired("Payroll Id", null)]
        [OTDisplayName("Payroll Id")]
        [DataMember]
        public long PayrollId
        {
            get
            {
                return _payrollId;
            }
            set
            {
                _payrollId = value;
            }
        }

        /*Section="Field-Event"*/
        [ScaffoldColumn(false)]
        [OTRequired("Event", null)]
        [OTDisplayName("Event")]
        [DataMember]
        public long Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }

        /*Section="Field-Organization"*/
        [ScaffoldColumn(false)]
        [OTRequired("Organization", null)]
        [OTDisplayName("Organization")]
        [DataMember]
        public long Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
            }
        }

        /*Section="Field-Deleted"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Deleted")]
        [ReadOnly(true)]
        [DataMember]
        public bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                _deleted = value;
            }
        }

        /*Section="Field-CreateDate"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Date")]
        [ReadOnly(true)]
        [DataMember]
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }

        /*Section="Field-UpdateDate"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Update Date")]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<DateTime> UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                _updateDate = value;
            }
        }

        /*Section="Field-CreateUser"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create User")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateUser
        {
            get
            {
                return _createUser;
            }
            set
            {
                _createUser = value;
            }
        }

        /*Section="Field-UpdateUser"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Update User")]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<long> UpdateUser
        {
            get
            {
                return _updateUser;
            }
            set
            {
                _updateUser = value;
            }
        }

        /*Section="Field-CreateChannel"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Channel")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateChannel
        {
            get
            {
                return _createChannel;
            }
            set
            {
                _createChannel = value;
            }
        }

        /*Section="Field-CreateBranch"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Branch")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateBranch
        {
            get
            {
                return _createBranch;
            }
            set
            {
                _createBranch = value;
            }
        }

        /*Section="Field-CreateScreen"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Screen")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateScreen
        {
            get
            {
                return _createScreen;
            }
            set
            {
                _createScreen = value;
            }
        }

        /*Section="Field-Employee"*/
        [UIHint("EmployeeList")]
        [OTRequired("Employee", null)]
        [OTDisplayName("Employee")]
        [DataMember]
        public long Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
            }
        }

        /*Section="Field-YearCode"*/
        [OTRequired("Year Code", null)]
        [OTDisplayName("Year Code")]
        [DataMember]
        public int YearCode
        {
            get
            {
                return _yearCode;
            }
            set
            {
                _yearCode = value;
            }
        }

        /*Section="Field-MonthCode"*/
        [OTRequired("Month Code", null)]
        [OTDisplayName("Month Code")]
        [DataMember]
        public int MonthCode
        {
            get
            {
                return _monthCode;
            }
            set
            {
                _monthCode = value;
            }
        }

        /*Section="Field-WorkingDay"*/
        [OTDisplayName("Working Day")]
        [DataMember]
        public Nullable<int> WorkingDay
        {
            get
            {
                return _workingDay;
            }
            set
            {
                _workingDay = value;
            }
        }

        /*Section="Field-WorkingHours"*/
        [OTDisplayName("Working Hours")]
        [DataMember]
        public Nullable<decimal> WorkingHours
        {
            get
            {
                return _workingHours;
            }
            set
            {
                _workingHours = value;
            }
        }

        /*Section="Field-PayAmount"*/
        [OTDisplayName("Pay Amount")]
        [DataMember]
        public Nullable<decimal> PayAmount
        {
            get
            {
                return _payAmount;
            }
            set
            {
                _payAmount = value;
            }
        }

        /*Section="Field-AnnualLeave"*/
        [OTDisplayName("Annual Leave")]
        [DataMember]
        public Nullable<int> AnnualLeave
        {
            get
            {
                return _annualLeave;
            }
            set
            {
                _annualLeave = value;
            }
        }

        /*Section="Field-AnnualLeaveHours"*/
        [OTDisplayName("Annual Leave Hours")]
        [DataMember]
        public Nullable<decimal> AnnualLeaveHours
        {
            get
            {
                return _annualLeaveHours;
            }
            set
            {
                _annualLeaveHours = value;
            }
        }

        /*Section="Field-AnnualLeavePay"*/
        [OTDisplayName("Annual Leave Pay")]
        [DataMember]
        public Nullable<decimal> AnnualLeavePay
        {
            get
            {
                return _annualLeavePay;
            }
            set
            {
                _annualLeavePay = value;
            }
        }

        /*Section="Field-PaidLeavewithExcuseDayCount"*/
        [OTDisplayName("Paid Leave with Excuse Day Count")]
        [DataMember]
        public Nullable<int> PaidLeavewithExcuseDayCount
        {
            get
            {
                return _paidLeavewithExcuseDayCount;
            }
            set
            {
                _paidLeavewithExcuseDayCount = value;
            }
        }

        /*Section="Field-PaidLeavewithExcuseHours"*/
        [OTDisplayName("Paid Leave with Excuse Hours")]
        [DataMember]
        public Nullable<decimal> PaidLeavewithExcuseHours
        {
            get
            {
                return _paidLeavewithExcuseHours;
            }
            set
            {
                _paidLeavewithExcuseHours = value;
            }
        }

        /*Section="Field-PaidLeavewithExcusePayAmount"*/
        [OTDisplayName("Paid Leave with Excuse Pay Amount")]
        [DataMember]
        public Nullable<decimal> PaidLeavewithExcusePayAmount
        {
            get
            {
                return _paidLeavewithExcusePayAmount;
            }
            set
            {
                _paidLeavewithExcusePayAmount = value;
            }
        }

        /*Section="Field-LeaveNoPaywithMedicalReportDayCount"*/
        [OTDisplayName("Leave No Pay with Medical Report Day Count")]
        [DataMember]
        public Nullable<int> LeaveNoPaywithMedicalReportDayCount
        {
            get
            {
                return _leaveNoPaywithMedicalReportDayCount;
            }
            set
            {
                _leaveNoPaywithMedicalReportDayCount = value;
            }
        }

        /*Section="Field-LeaveNoPaywithMedicalReportHours"*/
        [OTDisplayName("Leave No Pay with Medical Report Hours")]
        [DataMember]
        public Nullable<decimal> LeaveNoPaywithMedicalReportHours
        {
            get
            {
                return _leaveNoPaywithMedicalReportHours;
            }
            set
            {
                _leaveNoPaywithMedicalReportHours = value;
            }
        }

        /*Section="Field-LeaveNoPaywithoutExcuseDayCount"*/
        [OTDisplayName("Leave No Pay without Excuse Day Count")]
        [DataMember]
        public Nullable<int> LeaveNoPaywithoutExcuseDayCount
        {
            get
            {
                return _leaveNoPaywithoutExcuseDayCount;
            }
            set
            {
                _leaveNoPaywithoutExcuseDayCount = value;
            }
        }

        /*Section="Field-LeaveNoPaywithoutExcuseHours"*/
        [OTDisplayName("Leave No Pay without Excuse Hours")]
        [DataMember]
        public Nullable<decimal> LeaveNoPaywithoutExcuseHours
        {
            get
            {
                return _leaveNoPaywithoutExcuseHours;
            }
            set
            {
                _leaveNoPaywithoutExcuseHours = value;
            }
        }

        /*Section="Field-AbsenceDayCount"*/
        [OTDisplayName("Absence Day Count")]
        [DataMember]
        public Nullable<int> AbsenceDayCount
        {
            get
            {
                return _absenceDayCount;
            }
            set
            {
                _absenceDayCount = value;
            }
        }

        /*Section="Field-AbsenceHours"*/
        [OTDisplayName("Absence Hours")]
        [DataMember]
        public Nullable<decimal> AbsenceHours
        {
            get
            {
                return _absenceHours;
            }
            set
            {
                _absenceHours = value;
            }
        }

        /*Section="Field-LegalHolidayHours"*/
        [OTDisplayName("Legal Holiday Hours")]
        [DataMember]
        public Nullable<decimal> LegalHolidayHours
        {
            get
            {
                return _legalHolidayHours;
            }
            set
            {
                _legalHolidayHours = value;
            }
        }

        /*Section="Field-LegalHolidayPayAmount"*/
        [OTDisplayName("Legal Holiday Pay Amount")]
        [DataMember]
        public Nullable<decimal> LegalHolidayPayAmount
        {
            get
            {
                return _legalHolidayPayAmount;
            }
            set
            {
                _legalHolidayPayAmount = value;
            }
        }

        /*Section="Field-OvertimeHours"*/
        [OTDisplayName("Overtime Hours")]
        [DataMember]
        public Nullable<decimal> OvertimeHours
        {
            get
            {
                return _overtimeHours;
            }
            set
            {
                _overtimeHours = value;
            }
        }

        /*Section="Field-OvertimePayAmount"*/
        [OTDisplayName("Overtime Pay Amount")]
        [DataMember]
        public Nullable<decimal> OvertimePayAmount
        {
            get
            {
                return _overtimePayAmount;
            }
            set
            {
                _overtimePayAmount = value;
            }
        }

        /*Section="Field-CashIndemnityAmount"*/
        [OTDisplayName("Cash Indemnity Amount")]
        [DataMember]
        public Nullable<decimal> CashIndemnityAmount
        {
            get
            {
                return _cashIndemnityAmount;
            }
            set
            {
                _cashIndemnityAmount = value;
            }
        }

        /*Section="Field-FoodAllowanceAmount"*/
        [OTDisplayName("Food Allowance Amount")]
        [DataMember]
        public Nullable<decimal> FoodAllowanceAmount
        {
            get
            {
                return _foodAllowanceAmount;
            }
            set
            {
                _foodAllowanceAmount = value;
            }
        }

        /*Section="Field-FoodAllowanceDayCount"*/
        [OTDisplayName("Food Allowance Day Count")]
        [DataMember]
        public Nullable<int> FoodAllowanceDayCount
        {
            get
            {
                return _foodAllowanceDayCount;
            }
            set
            {
                _foodAllowanceDayCount = value;
            }
        }

        /*Section="Field-LeavePayAmount"*/
        [OTDisplayName("Leave Pay Amount")]
        [DataMember]
        public Nullable<decimal> LeavePayAmount
        {
            get
            {
                return _leavePayAmount;
            }
            set
            {
                _leavePayAmount = value;
            }
        }

        /*Section="Field-AdvanceAmount"*/
        [OTDisplayName("Advance Amount")]
        [DataMember]
        public Nullable<decimal> AdvanceAmount
        {
            get
            {
                return _advanceAmount;
            }
            set
            {
                _advanceAmount = value;
            }
        }

        /*Section="Field-PayCutAmount"*/
        [OTDisplayName("Pay Cut Amount")]
        [DataMember]
        public Nullable<decimal> PayCutAmount
        {
            get
            {
                return _payCutAmount;
            }
            set
            {
                _payCutAmount = value;
            }
        }

        /*Section="Field-InstallmentPayCutAmount"*/
        [OTDisplayName("Installment Pay Cut Amount")]
        [DataMember]
        public Nullable<decimal> InstallmentPayCutAmount
        {
            get
            {
                return _installmentPayCutAmount;
            }
            set
            {
                _installmentPayCutAmount = value;
            }
        }

        /*Section="Field-InsuranceCutAmount"*/
        [OTDisplayName("Insurance Cut Amount")]
        [DataMember]
        public Nullable<decimal> InsuranceCutAmount
        {
            get
            {
                return _insuranceCutAmount;
            }
            set
            {
                _insuranceCutAmount = value;
            }
        }

        /*Section="Field-AlimonyCutAmount"*/
        [OTDisplayName("Alimony Cut Amount")]
        [DataMember]
        public Nullable<decimal> AlimonyCutAmount
        {
            get
            {
                return _alimonyCutAmount;
            }
            set
            {
                _alimonyCutAmount = value;
            }
        }

        /*Section="Field-ExecutionDeduction1Amount"*/
        [OTDisplayName("Execution Deduction 1 Amount")]
        [DataMember]
        public Nullable<decimal> ExecutionDeduction1Amount
        {
            get
            {
                return _executionDeduction1Amount;
            }
            set
            {
                _executionDeduction1Amount = value;
            }
        }

        /*Section="Field-ExecutionDeduction2Amount"*/
        [OTDisplayName("Execution Deduction 2 Amount")]
        [DataMember]
        public Nullable<decimal> ExecutionDeduction2Amount
        {
            get
            {
                return _executionDeduction2Amount;
            }
            set
            {
                _executionDeduction2Amount = value;
            }
        }

        /*Section="Field-ExecutionDeduction3Amount"*/
        [OTDisplayName("Execution Deduction 3 Amount")]
        [DataMember]
        public Nullable<decimal> ExecutionDeduction3Amount
        {
            get
            {
                return _executionDeduction3Amount;
            }
            set
            {
                _executionDeduction3Amount = value;
            }
        }

        /*Section="Field-InsuranceDayCount"*/
        [OTDisplayName("Insurance Day Count")]
        [DataMember]
        public Nullable<int> InsuranceDayCount
        {
            get
            {
                return _insuranceDayCount;
            }
            set
            {
                _insuranceDayCount = value;
            }
        }

        /*Section="Field-AssessmentAmount"*/
        [OTDisplayName("Assessment Amount")]
        [DataMember]
        public Nullable<decimal> AssessmentAmount
        {
            get
            {
                return _assessmentAmount;
            }
            set
            {
                _assessmentAmount = value;
            }
        }

        /*Section="Field-InsuranceCutWorkerAmount"*/
        [OTDisplayName("Insurance Cut Worker Amount")]
        [DataMember]
        public Nullable<decimal> InsuranceCutWorkerAmount
        {
            get
            {
                return _insuranceCutWorkerAmount;
            }
            set
            {
                _insuranceCutWorkerAmount = value;
            }
        }

        /*Section="Field-InsuranceCutEmployerAmount"*/
        [OTDisplayName("Insurance Cut Employer Amount")]
        [DataMember]
        public Nullable<decimal> InsuranceCutEmployerAmount
        {
            get
            {
                return _insuranceCutEmployerAmount;
            }
            set
            {
                _insuranceCutEmployerAmount = value;
            }
        }

        /*Section="Field-UnemploymentPremiumWorkerAmount"*/
        [OTDisplayName("Unemployment Premium Worker Amount")]
        [DataMember]
        public Nullable<decimal> UnemploymentPremiumWorkerAmount
        {
            get
            {
                return _unemploymentPremiumWorkerAmount;
            }
            set
            {
                _unemploymentPremiumWorkerAmount = value;
            }
        }

        /*Section="Field-UnemploymentPremiumEmployerAmount"*/
        [OTDisplayName("Unemployment Premium Employer Amount")]
        [DataMember]
        public Nullable<decimal> UnemploymentPremiumEmployerAmount
        {
            get
            {
                return _unemploymentPremiumEmployerAmount;
            }
            set
            {
                _unemploymentPremiumEmployerAmount = value;
            }
        }

        /*Section="Field-StampTaxAmount"*/
        [OTDisplayName("Stamp Tax Amount")]
        [DataMember]
        public Nullable<decimal> StampTaxAmount
        {
            get
            {
                return _stampTaxAmount;
            }
            set
            {
                _stampTaxAmount = value;
            }
        }

        /*Section="Field-PreviousTaxAssessmentAmount"*/
        [OTDisplayName("Previous Tax Assessment Amount")]
        [DataMember]
        public Nullable<decimal> PreviousTaxAssessmentAmount
        {
            get
            {
                return _previousTaxAssessmentAmount;
            }
            set
            {
                _previousTaxAssessmentAmount = value;
            }
        }

        /*Section="Field-TaxAssessmentAmount"*/
        [OTDisplayName("Tax Assessment Amount")]
        [DataMember]
        public Nullable<decimal> TaxAssessmentAmount
        {
            get
            {
                return _taxAssessmentAmount;
            }
            set
            {
                _taxAssessmentAmount = value;
            }
        }

        /*Section="Field-IncomeTaxAmount"*/
        [OTDisplayName("Income Tax Amount")]
        [DataMember]
        public Nullable<decimal> IncomeTaxAmount
        {
            get
            {
                return _incomeTaxAmount;
            }
            set
            {
                _incomeTaxAmount = value;
            }
        }

        /*Section="Field-IncomeTaxRate"*/
        [OTDisplayName("Income Tax Rate")]
        [DataMember]
        public Nullable<decimal> IncomeTaxRate
        {
            get
            {
                return _incomeTaxRate;
            }
            set
            {
                _incomeTaxRate = value;
            }
        }

        /*Section="Field-TotalWithholdingAmount"*/
        [OTDisplayName("Total Withholding Amount")]
        [DataMember]
        public Nullable<decimal> TotalWithholdingAmount
        {
            get
            {
                return _totalWithholdingAmount;
            }
            set
            {
                _totalWithholdingAmount = value;
            }
        }

        /*Section="Field-MinimumLivingAllowanceAmount"*/
        [OTDisplayName("Minimum Living Allowance Amount")]
        [DataMember]
        public Nullable<decimal> MinimumLivingAllowanceAmount
        {
            get
            {
                return _minimumLivingAllowanceAmount;
            }
            set
            {
                _minimumLivingAllowanceAmount = value;
            }
        }

        /*Section="Field-NetAmount"*/
        [OTDisplayName("Net Amount")]
        [DataMember]
        public Nullable<decimal> NetAmount
        {
            get
            {
                return _netAmount;
            }
            set
            {
                _netAmount = value;
            }
        }

        /*Section="Field-TotalGrossRevenueAmount"*/
        [OTDisplayName("Total Gross Revenue Amount")]
        [DataMember]
        public Nullable<decimal> TotalGrossRevenueAmount
        {
            get
            {
                return _totalGrossRevenueAmount;
            }
            set
            {
                _totalGrossRevenueAmount = value;
            }
        }

        /*Section="Field-IncentiveShare5510Amount"*/
        [OTDisplayName("Incentive Share 5510 Amount")]
        [DataMember]
        public Nullable<decimal> IncentiveShare5510Amount
        {
            get
            {
                return _incentiveShare5510Amount;
            }
            set
            {
                _incentiveShare5510Amount = value;
            }
        }

        /*Section="Field-IncentiveShare6111Amount"*/
        [OTDisplayName("Incentive Share 6111 Amount")]
        [DataMember]
        public Nullable<decimal> IncentiveShare6111Amount
        {
            get
            {
                return _incentiveShare6111Amount;
            }
            set
            {
                _incentiveShare6111Amount = value;
            }
        }

        /*Section="Field-IncentiveShare2828Amount"*/
        [OTDisplayName("Incentive Share 2828 Amount")]
        [DataMember]
        public Nullable<decimal> IncentiveShare2828Amount
        {
            get
            {
                return _incentiveShare2828Amount;
            }
            set
            {
                _incentiveShare2828Amount = value;
            }
        }

        /*Section="Field-IncentiveShare27103Amount"*/
        [OTDisplayName("Incentive Share 27103 Amount")]
        [DataMember]
        public Nullable<decimal> IncentiveShare27103Amount
        {
            get
            {
                return _incentiveShare27103Amount;
            }
            set
            {
                _incentiveShare27103Amount = value;
            }
        }

        /*Section="Field-IncentiveShare14857Amount"*/
        [OTDisplayName("Incentive Share 14857 Amount")]
        [DataMember]
        public Nullable<decimal> IncentiveShare14857Amount
        {
            get
            {
                return _incentiveShare14857Amount;
            }
            set
            {
                _incentiveShare14857Amount = value;
            }
        }

        /*Section="Field-IncomeTaxIncentiveShareAmount"*/
        [OTDisplayName("Income Tax Incentive Share Amount")]
        [DataMember]
        public Nullable<decimal> IncomeTaxIncentiveShareAmount
        {
            get
            {
                return _incomeTaxIncentiveShareAmount;
            }
            set
            {
                _incomeTaxIncentiveShareAmount = value;
            }
        }

        /*Section="Field-UnemploymentIncentiveShareAmount"*/
        [OTDisplayName("Unemployment Incentive Share Amount")]
        [DataMember]
        public Nullable<decimal> UnemploymentIncentiveShareAmount
        {
            get
            {
                return _unemploymentIncentiveShareAmount;
            }
            set
            {
                _unemploymentIncentiveShareAmount = value;
            }
        }

        /*Section="Field-TaxIncentiveAmount"*/
        [OTDisplayName("Tax Incentive Amount")]
        [DataMember]
        public Nullable<decimal> TaxIncentiveAmount
        {
            get
            {
                return _taxIncentiveAmount;
            }
            set
            {
                _taxIncentiveAmount = value;
            }
        }

        [DataMember]
        public Nullable<decimal> SeverancePayAmount
        {
            get; set;
        }

        [DataMember]
        public Nullable<decimal> UnemploymentIncentive687Amount
        {
            get; set;
        }

        [DataMember]
        public Nullable<decimal> TotalInsurancePremAmount
        {
            get; set;
        }

        [DataMember]
        public Nullable<decimal> TotalUnemploymentPremAmount
        {
            get; set;
        }

        [DataMember]
        public Nullable<decimal> CashDeficitAmount
        {
            get; set;
        }
        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _payrollId;
        }


        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public string EmployeeName { get; set; }

        [DataMember]
        public string WorkingType { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime QuitDate { get; set; }

        [DataMember]
        public string DepartmentName { get; set; }

        [DataMember]
        public string ExpenseCenter { get; set; }

        [DataMember]
        public int IncentiveActCode { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}