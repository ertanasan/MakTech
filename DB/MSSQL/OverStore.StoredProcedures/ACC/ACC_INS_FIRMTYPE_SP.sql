-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_FIRMTYPE_SP
    @FirmTypeId INT,
    @Name       VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_FIRMTYPE
    (
        FIRMTYPEID,
        FIRMTYPE_NM
    )
    VALUES
    (
        @FirmTypeId,
        @Name
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

    /*Section="Log"*/
    -- Create log record
    INSERT INTO ACC_FIRMTYPELOG
    (
        FIRMTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        FIRMTYPE_NM
    )    
    VALUES
    (
        @FirmTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Name);
/*Section="End"*/
END;
