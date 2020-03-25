-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_SUPERGROUP1_SP
    @SuperGroup1Id   INT,
    @SuperGroup1Name VARCHAR(100),
    @Comment         VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_SUPERGROUP1
    (
        SUPERGROUP1ID,
        SUPERGROUP1_NM,
        COMMENT_DSC
    )
    VALUES
    (
        @SuperGroup1Id,
        @SuperGroup1Name,
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
    INSERT INTO PRD_SUPERGROUP1LOG
    (
        SUPERGROUP1ID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SUPERGROUP1_NM,
        COMMENT_DSC
    )    
    VALUES
    (
        @SuperGroup1Id,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @SuperGroup1Name,
        @Comment);
/*Section="End"*/
END;
