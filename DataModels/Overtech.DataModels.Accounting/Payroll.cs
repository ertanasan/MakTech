// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Accounting
{
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "PAYROLL", HasAutoIdentity = true, DisplayName = "Payroll", IdField = "PayrollId")]
    [DataContract]
    public class Payroll : DataModelObject
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
        [OTDataField("PAYROLLID")]
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
        [OTDataField("EVENT")]
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
        [OTDataField("ORGANIZATION")]
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
        [OTDataField("DELETED_FL")]
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
        [OTDataField("CREATE_DT")]
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
        [OTDataField("UPDATE_DT", Nullable = true)]
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
        [OTDataField("CREATEUSER")]
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
        [OTDataField("UPDATEUSER", Nullable = true)]
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
        [OTDataField("CREATECHANNEL")]
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
        [OTDataField("CREATEBRANCH")]
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
        [OTDataField("CREATESCREEN")]
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
        [OTDataField("EMPLOYEE")]
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
        [OTDataField("YEAR_CD")]
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
        [OTDataField("MONTH_CD")]
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
        [OTDataField("WORKINGDAY_CNT", Nullable = true)]
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
        [OTDataField("WORKINGHOURS_AMT", Nullable = true)]
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
        [OTDataField("PAY_AMT", Nullable = true)]
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
        [OTDataField("ANNUALLEAVEDAY_CNT", Nullable = true)]
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
        [OTDataField("ANNUALLEAVEHOURS_AMT", Nullable = true)]
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
        [OTDataField("ANNUALLEAVEPAY_AMT", Nullable = true)]
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
        [OTDataField("PAIDLEAVEWEXCUSEDAY_CNT", Nullable = true)]
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
        [OTDataField("PAIDLEAVEWEXCUSEHOURS_AMT", Nullable = true)]
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
        [OTDataField("PAIDLEAVEWEXCUSEPAY_AMT", Nullable = true)]
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
        [OTDataField("LEAVENOPAYWMEDREPDAY_CNT", Nullable = true)]
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
        [OTDataField("LEAVENOPAYWMEDREPHOURS_AMT", Nullable = true)]
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
        [OTDataField("LEAVENOPAYWOUTEXCUSEDAY_CNT", Nullable = true)]
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
        [OTDataField("LEAVENOPAYWOUTEXCUSEHOURS_AMT", Nullable = true)]
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
        [OTDataField("ABSENCEDAY_CNT", Nullable = true)]
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
        [OTDataField("ABSENCEHOURS_AMT", Nullable = true)]
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
        [OTDataField("LEGALHOLIDAYHOURS_AMT", Nullable = true)]
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
        [OTDataField("LEGALHOLIDAYPAY_AMT", Nullable = true)]
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
        [OTDataField("OVERTIMEHOURS_AMT", Nullable = true)]
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
        [OTDataField("OVERTIMEPAY_AMT", Nullable = true)]
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
        [OTDataField("CASHINDEMNITY_AMT", Nullable = true)]
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
        [OTDataField("FOODALLOWANCE_AMT", Nullable = true)]
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
        [OTDataField("FOODALLOWANCEDAY_CNT", Nullable = true)]
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
        [OTDataField("LEAVEPAY_AMT", Nullable = true)]
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
        [OTDataField("ADVANCE_AMT", Nullable = true)]
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
        [OTDataField("PAYCUT_AMT", Nullable = true)]
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
        [OTDataField("INSTALLMENTPAYCUT_AMT", Nullable = true)]
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
        [OTDataField("INSURANCECUT_AMT", Nullable = true)]
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
        [OTDataField("ALIMONYCUT_AMT", Nullable = true)]
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
        [OTDataField("EXECUTIONDEDUCTION1_AMT", Nullable = true)]
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
        [OTDataField("EXECUTIONDEDUCTION2_AMT", Nullable = true)]
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
        [OTDataField("EXECUTIONDEDUCTION3_AMT", Nullable = true)]
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
        [OTDataField("INSURANCEDAY_CNT", Nullable = true)]
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
        [OTDataField("ASSESSMENT_AMT", Nullable = true)]
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
        [OTDataField("INSURANCECUTWORKER_AMT", Nullable = true)]
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
        [OTDataField("INSURANCECUTEMPLOYER_AMT", Nullable = true)]
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
        [OTDataField("UNEMPLOYMENTPREMIUMWORKER_AMT", Nullable = true)]
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
        [OTDataField("UNEMPLOYMENTPREMIUMEMPLOYER_AMT", Nullable = true)]
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
        [OTDataField("STAMPTAX_AMT", Nullable = true)]
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
        [OTDataField("PREVTAXASSESSMENT_AMT", Nullable = true)]
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
        [OTDataField("TAXASSESSMENT_AMT", Nullable = true)]
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
        [OTDataField("INCOMETAX_AMT", Nullable = true)]
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
        [OTDataField("INCOMETAX_RT", Nullable = true)]
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
        [OTDataField("TOTALWITHHOLDING_AMT", Nullable = true)]
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
        [OTDataField("MINLIVINGALLOWANCE_AMT", Nullable = true)]
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
        [OTDataField("NET_AMT", Nullable = true)]
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
        [OTDataField("TOTALGROSSREVENUE_AMT", Nullable = true)]
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
        [OTDataField("INCENTIVESHARE5510_AMT", Nullable = true)]
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
        [OTDataField("INCENTIVESHARE6111_AMT", Nullable = true)]
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
        [OTDataField("INCENTIVESHARE2828_AMT", Nullable = true)]
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
        [OTDataField("INCENTIVESHARE27103_AMT", Nullable = true)]
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
        [OTDataField("INCENTIVESHARE14857_AMT", Nullable = true)]
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
        [OTDataField("INCOMETAXINCENTIVESHARE_AMT", Nullable = true)]
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
        [OTDataField("UNEMPLOYMENTINCENTIVESHARE_AMT", Nullable = true)]
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
        [OTDataField("TAXINCENTIVE_AMT", Nullable = true)]
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

        [OTDataField("SEVERANCEPAY_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> SeverancePayAmount
        {
            get; set;
        }

        [OTDataField("UNEMPLOYMENTINCENTIVE687_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> UnemploymentIncentive687Amount
        {
            get; set;
        }

        [OTDataField("TOTALINSURANCEPREM_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> TotalInsurancePremAmount
        {
            get; set;
        }

        [OTDataField("TOTALUNEMPLOYMENTPREM_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> TotalUnemploymentPremAmount
        {
            get; set;
        }

        [OTDataField("CASHDEFICIT_AMT", Nullable = true)]
        [DataMember]
        public Nullable<decimal> CashDeficitAmount
        {
            get; set;
        }


        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _payrollId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("EMPLOYEE_NM", IsExtended = true)]
        [DataMember]
        public string EmployeeName { get; set; }

        [OTDataField("WORKINGTYPE_DSC", IsExtended = true)]
        [DataMember]
        public string WorkingType { get; set; }

        [OTDataField("START_DT", IsExtended = true)]
        [DataMember]
        public DateTime StartDate { get; set; }

        [OTDataField("QUIT_DT", IsExtended = true)]
        [DataMember]
        public DateTime QuitDate { get; set; }

        [OTDataField("DEPARTMENT_NM", IsExtended = true)]
        [DataMember]
        public string DepartmentName { get; set; }

        [OTDataField("EXPENSECENTER_TXT", IsExtended = true)]
        [DataMember]
        public string ExpenseCenter { get; set; }

        [OTDataField("INCENTIVEACT_CD", IsExtended = true)]
        [DataMember]
        public int IncentiveActCode { get; set; }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

