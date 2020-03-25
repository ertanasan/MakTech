-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_INS_STOCKGROUP_SP
    @Product      INT,
    @StockGroup   INT,
    @StockGroupId INT OUT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO PRD_STOCKGROUP
    (
        PRODUCTID,
        STOCKGROUP
    )
    VALUES
    (
        @Product,
        @StockGroup
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
    SELECT @StockGroupId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @Product,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @StockGroup,
        @StockGroupId);
/*Section="End"*/
END;
