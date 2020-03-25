-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_PRODUCTIONCONTENT_SP
    @ProductionContentId INT
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
        SHARE_RT    )    
    SELECT
        PRODUCTIONCONTENTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_PRODUCTIONCONTENT
     WHERE PRODUCTIONCONTENTID = @ProductionContentId;

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
