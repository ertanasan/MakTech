-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_EXPENSE_SP
    @ExpenseId            BIGINT OUT,
    @Event                INT,
    @Organization         INT,
    @ExpenseType          INT,
    @Store                INT,
    @ExpenseDate          DATETIME,
    @ExpenseAmount        NUMERIC(22,6),
    @ReceiptNo            VARCHAR(100),
    @OpenFlag             VARCHAR(1),
    @PayOffDate           DATETIME,
    @ExpenseDescription   VARCHAR(1000),
    @VATRate              NUMERIC(4,2),
    @MikroTransactionCode INT,
    @MikroTime            DATETIME,
    @StatusCode           INT,
    @StatusText           VARCHAR(1000),
    @MikroUser            INT,
    @HasReceipt           VARCHAR(1),
    @RegionManager        INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_EXPENSE
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        EXPENSETYPE,
        STORE,
        EXPENSE_DT,
        EXPENSE_AMT,
        RECEIPTNO_TXT,
        OPEN_FL,
        PAYOFF_DT,
        EXPENSE_DSC,
        VAT_RT,
        MIKRO_CD,
        MIKRO_TM,
        STATUS_CD,
        STATUS_TXT,
        MIKROUSER,
        HASRECEIPT_FL,
        REGIONMANAGER
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
        @ExpenseType,
        @Store,
        CAST(@ExpenseDate AS DATE),
        @ExpenseAmount,
        @ReceiptNo,
        @OpenFlag,
        CASE WHEN @OpenFlag = 'Y' THEN NULL ELSE CAST(@PayOffDate AS DATE) END ,
        @ExpenseDescription,
        @VATRate,
        @MikroTransactionCode,
        @MikroTime,
        @StatusCode,
        @StatusText,
        @MikroUser,
        @HasReceipt,
        @RegionManager
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
    SELECT @ExpenseId = SCOPE_IDENTITY();
/*Section="End"*/
END;
