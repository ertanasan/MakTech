-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_PRODUCTIONCONTENT_SP
    @ProductionContentId INT OUT,
    @Production          INT,
    @Product             INT,
    @ShareRate           NUMERIC(4,2)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_PRODUCTIONCONTENT
    (
        PRODUCTION,
        PRODUCT,
        SHARE_RT
    )
    VALUES
    (
        @Production,
        @Product,
        @ShareRate
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
    SELECT @ProductionContentId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO WHS_PRODUCTIONCONTENTLOG
    (
        PRODUCTIONCONTENTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PRODUCTION,
        PRODUCT,
        SHARE_RT
    )    
    VALUES
    (
        @ProductionContentId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Production,
        @Product,
        @ShareRate);
/*Section="End"*/
END;
