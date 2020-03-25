-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_BANKSTATEMENT_SP
    @BankStatementId   BIGINT OUT,
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
	/*Section="Insert"*/
    SET NOCOUNT OFF

	SELECT @BankStatementId = BANKSTATEMENTID FROM ACC_BANKSTATEMENT WHERE BANK = @Bank AND DATE_DT = @Date AND DESCRIPTION_DSC = @Description AND TRANSACTION_AMT = @TransactionAmount AND BALANCE_AMT = @Balance

	IF @@ROWCOUNT > 0 RETURN;

    
    -- Insert record
    INSERT INTO ACC_BANKSTATEMENT
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
        DATE_DT,
        DESCRIPTION_DSC,
        TRANSACTION_AMT,
        BALANCE_AMT,
        CHANNEL_DSC,
        INFO1_DSC,
        INFO2_DSC,
        INFO3_DSC
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
        CAST(@Date AS DATE),
        @Description,
        @TransactionAmount,
        @Balance,
        @Channel,
        @Info1,
        @Info2,
        @Info3
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
    SELECT @BankStatementId = SCOPE_IDENTITY();
/*Section="End"*/
END;
