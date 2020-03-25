-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_DEL_ASSIGNUSER_SP
    @AssignUserId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO HDK_ASSIGNUSERLOG
    (
        ASSIGNUSERID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GROUP_NM,
        RESPONSIBLEUSER,
        ADMIN_FL    )    
    SELECT
        ASSIGNUSERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GROUP_NM,
        RESPONSIBLEUSER,
        ADMIN_FL
      FROM
        HDK_ASSIGNUSER A (NOLOCK)
     WHERE
        A.ASSIGNUSERID = @AssignUserId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM HDK_ASSIGNUSER
     WHERE ASSIGNUSERID = @AssignUserId;

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
