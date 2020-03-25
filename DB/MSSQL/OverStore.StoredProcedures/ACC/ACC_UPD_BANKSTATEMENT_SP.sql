-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_BANKSTATEMENT_SP
    @BankStatementId   BIGINT,
    @Event             INT,
    @Organization      INT,
    @Bank              INT,
    @Date              DATETIME,
    @Description       VARCHAR(1000),
    @TransactionAmount NUMERIC(22,6),
    @Balance           NUMERIC(22,6),
    @Channel           VARCHAR(100),
    @Info1             VARCHAR(100),
    @Info2             VARCHAR(100),
    @Info3             VARCHAR(100)
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
    UPDATE ACC_BANKSTATEMENT
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           BANK = @Bank,
           DATE_DT = CAST(@Date AS DATE),
           DESCRIPTION_DSC = @Description,
           TRANSACTION_AMT = @TransactionAmount,
           BALANCE_AMT = @Balance,
           CHANNEL_DSC = @Channel,
           INFO1_DSC = @Info1,
           INFO2_DSC = @Info2,
           INFO3_DSC = @Info3
     WHERE BANKSTATEMENTID = @BankStatementId
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
