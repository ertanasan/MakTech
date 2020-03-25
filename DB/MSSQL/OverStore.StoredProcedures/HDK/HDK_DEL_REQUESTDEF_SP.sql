-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_REQUESTDEF_SP
    @RequestDefinitionId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_REQUESTDEFLOG
    (
        REQUESTDEFID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        REQUESTDEF_NM,
        REQUESTGROUP,
        PROCESS,
        MICROCODE_TXT,
        DISPLAYORDER_NO,
        ACTIVE_FL    )
    SELECT
        REQUESTDEFID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        REQUESTDEF_NM,
        REQUESTGROUP,
        PROCESS,
        MICROCODE_TXT,
        DISPLAYORDER_NO,
        ACTIVE_FL
      FROM
        HDK_REQUESTDEF R (NOLOCK)
     WHERE
        R.REQUESTDEFID = @RequestDefinitionId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_REQUESTDEF
     WHERE REQUESTDEFID = @RequestDefinitionId;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
