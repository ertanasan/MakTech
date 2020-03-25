-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_UPD_STOCKGROUP_SP
    @Product      INT,
    @StockGroup   INT,
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
        STOCKGROUPID
    )    
    SELECT
        PRODUCTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STOCKGROUP,
        STOCKGROUPID
      FROM
        PRD_STOCKGROUP S (NOLOCK)
     WHERE
        S.STOCKGROUPID = @StockGroupId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE PRD_STOCKGROUP
       SET
           PRODUCTID = @Product,
           STOCKGROUP = @StockGroup
     WHERE STOCKGROUPID = @StockGroupId;

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
