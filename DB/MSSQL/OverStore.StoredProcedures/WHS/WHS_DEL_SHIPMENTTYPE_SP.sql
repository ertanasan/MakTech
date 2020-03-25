-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_DEL_SHIPMENTTYPE_SP
    @ShipmentTypeId INT
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
        SHIPMENTTYPE_NM    )    
    SELECT
        SHIPMENTTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        SHIPMENTTYPE_NM
      FROM
        WHS_SHIPMENTTYPE S (NOLOCK)
     WHERE
        S.SHIPMENTTYPEID = @ShipmentTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM WHS_SHIPMENTTYPE
     WHERE SHIPMENTTYPEID = @ShipmentTypeId;

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
