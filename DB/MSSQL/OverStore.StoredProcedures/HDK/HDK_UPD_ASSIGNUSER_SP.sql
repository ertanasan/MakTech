-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_ASSIGNUSER_SP
    @AssignUserId    INT,
    @GroupName       VARCHAR(100),
    @ResponsibleUser INT,
    @AdminFlag       VARCHAR(1)
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
        ADMIN_FL
    )    
    SELECT
        ASSIGNUSERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_ASSIGNUSER
       SET
           GROUP_NM = @GroupName,
           RESPONSIBLEUSER = @ResponsibleUser,
           ADMIN_FL = @AdminFlag
     WHERE ASSIGNUSERID = @AssignUserId;

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
