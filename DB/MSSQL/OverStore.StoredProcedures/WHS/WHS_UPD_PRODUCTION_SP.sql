-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_PRODUCTION_SP
    @ProductionId INT,
    @Product      INT
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
        PRODUCT
    )    
    SELECT
        PRODUCTIONID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PRODUCT
      FROM
        WHS_PRODUCTION P (NOLOCK)
     WHERE
        P.PRODUCTIONID = @ProductionId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_PRODUCTION
       SET
           PRODUCT = @Product
     WHERE PRODUCTIONID = @ProductionId;

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
