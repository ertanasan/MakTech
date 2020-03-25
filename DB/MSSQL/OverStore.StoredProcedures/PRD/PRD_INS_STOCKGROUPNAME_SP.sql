-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_STOCKGROUPNAME_SP
    @StockGroupNameId INT,
    @StockGroupName   VARCHAR(100),
    @UsageType        INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_STOCKGROUPNAME
    (
        STOCKGROUPID,
        STOCKGROUP_NM,
        USAGETYPE_CD
    )
    VALUES
    (
        @StockGroupNameId,
        @StockGroupName,
        @UsageType
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

    /*Section="Log"*/
    -- Create log record
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
        USAGETYPE_CD
    )
    VALUES
    (
        @StockGroupNameId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StockGroupName,
        @UsageType);
/*Section="End"*/
END;
