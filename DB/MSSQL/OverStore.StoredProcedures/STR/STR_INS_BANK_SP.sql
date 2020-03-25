-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_BANK_SP
    @BankId      INT OUT,
    @BankName    VARCHAR(100),
    @BankAccount VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_BANK
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        BANK_NM,
        ACCOUNT_TXT
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @BankName,
        @BankAccount
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
    SELECT @BankId = SCOPE_IDENTITY();
/*Section="End"*/
END;
