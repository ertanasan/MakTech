-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_PRODUCTIONCONTENT_SP
    @ProductionContentId INT,
    @Production          INT,
    @Product             INT,
    @ShareRate           NUMERIC(4,2)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        PRODUCTIONCONTENTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PRODUCTION,
        PRODUCT,
        SHARE_RT
      FROM
        WHS_PRODUCTIONCONTENT P (NOLOCK)
     WHERE
        P.PRODUCTIONCONTENTID = @ProductionContentId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_PRODUCTIONCONTENT
       SET
           PRODUCTION = @Production,
           PRODUCT = @Product,
           SHARE_RT = @ShareRate
     WHERE PRODUCTIONCONTENTID = @ProductionContentId;

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
