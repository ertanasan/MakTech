-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_SHIPMENTTYPE_SP
    @ShipmentTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SHIPMENTTYPEID,
           S.SHIPMENTTYPE_NM      
      FROM WHS_SHIPMENTTYPE S (NOLOCK)
     WHERE S.SHIPMENTTYPEID = @ShipmentTypeId;

    /*Section="End"*/
END;
