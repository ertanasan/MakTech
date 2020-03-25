CREATE PROCEDURE RCL_UPD_STORE_SP
    @StoreReconciliationId BIGINT,
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
    -- şube ise ve update edilecek adım numarası, mevcut adımdan büyük değilse hata ver. 
    DECLARE @ParallelRunControl INT
    IF dbo.[SYS_GETCURRENTBRANCHTYPE_FN]() = 'Branch' 
    BEGIN
        SELECT @ParallelRunControl = COUNT(*)
          FROM RCL_STORE
         WHERE STORERECID = @StoreReconciliationId
           AND LASTSTEP_NO >= @LastStepNo
           AND @LastStepNo != 6 -- kredi kart adımına geri dönebilmek için

        IF @ParallelRunControl > 0 
        BEGIN
            RAISERROR ('Mutabakat sürecinde geri dönemezsiniz.',16, 1);
        END
    END
    
    INSERT INTO RCL_STORELOG
    (
        STORERECID, LOG_DT, LOGUSER, LOGOPERATION_CD, LOGCHANNEL, LOGBRANCH, LOGSCREEN, STORE, RECONCILIATION_DT
	  , ZET_AMT, DEFINEDADVANCE_AMT, EXPENSE_AMT, CASH_AMT, CARD_AMT, RECOVERED_AMT, ADJUSTMENT_AMT, NETOFF_AMT
	  , BANK_AMT, CURRENTADVANCE_AMT, EXPENSERETURN_AMT, DIFFREASONCODES_TXT, DIFFREASON_TXT, LASTSTEP_NO, COMPLETE_FL
	  , ADJUSTMENT_DSC, DEFICITCYCLE_CNT
	)
    SELECT
        S.STORERECID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STORE, RECONCILIATION_DT, ZET_AMT, DEFINEDADVANCE_AMT, EXPENSE_AMT, CASH_AMT, CARD_AMT, 
		RECOVERED_AMT, ADJUSTMENT_AMT, NETOFF_AMT, BANK_AMT, CURRENTADVANCE_AMT, EXPENSERETURN_AMT, 
		DIFFREASONCODES_TXT, DIFFREASON_TXT, LASTSTEP_NO, COMPLETE_FL, ADJUSTMENT_DSC, DEFICITCYCLE_CNT
      FROM
        RCL_STORE S (NOLOCK)
     WHERE
        S.STORERECID = @StoreReconciliationId;

    SET NOCOUNT OFF;
    UPDATE RCL_STORE
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STORE = @Store,
           -- RECONCILIATION_DT = @ReconciliationDate, tarih update olmamalı. 
           ZET_AMT = @ZetAmount,
           DEFINEDADVANCE_AMT = @DefinedAdvance,
           EXPENSE_AMT = @ExpenseAmount,
           CASH_AMT = @CashAmount,
           CARD_AMT = @CardAmount,
           RECOVERED_AMT = @RecoveredAmount,
           ADJUSTMENT_AMT = @AdjustmentAmount,
           NETOFF_AMT = @NetoffAmount,
           BANK_AMT = @BankAmount,
           CURRENTADVANCE_AMT = @CurrentAdvance,
           EXPENSERETURN_AMT = @ExpenseReturn,
           DIFFREASONCODES_TXT = @DiffReasonCodes,
           DIFFREASON_TXT = @DiffReason,
           LASTSTEP_NO = @LastStepNo,
           COMPLETE_FL = @CompleteFlag,
           ADJUSTMENT_DSC = @AdjustmentReason,
           DEFICITCYCLE_CNT = @DeficitCycleCount
     WHERE STORERECID = @StoreReconciliationId;

    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;

	-- Merkez tarafından güncellenen eski tarihli bir mutabakat ise sonraki günleri düzeltme scriptini çalıştır. 
	IF @CompleteFlag = 'Y' AND @ReconciliationDate < CAST(GETDATE() AS DATE)
	BEGIN
		EXEC RCL_UPD_RECALCULATE_SP @Store
	END

	SET NOCOUNT ON;

END