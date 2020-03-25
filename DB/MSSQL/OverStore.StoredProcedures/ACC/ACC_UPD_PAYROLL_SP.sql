-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_PAYROLL_SP
    @PayrollId                           BIGINT,
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
    @CashDeficitAmount					 NUMERIC(22,6)
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_PAYROLL
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           EMPLOYEE = @Employee,
           YEAR_CD = @YearCode,
           MONTH_CD = @MonthCode,
           WORKINGDAY_CNT = @WorkingDay,
           WORKINGHOURS_AMT = @WorkingHours,
           PAY_AMT = @PayAmount,
           ANNUALLEAVEDAY_CNT = @AnnualLeave,
           ANNUALLEAVEHOURS_AMT = @AnnualLeaveHours,
           ANNUALLEAVEPAY_AMT = @AnnualLeavePay,
           PAIDLEAVEWEXCUSEDAY_CNT = @PaidLeavewithExcuseDayCount,
           PAIDLEAVEWEXCUSEHOURS_AMT = @PaidLeavewithExcuseHours,
           PAIDLEAVEWEXCUSEPAY_AMT = @PaidLeavewithExcusePayAmount,
           LEAVENOPAYWMEDREPDAY_CNT = @LeaveNoPaywithMedicalReportDayCount,
           LEAVENOPAYWMEDREPHOURS_AMT = @LeaveNoPaywithMedicalReportHours,
           LEAVENOPAYWOUTEXCUSEDAY_CNT = @LeaveNoPaywithoutExcuseDayCount,
           LEAVENOPAYWOUTEXCUSEHOURS_AMT = @LeaveNoPaywithoutExcuseHours,
           ABSENCEDAY_CNT = @AbsenceDayCount,
           ABSENCEHOURS_AMT = @AbsenceHours,
           LEGALHOLIDAYHOURS_AMT = @LegalHolidayHours,
           LEGALHOLIDAYPAY_AMT = @LegalHolidayPayAmount,
           OVERTIMEHOURS_AMT = @OvertimeHours,
           OVERTIMEPAY_AMT = @OvertimePayAmount,
           CASHINDEMNITY_AMT = @CashIndemnityAmount,
           FOODALLOWANCE_AMT = @FoodAllowanceAmount,
           FOODALLOWANCEDAY_CNT = @FoodAllowanceDayCount,
           LEAVEPAY_AMT = @LeavePayAmount,
           ADVANCE_AMT = @AdvanceAmount,
           PAYCUT_AMT = @PayCutAmount,
           INSTALLMENTPAYCUT_AMT = @InstallmentPayCutAmount,
           INSURANCECUT_AMT = @InsuranceCutAmount,
           ALIMONYCUT_AMT = @AlimonyCutAmount,
           EXECUTIONDEDUCTION1_AMT = @ExecutionDeduction1Amount,
           EXECUTIONDEDUCTION2_AMT = @ExecutionDeduction2Amount,
           EXECUTIONDEDUCTION3_AMT = @ExecutionDeduction3Amount,
           INSURANCEDAY_CNT = @InsuranceDayCount,
           ASSESSMENT_AMT = @AssessmentAmount,
           INSURANCECUTWORKER_AMT = @InsuranceCutWorkerAmount,
           INSURANCECUTEMPLOYER_AMT = @InsuranceCutEmployerAmount,
           UNEMPLOYMENTPREMIUMWORKER_AMT = @UnemploymentPremiumWorkerAmount,
           UNEMPLOYMENTPREMIUMEMPLOYER_AMT = @UnemploymentPremiumEmployerAmount,
           STAMPTAX_AMT = @StampTaxAmount,
           PREVTAXASSESSMENT_AMT = @PreviousTaxAssessmentAmount,
           TAXASSESSMENT_AMT = @TaxAssessmentAmount,
           INCOMETAX_AMT = @IncomeTaxAmount,
           INCOMETAX_RT = @IncomeTaxRate,
           TOTALWITHHOLDING_AMT = @TotalWithholdingAmount,
           MINLIVINGALLOWANCE_AMT = @MinimumLivingAllowanceAmount,
           NET_AMT = @NetAmount,
           TOTALGROSSREVENUE_AMT = @TotalGrossRevenueAmount,
           INCENTIVESHARE5510_AMT = @IncentiveShare5510Amount,
           INCENTIVESHARE6111_AMT = @IncentiveShare6111Amount,
           INCENTIVESHARE2828_AMT = @IncentiveShare2828Amount,
           INCENTIVESHARE27103_AMT = @IncentiveShare27103Amount,
           INCENTIVESHARE14857_AMT = @IncentiveShare14857Amount,
           INCOMETAXINCENTIVESHARE_AMT = @IncomeTaxIncentiveShareAmount,
           UNEMPLOYMENTINCENTIVESHARE_AMT = @UnemploymentIncentiveShareAmount,
		   TAXINCENTIVE_AMT = @TaxIncentiveAmount,
           CASHDEFICIT_AMT = @CashDeficitAmount
     WHERE PAYROLLID = @PayrollId     
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
