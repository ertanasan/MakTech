﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_PAYROLL_SP
    @PayrollId BIGINT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Query"*/
    -- Select
    SELECT
           P.PAYROLLID,
           P.EVENT,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.CREATECHANNEL,
           P.CREATEBRANCH,
           P.CREATESCREEN,
           P.EMPLOYEE,
           P.YEAR_CD,
           P.MONTH_CD,
           P.WORKINGDAY_CNT,
           P.WORKINGHOURS_AMT,
           P.PAY_AMT,
           P.ANNUALLEAVEDAY_CNT,
           P.ANNUALLEAVEHOURS_AMT,
           P.ANNUALLEAVEPAY_AMT,
           P.PAIDLEAVEWEXCUSEDAY_CNT,
           P.PAIDLEAVEWEXCUSEHOURS_AMT,
           P.PAIDLEAVEWEXCUSEPAY_AMT,
           P.LEAVENOPAYWMEDREPDAY_CNT,
           P.LEAVENOPAYWMEDREPHOURS_AMT,
           P.LEAVENOPAYWOUTEXCUSEDAY_CNT,
           P.LEAVENOPAYWOUTEXCUSEHOURS_AMT,
           P.ABSENCEDAY_CNT,
           P.ABSENCEHOURS_AMT,
           P.LEGALHOLIDAYHOURS_AMT,
           P.LEGALHOLIDAYPAY_AMT,
           P.OVERTIMEHOURS_AMT,
           P.OVERTIMEPAY_AMT,
           P.CASHINDEMNITY_AMT,
           P.FOODALLOWANCE_AMT,
           P.FOODALLOWANCEDAY_CNT,
           P.LEAVEPAY_AMT,
           P.ADVANCE_AMT,
           P.PAYCUT_AMT,
           P.INSTALLMENTPAYCUT_AMT,
           P.INSURANCECUT_AMT,
           P.ALIMONYCUT_AMT,
           P.EXECUTIONDEDUCTION1_AMT,
           P.EXECUTIONDEDUCTION2_AMT,
           P.EXECUTIONDEDUCTION3_AMT,
           P.INSURANCEDAY_CNT,
           P.ASSESSMENT_AMT,
           P.INSURANCECUTWORKER_AMT,
           P.INSURANCECUTEMPLOYER_AMT,
           P.UNEMPLOYMENTPREMIUMWORKER_AMT,
           P.UNEMPLOYMENTPREMIUMEMPLOYER_AMT,
           P.STAMPTAX_AMT,
           P.PREVTAXASSESSMENT_AMT,
           P.TAXASSESSMENT_AMT,
           P.INCOMETAX_AMT,
           P.INCOMETAX_RT,
           P.TOTALWITHHOLDING_AMT,
           P.MINLIVINGALLOWANCE_AMT,
           P.NET_AMT,
           P.TOTALGROSSREVENUE_AMT,
           P.INCENTIVESHARE5510_AMT,
           P.INCENTIVESHARE6111_AMT,
           P.INCENTIVESHARE2828_AMT,
           P.INCENTIVESHARE27103_AMT,
           P.INCENTIVESHARE14857_AMT,
           P.INCOMETAXINCENTIVESHARE_AMT,
           P.UNEMPLOYMENTINCENTIVESHARE_AMT,
		   P.TAXINCENTIVE_AMT,
           P.CASHDEFICIT_AMT
      FROM ACC_PAYROLL P (NOLOCK)
     WHERE P.PAYROLLID = @PayrollId     
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
