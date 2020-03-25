-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_PROPERTYTYPE_SP
    @PropertyTypeId INT,
    @Name           VARCHAR(100),
    @Description    VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_PROPERTYTYPE
    (
        PROPERTYTYPEID,
        PROPERTYTYPE_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @PropertyTypeId,
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

    /*Section="Log"*/
    -- Create log record
    INSERT INTO PRD_PROPERTYTYPELOG
    (
        PROPERTYTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROPERTYTYPE_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @PropertyTypeId,
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
