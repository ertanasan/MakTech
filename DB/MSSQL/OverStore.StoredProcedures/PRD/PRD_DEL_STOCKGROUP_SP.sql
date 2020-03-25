-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_DEL_STOCKGROUP_SP
    @StockGroupId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO PRD_STOCKGROUPLOG
    (
        PRODUCTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STOCKGROUP,
        STOCKGROUPID    )
    SELECT
        PRODUCTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STOCKGROUP,
        STOCKGROUPID
      FROM
        PRD_STOCKGROUP S (NOLOCK)
     WHERE
        S.STOCKGROUPID = @StockGroupId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM PRD_STOCKGROUP
     WHERE STOCKGROUPID = @StockGroupId;

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
