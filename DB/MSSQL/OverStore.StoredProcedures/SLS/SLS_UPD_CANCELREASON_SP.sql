-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_UPD_CANCELREASON_SP
    @CancelReasonId      BIGINT,
    @Event               INT,
    @Organization        INT,
    @StoreReconciliation BIGINT,
    @SaleDetail          BIGINT,
    @ReasonText          VARCHAR(1000),
    @CashierName         VARCHAR(100)
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE SLS_CANCELREASON
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           STOREREC = @StoreReconciliation,
           SALEDETAIL = @SaleDetail,
           REASON_TXT = @ReasonText,
           CASHIER_NM = @CashierName
     WHERE CANCELREASONID = @CancelReasonId     
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
