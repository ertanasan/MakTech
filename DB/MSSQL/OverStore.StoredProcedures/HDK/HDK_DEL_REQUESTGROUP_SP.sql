-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_REQUESTGROUP_SP
    @RequestGroupId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_REQUESTGROUPLOG
    (
        REQUESTGROUPID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        REQUESTGROUP_NM,
        DISPLAYORDER_NO,
        ACTIVE_FL    )
    SELECT
        REQUESTGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        REQUESTGROUP_NM,
        DISPLAYORDER_NO,
        ACTIVE_FL
      FROM
        HDK_REQUESTGROUP R (NOLOCK)
     WHERE
        R.REQUESTGROUPID = @RequestGroupId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_REQUESTGROUP
     WHERE REQUESTGROUPID = @RequestGroupId;

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
