-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_INS_REQUESTGROUP_SP
    @RequestGroupId   INT OUT,
    @RequestGroupName VARCHAR(100),
    @DisplayOrder     INT,
    @ActiveFlag       VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO HDK_REQUESTGROUP
    (
        REQUESTGROUP_NM,
        DISPLAYORDER_NO,
        ACTIVE_FL
    )
    VALUES
    (
        @RequestGroupName,
        @DisplayOrder,
        @ActiveFlag
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
    SELECT @RequestGroupId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
        ACTIVE_FL
    )
    VALUES
    (
        @RequestGroupId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @RequestGroupName,
        @DisplayOrder,
        @ActiveFlag);
/*Section="End"*/
END;
