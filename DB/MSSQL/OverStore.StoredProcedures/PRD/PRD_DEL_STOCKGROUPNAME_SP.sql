-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_STOCKGROUPNAME_SP
    @StockGroupNameId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_STOCKGROUPNAMELOG
    (
        STOCKGROUPID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STOCKGROUP_NM,
        USAGETYPE_CD    )
    SELECT
        STOCKGROUPID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STOCKGROUP_NM,
        USAGETYPE_CD
      FROM
        PRD_STOCKGROUPNAME S (NOLOCK)
     WHERE
        S.STOCKGROUPID = @StockGroupNameId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_STOCKGROUPNAME
     WHERE STOCKGROUPID = @StockGroupNameId;

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
