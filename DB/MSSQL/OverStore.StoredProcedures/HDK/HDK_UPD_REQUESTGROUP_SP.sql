-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_UPD_REQUESTGROUP_SP
    @RequestGroupId   INT,
    @RequestGroupName VARCHAR(100),
    @DisplayOrder     INT,
    @ActiveFlag       VARCHAR(1)
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
        ACTIVE_FL
    )
    SELECT
        REQUESTGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE HDK_REQUESTGROUP
       SET
           REQUESTGROUP_NM = @RequestGroupName,
           DISPLAYORDER_NO = @DisplayOrder,
           ACTIVE_FL = @ActiveFlag
     WHERE REQUESTGROUPID = @RequestGroupId;

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
