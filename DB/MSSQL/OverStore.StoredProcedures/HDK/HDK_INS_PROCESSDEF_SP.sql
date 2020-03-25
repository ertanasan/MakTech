-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_PROCESSDEF_SP
    @ProcessDefinitionId   INT OUT,
    @ProcessDefinitionName VARCHAR(100),
    @ProcessNo             INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_PROCESSDEF
    (
        PROCESSDEF_NM,
        PROCESS_NO
    )
    VALUES
    (
        @ProcessDefinitionName,
        @ProcessNo
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
    SELECT @ProcessDefinitionId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO HDK_PROCESSDEFLOG
    (
        PROCESSDEFID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PROCESSDEF_NM,
        PROCESS_NO
    )
    VALUES
    (
        @ProcessDefinitionId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ProcessDefinitionName,
        @ProcessNo);
/*Section="End"*/
END;
