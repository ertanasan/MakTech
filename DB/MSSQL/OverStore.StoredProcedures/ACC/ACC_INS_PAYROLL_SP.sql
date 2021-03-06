﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_PAYROLL_SP
    @PayrollId                           BIGINT OUT,
    @Event                               INT,
    @Organization                        INT,
    @Employee                            INT,
    @YearCode                            INT,
    @MonthCode                           INT,
    @WorkingDay                          INT,
    @WorkingHours                        NUMERIC(10,2),
    @PayAmount                           NUMERIC(22,6),
    @AnnualLeave                         INT,
    @AnnualLeaveHours                    NUMERIC(10,2),
    @AnnualLeavePay                      NUMERIC(22,6),
    @PaidLeavewithExcuseDayCount         INT,
    @PaidLeavewithExcuseHours            NUMERIC(10,2),
    @PaidLeavewithExcusePayAmount        NUMERIC(22,6),
    @LeaveNoPaywithMedicalReportDayCount INT,
    @LeaveNoPaywithMedicalReportHours    NUMERIC(10,2),
    @LeaveNoPaywithoutExcuseDayCount     INT,
    @LeaveNoPaywithoutExcuseHours        NUMERIC(10,2),
    @AbsenceDayCount                     INT,
    @AbsenceHours                        NUMERIC(10,2),
    @LegalHolidayHours                   NUMERIC(10,2),
    @LegalHolidayPayAmount               NUMERIC(22,6),
    @OvertimeHours                       NUMERIC(10,2),
    @OvertimePayAmount                   NUMERIC(22,6),
    @CashIndemnityAmount                 NUMERIC(22,6),
    @FoodAllowanceAmount                 NUMERIC(22,6),
    @FoodAllowanceDayCount               INT,
    @LeavePayAmount                      NUMERIC(22,6),
    @AdvanceAmount                       NUMERIC(22,6),
    @PayCutAmount                        NUMERIC(22,6),
    @InstallmentPayCutAmount             NUMERIC(22,6),
    @InsuranceCutAmount                  NUMERIC(22,6),
    @AlimonyCutAmount                    NUMERIC(22,6),
    @ExecutionDeduction1Amount           NUMERIC(22,6),
    @ExecutionDeduction2Amount           NUMERIC(22,6),
    @ExecutionDeduction3Amount           NUMERIC(22,6),
    @InsuranceDayCount                   INT,
    @AssessmentAmount                    NUMERIC(22,6),
    @InsuranceCutWorkerAmount            NUMERIC(22,6),
    @InsuranceCutEmployerAmount          NUMERIC(22,6),
    @UnemploymentPremiumWorkerAmount     NUMERIC(22,6),
    @UnemploymentPremiumEmployerAmount   NUMERIC(22,6),
    @StampTaxAmount                      NUMERIC(22,6),
    @PreviousTaxAssessmentAmount         NUMERIC(22,6),
    @TaxAssessmentAmount                 NUMERIC(22,6),
    @IncomeTaxAmount                     NUMERIC(22,6),
    @IncomeTaxRate                       NUMERIC(4,2),
    @TotalWithholdingAmount              NUMERIC(22,6),
    @MinimumLivingAllowanceAmount        NUMERIC(22,6),
    @NetAmount                           NUMERIC(22,6),
    @TotalGrossRevenueAmount             NUMERIC(22,6),
    @IncentiveShare5510Amount            NUMERIC(22,6),
    @IncentiveShare6111Amount            NUMERIC(22,6),
    @IncentiveShare2828Amount            NUMERIC(22,6),
    @IncentiveShare27103Amount           NUMERIC(22,6),
    @IncentiveShare14857Amount           NUMERIC(22,6),
    @IncomeTaxIncentiveShareAmount       NUMERIC(22,6),
    @UnemploymentIncentiveShareAmount    NUMERIC(22,6),
	@TaxIncentiveAmount					 NUMERIC(22,6),
	@SeverancePayAmount					 NUMERIC(22,6), -- SEVERANCEPAY_AMT
	@UnemploymentIncentive687Amount		 NUMERIC(22,6), -- UNEMPLOYMENTINCENTIVE687_AMT
	@TotalInsurancePremAmount			 NUMERIC(22,6), -- TOTALINSURANCEPREM_AMT
	@TotalUnemploymentPremAmount		 NUMERIC(22,6), -- TOTALUNEMPLOYMENTPREM_AMT
    @CashDeficitAmount                   NUMERIC(22,6)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_PAYROLL
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        EMPLOYEE,
        YEAR_CD,
        MONTH_CD,
        WORKINGDAY_CNT,
        WORKINGHOURS_AMT,
        PAY_AMT,
        ANNUALLEAVEDAY_CNT,
        ANNUALLEAVEHOURS_AMT,
        ANNUALLEAVEPAY_AMT,
        PAIDLEAVEWEXCUSEDAY_CNT,
        PAIDLEAVEWEXCUSEHOURS_AMT,
        PAIDLEAVEWEXCUSEPAY_AMT,
        LEAVENOPAYWMEDREPDAY_CNT,
        LEAVENOPAYWMEDREPHOURS_AMT,
        LEAVENOPAYWOUTEXCUSEDAY_CNT,
        LEAVENOPAYWOUTEXCUSEHOURS_AMT,
        ABSENCEDAY_CNT,
        ABSENCEHOURS_AMT,
        LEGALHOLIDAYHOURS_AMT,
        LEGALHOLIDAYPAY_AMT,
        OVERTIMEHOURS_AMT,
        OVERTIMEPAY_AMT,
        CASHINDEMNITY_AMT,
        FOODALLOWANCE_AMT,
        FOODALLOWANCEDAY_CNT,
        LEAVEPAY_AMT,
        ADVANCE_AMT,
        PAYCUT_AMT,
        INSTALLMENTPAYCUT_AMT,
        INSURANCECUT_AMT,
        ALIMONYCUT_AMT,
        EXECUTIONDEDUCTION1_AMT,
        EXECUTIONDEDUCTION2_AMT,
        EXECUTIONDEDUCTION3_AMT,
        INSURANCEDAY_CNT,
        ASSESSMENT_AMT,
        INSURANCECUTWORKER_AMT,
        INSURANCECUTEMPLOYER_AMT,
        UNEMPLOYMENTPREMIUMWORKER_AMT,
        UNEMPLOYMENTPREMIUMEMPLOYER_AMT,
        STAMPTAX_AMT,
        PREVTAXASSESSMENT_AMT,
        TAXASSESSMENT_AMT,
        INCOMETAX_AMT,
        INCOMETAX_RT,
        TOTALWITHHOLDING_AMT,
        MINLIVINGALLOWANCE_AMT,
        NET_AMT,
        TOTALGROSSREVENUE_AMT,
        INCENTIVESHARE5510_AMT,
        INCENTIVESHARE6111_AMT,
        INCENTIVESHARE2828_AMT,
        INCENTIVESHARE27103_AMT,
        INCENTIVESHARE14857_AMT,
        INCOMETAXINCENTIVESHARE_AMT,
        UNEMPLOYMENTINCENTIVESHARE_AMT,
		TAXINCENTIVE_AMT,
		SEVERANCEPAY_AMT,
		UNEMPLOYMENTINCENTIVE687_AMT,
		TOTALINSURANCEPREM_AMT,
		TOTALUNEMPLOYMENTPREM_AMT,
        CASHDEFICIT_AMT
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Employee,
        @YearCode,
        @MonthCode,
        @WorkingDay,
        @WorkingHours,
        @PayAmount,
        @AnnualLeave,
        @AnnualLeaveHours,
        @AnnualLeavePay,
        @PaidLeavewithExcuseDayCount,
        @PaidLeavewithExcuseHours,
        @PaidLeavewithExcusePayAmount,
        @LeaveNoPaywithMedicalReportDayCount,
        @LeaveNoPaywithMedicalReportHours,
        @LeaveNoPaywithoutExcuseDayCount,
        @LeaveNoPaywithoutExcuseHours,
        @AbsenceDayCount,
        @AbsenceHours,
        @LegalHolidayHours,
        @LegalHolidayPayAmount,
        @OvertimeHours,
        @OvertimePayAmount,
        @CashIndemnityAmount,
        @FoodAllowanceAmount,
        @FoodAllowanceDayCount,
        @LeavePayAmount,
        @AdvanceAmount,
        @PayCutAmount,
        @InstallmentPayCutAmount,
        @InsuranceCutAmount,
        @AlimonyCutAmount,
        @ExecutionDeduction1Amount,
        @ExecutionDeduction2Amount,
        @ExecutionDeduction3Amount,
        @InsuranceDayCount,
        @AssessmentAmount,
        @InsuranceCutWorkerAmount,
        @InsuranceCutEmployerAmount,
        @UnemploymentPremiumWorkerAmount,
        @UnemploymentPremiumEmployerAmount,
        @StampTaxAmount,
        @PreviousTaxAssessmentAmount,
        @TaxAssessmentAmount,
        @IncomeTaxAmount,
        @IncomeTaxRate,
        @TotalWithholdingAmount,
        @MinimumLivingAllowanceAmount,
        @NetAmount,
        @TotalGrossRevenueAmount,
        @IncentiveShare5510Amount,
        @IncentiveShare6111Amount,
        @IncentiveShare2828Amount,
        @IncentiveShare27103Amount,
        @IncentiveShare14857Amount,
        @IncomeTaxIncentiveShareAmount,
        @UnemploymentIncentiveShareAmount,
		@TaxIncentiveAmount,
		@SeverancePayAmount,
		@UnemploymentIncentive687Amount,
		@TotalInsurancePremAmount,
		@TotalUnemploymentPremAmount,
        @CashDeficitAmount
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @PayrollId = SCOPE_IDENTITY();
/*Section="End"*/
END;
