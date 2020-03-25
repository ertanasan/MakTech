-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_ACCOUNTTYPE_SP
    @StoreAccountTypeId INT OUT,
    @AccountTypeName    VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_ACCOUNTTYPE
    (
        ACCOUNTTYPE_NM
    )
    VALUES
    (
        @AccountTypeName
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
    SELECT @StoreAccountTypeId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_ACCOUNTTYPELOG
    (
        ACCOUNTTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ACCOUNTTYPE_NM
    )    
    VALUES
    (
        @StoreAccountTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @AccountTypeName);
/*Section="End"*/
END;
