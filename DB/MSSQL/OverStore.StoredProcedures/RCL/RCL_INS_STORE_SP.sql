CREATE PROCEDURE RCL_INS_STORE_SP
    @StoreReconciliationId BIGINT OUT,
    @Event                 INT,
    @Organization          INT,
    @Store                 INT,
    @ReconciliationDate    DATETIME,
    @ZetAmount             NUMERIC(22,6),
    @DefinedAdvance        NUMERIC(22,6),
    @ExpenseAmount         NUMERIC(22,6),
    @CashAmount            NUMERIC(22,6),
    @CardAmount            NUMERIC(22,6),
    @RecoveredAmount       NUMERIC(22,6),
    @AdjustmentAmount      NUMERIC(22,6),
    @NetoffAmount          NUMERIC(22,6),
    @BankAmount            NUMERIC(22,6),
    @CurrentAdvance        NUMERIC(22,6),
    @ExpenseReturn         NUMERIC(22,6),
    @DiffReasonCodes       VARCHAR(300),
    @DiffReason            VARCHAR(500),
    @LastStepNo            INT,
    @CompleteFlag          VARCHAR(1),
    @AdjustmentReason      VARCHAR(300),
    @DeficitCycleCount     INT
AS
BEGIN
    SET NOCOUNT OFF

	DECLARE @Control INT
	SELECT @Control = COUNT(*)
	  FROM RCL_STORE
	 WHERE STORE = @Store
	   AND RECONCILIATION_DT = CAST(@ReconciliationDate AS DATE)
	   AND DELETED_FL = 'N'

	IF @Control > 0
	BEGIN
	  RAISERROR ('Bu tarih için mutabakat kaydı zaten var. Lütfen işleme baştan başlayınız.', 16, 1);
	END

    INSERT INTO RCL_STORE
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STORE,
        RECONCILIATION_DT,
        ZET_AMT,
        DEFINEDADVANCE_AMT,
        EXPENSE_AMT,
        CASH_AMT,
        CARD_AMT,
        RECOVERED_AMT,
        ADJUSTMENT_AMT,
        NETOFF_AMT,
        BANK_AMT,
        CURRENTADVANCE_AMT,
        EXPENSERETURN_AMT,
        DIFFREASONCODES_TXT,
        DIFFREASON_TXT,
        LASTSTEP_NO,
        COMPLETE_FL,
		ADJUSTMENT_DSC,
        DEFICITCYCLE_CNT
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
        @Store,
        CAST(@ReconciliationDate AS DATE),
        @ZetAmount,
        @DefinedAdvance,
        @ExpenseAmount,
        @CashAmount,
        @CardAmount,
        @RecoveredAmount,
        @AdjustmentAmount,
        @NetoffAmount,
        @BankAmount,
        @CurrentAdvance,
        @ExpenseReturn,
        @DiffReasonCodes,
        @DiffReason,
        @LastStepNo,
        @CompleteFlag,
		@AdjustmentReason,
		@DeficitCycleCount
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
