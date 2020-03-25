-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_SUBGROUP_SP
    @SubgroupID INT
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
        COMMENT_DSC    )    
    SELECT
        SUBGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_SUBGROUP
     WHERE SUBGROUPID = @SubgroupID;

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
