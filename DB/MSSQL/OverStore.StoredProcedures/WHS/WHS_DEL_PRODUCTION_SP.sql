-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_PRODUCTION_SP
    @ProductionId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_PRODUCTIONLOG
    (
        PRODUCTIONID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PRODUCT    )    
    SELECT
        PRODUCTIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PRODUCT
      FROM
        WHS_PRODUCTION P (NOLOCK)
     WHERE
        P.PRODUCTIONID = @ProductionId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_PRODUCTION
     WHERE PRODUCTIONID = @ProductionId;

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
