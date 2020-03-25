CREATE PROCEDURE RCL_INS_RECONCILIATION_SP
    @StoreReconciliationId BIGINT OUT,
    @Event                 INT,
    @Organization          INT,
    @TransactionDate       DATETIME,
    @StoreID               INT,
    @PreviousDayAmount     NUMERIC(22,6),
    @SaleTotal             NUMERIC(22,6),
    @CashTotal             NUMERIC(22,6),
    @CardTotal             NUMERIC(22,6),
    @ToBank                NUMERIC(22,6),
    @Difference            NUMERIC(22,6),
    @DifferenceExplanation VARCHAR(1000),
    @Completed             NUMERIC(22,6),
    @EodAdvance            NUMERIC(22,6),
    @Reconciliated         VARCHAR(1),
    @Approved              VARCHAR(1)
AS
BEGIN

	DECLARE @Count INT;

	SELECT @Count = COUNT(RECONCILIATIONID) FROM RCL_RECONCILIATION (NOLOCK) 
	WHERE STORE = @StoreID 
		AND TRANSACTION_DT = @TransactionDate 
		AND DELETED_FL = 'N';

	IF @Count > 0 
		RAISERROR ('Bu tarih için mutabakat kaydı zaten var. Lütfen işleme baştan başlayınız.', 16, 1);


    SET NOCOUNT OFF

    INSERT INTO RCL_RECONCILIATION
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        TRANSACTION_DT,
        STORE,
        PREVIOUSDAYADVANCE_AMT,
        SALETOTAL_AMT,
        CASHTOTAL_AMT,
        CARDTOTAL_AMT,
        TOBANK_AMT,
        DIFFERENCE_AMT,
        DIFFERENCE_DSC,
        COMPLETED_AMT,
        EODADVANCE_AMT,
        RECONCILIATED_FL,
        APPROVED_FL
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
        @TransactionDate,
        @StoreID,
        @PreviousDayAmount,
        @SaleTotal,
        @CashTotal,
        @CardTotal,
        @ToBank,
        @Difference,
        @DifferenceExplanation,
        @Completed,
        @EodAdvance,
        @Reconciliated,
        @Approved
    );

    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @StoreReconciliationId = SCOPE_IDENTITY();
END;
