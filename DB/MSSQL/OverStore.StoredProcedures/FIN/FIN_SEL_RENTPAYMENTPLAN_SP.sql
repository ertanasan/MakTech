-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_SEL_RENTPAYMENTPLAN_SP
    @RentPaymentPlanId INT
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
           R.RENTPAYMENTPLANID,
           R.ORGANIZATION,
           R.DELETED_FL,
           R.CREATE_DT,
           R.UPDATE_DT,
           R.CREATEUSER,
           R.UPDATEUSER,
           R.ESTATERENTPERIOD,
           R.PAYMENTORDER_NO,
           R.DUE_DT,
           R.PAYMENT_AMT,
           R.CURRENCY_TXT,
           R.ADDITIONALPAYMENT_AMT,
           R.ADDPAYMENTCURRENCY_TXT,
           R.COMMENT_DSC
      FROM FIN_RENTPAYMENTPLAN R (NOLOCK)
     WHERE R.RENTPAYMENTPLANID = @RentPaymentPlanId
       AND (@Organization IS NULL OR R.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
