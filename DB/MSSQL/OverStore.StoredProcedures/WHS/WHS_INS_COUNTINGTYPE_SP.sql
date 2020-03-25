-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_COUNTINGTYPE_SP
    @CountingTypeId   INT OUT,
    @CountingTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_COUNTINGTYPE
    (
        COUNTINGTYPE_NM
    )
    VALUES
    (
        @CountingTypeName
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
    SELECT @CountingTypeId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_COUNTINGTYPELOG
    (
        COUNTINGTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        COUNTINGTYPE_NM
    )    
    VALUES
    (
        @CountingTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @CountingTypeName);
/*Section="End"*/
END;
