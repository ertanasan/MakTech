-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_UPD_RECONCILIATION_SP
    @StoreReconciliationId BIGINT,
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
    @Approved			   VARCHAR(1)
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

	SET @TransactionDate = CAST(@TransactionDate AS DATE)

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE RCL_RECONCILIATION
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           TRANSACTION_DT = @TransactionDate,
           STORE = @StoreID,
           PREVIOUSDAYADVANCE_AMT = @PreviousDayAmount,
           SALETOTAL_AMT = @SaleTotal,
           CASHTOTAL_AMT = @CashTotal,
           CARDTOTAL_AMT = @CardTotal,
           TOBANK_AMT = @ToBank,
           DIFFERENCE_AMT = @Difference,
           DIFFERENCE_DSC = @DifferenceExplanation,
           COMPLETED_AMT = @Completed,
           EODADVANCE_AMT = @EodAdvance,
		   RECONCILIATED_FL = @Reconciliated,
		   APPROVED_FL = @Approved
     WHERE RECONCILIATIONID = @StoreReconciliationId     
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
