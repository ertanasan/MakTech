-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_SHIPMENTUNIT_SP
    @ShipmentUnitId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SHIPMENTUNITID,
           S.UNIT_NM,
           S.PACKAGE_QTY,
           S.COMMENT_DSC      
      FROM WHS_SHIPMENTUNIT S (NOLOCK)
     WHERE S.SHIPMENTUNITID = @ShipmentUnitId;

    /*Section="End"*/
END;
