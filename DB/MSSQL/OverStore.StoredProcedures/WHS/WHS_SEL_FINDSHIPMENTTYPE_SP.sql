-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_FINDSHIPMENTTYPE_SP
    @ShipmentTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.SHIPMENTTYPEID,
           S.SHIPMENTTYPE_NM      
      FROM WHS_SHIPMENTTYPE S (NOLOCK)
     WHERE S.SHIPMENTTYPE_NM = @ShipmentTypeName;

/*Section="End"*/
END;
