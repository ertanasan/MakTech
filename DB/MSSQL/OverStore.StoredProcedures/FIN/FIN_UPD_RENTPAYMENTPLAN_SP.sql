-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_UPD_RENTPAYMENTPLAN_SP
    @RentPaymentPlanId         INT,
    @RentPeriod                INT,
    @PaymentOrder              INT,
    @DueDate                   DATETIME,
    @PaymentAmount             NUMERIC(22,6),
    @Currency                  VARCHAR(3),
    @AdditionalPaymentAmount   NUMERIC(22,6),
    @AdditionalPaymentCurrency VARCHAR(3),
    @Comment                   VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO FIN_RENTPAYMENTPLANLOG
    (
        RENTPAYMENTPLANID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ESTATERENTPERIOD,
        PAYMENTORDER_NO,
        DUE_DT,
        PAYMENT_AMT,
        CURRENCY_TXT,
        ADDITIONALPAYMENT_AMT,
        ADDPAYMENTCURRENCY_TXT,
        COMMENT_DSC
    )
    SELECT
        RENTPAYMENTPLANID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ESTATERENTPERIOD,
        PAYMENTORDER_NO,
        DUE_DT,
        PAYMENT_AMT,
        CURRENCY_TXT,
        ADDITIONALPAYMENT_AMT,
        ADDPAYMENTCURRENCY_TXT,
        COMMENT_DSC
      FROM
        FIN_RENTPAYMENTPLAN R (NOLOCK)
     WHERE
        R.RENTPAYMENTPLANID = @RentPaymentPlanId;
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE FIN_RENTPAYMENTPLAN
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           ESTATERENTPERIOD = @RentPeriod,
           PAYMENTORDER_NO = @PaymentOrder,
           DUE_DT = @DueDate,
           PAYMENT_AMT = @PaymentAmount,
           CURRENCY_TXT = @Currency,
           ADDITIONALPAYMENT_AMT = @AdditionalPaymentAmount,
           ADDPAYMENTCURRENCY_TXT = @AdditionalPaymentCurrency,
           COMMENT_DSC = @Comment
     WHERE RENTPAYMENTPLANID = @RentPaymentPlanId
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
