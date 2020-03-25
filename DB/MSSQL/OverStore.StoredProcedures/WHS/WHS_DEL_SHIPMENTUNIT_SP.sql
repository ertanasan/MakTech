-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_SHIPMENTUNIT_SP
    @ShipmentUnitId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_SHIPMENTUNITLOG
    (
        SHIPMENTUNITID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        UNIT_NM,
        PACKAGE_QTY,
        COMMENT_DSC    )    
    SELECT
        SHIPMENTUNITID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        UNIT_NM,
        PACKAGE_QTY,
        COMMENT_DSC
      FROM
        WHS_SHIPMENTUNIT S (NOLOCK)
     WHERE
        S.SHIPMENTUNITID = @ShipmentUnitId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_SHIPMENTUNIT
     WHERE SHIPMENTUNITID = @ShipmentUnitId;

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
