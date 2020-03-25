-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_REDIRECTIONGROUP_SP
    @RedirectionGroupId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
        REQUESTDEFINITION    )    
    SELECT
        REDIRECTIONGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GROUP_NM,
        REQUESTDEFINITION
      FROM
        HDK_REDIRECTIONGROUP R (NOLOCK)
     WHERE
        R.REDIRECTIONGROUPID = @RedirectionGroupId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_REDIRECTIONGROUP
     WHERE REDIRECTIONGROUPID = @RedirectionGroupId;

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
