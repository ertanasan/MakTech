CREATE PROCEDURE ACC_INS_BANKPOSTRAN_SP
    @BankPosTransactionsId BIGINT OUT,
    @Event                 INT,
    @Organization          INT,
    @Bank                  INT,
    @StoreRef              VARCHAR(100),
    @PosRef                VARCHAR(100),
    @BlockedDate           DATETIME,
    @ValueDate             DATETIME,
    @Quantity              INT,
    @CreditAmount          NUMERIC(22,6),
    @DebitAmount           NUMERIC(22,6),
    @CommissionAmount      NUMERIC(22,6),
    @MikroTransferTime     DATETIME,
    @MikroStatusCode       INT,
    @MikroTransactionCode  VARCHAR(100)
AS
BEGIN
    SET NOCOUNT OFF

    -- Insert record
    INSERT INTO ACC_BANKPOSTRAN
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        BANK,
        STOREREF_TXT,
        POSREF_TXT,
        BLOCKED_DT,
        VALUE_DT,
        QUANTITY_QTY,
        CREDIT_AMT,
        DEBIT_AMT,
        COMMISSION_AMT,
        MIKRO_TM,
        MIKROSTATUS_CD,
        MIKROTRANCODE_TXT
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
        @Bank,
        @StoreRef,
        @PosRef,
        @BlockedDate,
        @ValueDate,
        @Quantity,
        @CreditAmount,
        @DebitAmount,
        @CommissionAmount,
        @MikroTransferTime,
        @MikroStatusCode,
        @MikroTransactionCode
    );

    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @BankPosTransactionsId = SCOPE_IDENTITY();

END;
