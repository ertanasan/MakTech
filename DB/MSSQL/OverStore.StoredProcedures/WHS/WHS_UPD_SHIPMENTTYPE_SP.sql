-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_UPD_SHIPMENTTYPE_SP
    @ShipmentTypeId   INT,
    @ShipmentTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO WHS_SHIPMENTTYPELOG
    (
        SHIPMENTTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        SHIPMENTTYPE_NM
    )    
    SELECT
        SHIPMENTTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SHIPMENTTYPE_NM
      FROM
        WHS_SHIPMENTTYPE S (NOLOCK)
     WHERE
        S.SHIPMENTTYPEID = @ShipmentTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE WHS_SHIPMENTTYPE
       SET
           SHIPMENTTYPE_NM = @ShipmentTypeName
     WHERE SHIPMENTTYPEID = @ShipmentTypeId;

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
