-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_PACKAGETYPE_SP
    @ShipmentPackageTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PACKAGETYPEID,
           P.PACKAGETYPE_NM      
      FROM WHS_PACKAGETYPE P (NOLOCK)
     WHERE P.PACKAGETYPEID = @ShipmentPackageTypeId;

    /*Section="End"*/
END;
