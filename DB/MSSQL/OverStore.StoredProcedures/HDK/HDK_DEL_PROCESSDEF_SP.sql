-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_PROCESSDEF_SP
    @ProcessDefinitionId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
        PROCESS_NO    )
    SELECT
        PROCESSDEFID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PROCESSDEF_NM,
        PROCESS_NO
      FROM
        HDK_PROCESSDEF P (NOLOCK)
     WHERE
        P.PROCESSDEFID = @ProcessDefinitionId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_PROCESSDEF
     WHERE PROCESSDEFID = @ProcessDefinitionId;

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
