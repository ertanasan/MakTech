-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_SEASONTYPE_SP
    @SeasonTypeId   INT,
    @SeasonTypeName VARCHAR(100),
    @Comment        VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_SEASONTYPE
    (
        SEASONTYPEID,
        SEASONTYPE_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @SeasonTypeId,
        @SeasonTypeName,
        @Comment
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
    INSERT INTO PRD_SEASONTYPELOG
    (
        SEASONTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SEASONTYPE_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @SeasonTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @SeasonTypeName,
        @Comment);
/*Section="End"*/
END;
