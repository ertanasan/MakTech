-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_SHIPMENTUNIT_SP
    @ShipmentUnitId  INT,
    @UnitName        VARCHAR(100),
    @PackageQuantity INT,
    @Comment         VARCHAR(200)
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
        COMMENT_DSC
    )    
    SELECT
        SHIPMENTUNITID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_SHIPMENTUNIT
       SET
           UNIT_NM = @UnitName,
           PACKAGE_QTY = @PackageQuantity,
           COMMENT_DSC = @Comment
     WHERE SHIPMENTUNITID = @ShipmentUnitId;

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
