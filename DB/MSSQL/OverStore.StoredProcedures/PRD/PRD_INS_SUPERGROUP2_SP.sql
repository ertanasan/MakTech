-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_SUPERGROUP2_SP
    @SuperGroup2Id   INT,
    @SuperGroup2Name VARCHAR(100),
    @Comment         VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_SUPERGROUP2
    (
        SUPERGROUP2ID,
        SUPERGROUP2_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @SuperGroup2Id,
        @SuperGroup2Name,
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
    INSERT INTO PRD_SUPERGROUP2LOG
    (
        SUPERGROUP2ID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SUPERGROUP2_NM,
        COMMENT_DSC
    )    
    VALUES
    (
        @SuperGroup2Id,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @SuperGroup2Name,
        @Comment);
/*Section="End"*/
END;
