-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_INS_UPLOADTYPE_SP
    @UploadTypeId INT OUT,
    @Name         VARCHAR(100),
    @Description  VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO SUP_UPLOADTYPE
    (
        UPLOADTYPE_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @Name,
        @Description
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
    SELECT @UploadTypeId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO SUP_UPLOADTYPELOG
    (
        UPLOADTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        UPLOADTYPE_NM,
        COMMENT_DSC
    )    
    VALUES
    (
        @UploadTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Name,
        @Description);
/*Section="End"*/
END;
