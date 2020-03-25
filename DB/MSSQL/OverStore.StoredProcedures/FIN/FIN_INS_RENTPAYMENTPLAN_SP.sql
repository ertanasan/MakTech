-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_INS_RENTPAYMENTPLAN_SP
    @RentPaymentPlanId         INT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO FIN_RENTPAYMENTPLAN
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        ESTATERENTPERIOD,
        PAYMENTORDER_NO,
        DUE_DT,
        PAYMENT_AMT,
        CURRENCY_TXT,
        ADDITIONALPAYMENT_AMT,
        ADDPAYMENTCURRENCY_TXT,
        COMMENT_DSC
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @RentPeriod,
        @PaymentOrder,
        @DueDate,
        @PaymentAmount,
        @Currency,
        @AdditionalPaymentAmount,
        @AdditionalPaymentCurrency,
        @Comment
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
    SELECT @RentPaymentPlanId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @RentPaymentPlanId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @RentPeriod,
        @PaymentOrder,
        @DueDate,
        @PaymentAmount,
        @Currency,
        @AdditionalPaymentAmount,
        @AdditionalPaymentCurrency,
        @Comment);
/*Section="End"*/
END;
