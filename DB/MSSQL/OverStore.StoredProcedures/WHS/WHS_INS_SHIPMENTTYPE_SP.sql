-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_INS_SHIPMENTTYPE_SP
    @ShipmentTypeId   INT,
    @ShipmentTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO WHS_SHIPMENTTYPE
    (
        SHIPMENTTYPEID,
        SHIPMENTTYPE_NM
    )
    VALUES
    (
        @ShipmentTypeId,
        @ShipmentTypeName
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

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @ShipmentTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ShipmentTypeName);
/*Section="End"*/
END;
