-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_ZETIMAGE_SP
    @ZetImageId     BIGINT OUT,
    @Event          INT,
    @Organization   INT,
    @Reconciliation BIGINT,
    @CashRegister   INT,
    @Document       BIGINT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_ZETIMAGE
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        STOREREC,
        CASHREGISTER,
        DOCUMENT
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
        @Reconciliation,
        @CashRegister,
        @Document
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
    SELECT @ZetImageId = SCOPE_IDENTITY();
/*Section="End"*/
END;
