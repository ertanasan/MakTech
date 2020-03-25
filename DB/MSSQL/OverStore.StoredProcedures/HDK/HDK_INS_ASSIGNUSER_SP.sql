-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_ASSIGNUSER_SP
    @AssignUserId    INT OUT,
    @GroupName       VARCHAR(100),
    @ResponsibleUser INT,
    @AdminFlag       VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_ASSIGNUSER
    (
        GROUP_NM,
        RESPONSIBLEUSER,
        ADMIN_FL
    )
    VALUES
    (
        @GroupName,
        @ResponsibleUser,
        @AdminFlag
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
    SELECT @AssignUserId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @AssignUserId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @GroupName,
        @ResponsibleUser,
        @AdminFlag);
/*Section="End"*/
END;
