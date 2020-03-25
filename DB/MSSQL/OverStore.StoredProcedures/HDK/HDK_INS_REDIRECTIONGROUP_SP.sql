-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_REDIRECTIONGROUP_SP
    @RedirectionGroupId INT OUT,
    @GroupName          VARCHAR(100),
    @RequestDefinition  INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_REDIRECTIONGROUP
    (
        GROUP_NM,
        REQUESTDEFINITION
    )
    VALUES
    (
        @GroupName,
        @RequestDefinition
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
    SELECT @RedirectionGroupId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO HDK_REDIRECTIONGROUPLOG
    (
        REDIRECTIONGROUPID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GROUP_NM,
        REQUESTDEFINITION
    )    
    VALUES
    (
        @RedirectionGroupId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @GroupName,
        @RequestDefinition);
/*Section="End"*/
END;
