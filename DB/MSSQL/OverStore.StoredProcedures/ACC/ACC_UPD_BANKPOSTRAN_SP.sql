-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_BANKPOSTRAN_SP
    @BankPosTransactionsId BIGINT,
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
    UPDATE ACC_BANKPOSTRAN
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           BANK = @Bank,
           STOREREF_TXT = @StoreRef,
           POSREF_TXT = @PosRef,
           BLOCKED_DT = @BlockedDate,
           VALUE_DT = @ValueDate,
           QUANTITY_QTY = @Quantity,
           CREDIT_AMT = @CreditAmount,
           DEBIT_AMT = @DebitAmount,
           COMMISSION_AMT = @CommissionAmount,
           MIKRO_TM = @MikroTransferTime,
           MIKROSTATUS_CD = @MikroStatusCode,
           MIKROTRANCODE_TXT = @MikroTransactionCode
     WHERE BANKPOSTRANID = @BankPosTransactionsId
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
