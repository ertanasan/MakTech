-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_SUBGROUP_SP
    @SubgroupID   INT,
    @SubgroupName VARCHAR(100),
    @Category     INT,
    @Comment      VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_SUBGROUPLOG
    (
        SUBGROUPID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SUBGROUP_NM,
        CATEGORY,
        COMMENT_DSC
    )
    SELECT
        SUBGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SUBGROUP_NM,
        CATEGORY,
        COMMENT_DSC
      FROM
        PRD_SUBGROUP S (NOLOCK)
     WHERE
        S.SUBGROUPID = @SubgroupID;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_SUBGROUP
       SET
           SUBGROUP_NM = @SubgroupName,
           CATEGORY = @Category,
           COMMENT_DSC = @Comment
     WHERE SUBGROUPID = @SubgroupID;

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
