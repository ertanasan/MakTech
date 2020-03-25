-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_ACCOUNTS_SP
    @StoreAccountsId    INT OUT,
    @Store              INT,
    @AccountType        INT,
    @Bank               INT,
    @AccountText        VARCHAR(100),
    @AccountDescription VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_ACCOUNTS
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        STORE,
        ACCOUNTTYPE,
        BANK,
        ACCOUNT_TXT,
        ACCOUNT_DSC
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Store,
        @AccountType,
        @Bank,
        @AccountText,
        @AccountDescription
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
    SELECT @StoreAccountsId = SCOPE_IDENTITY();
/*Section="End"*/
END;
