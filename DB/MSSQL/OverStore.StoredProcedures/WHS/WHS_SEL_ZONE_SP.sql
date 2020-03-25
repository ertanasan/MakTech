-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_ZONE_SP
    @StorageZonesId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           Z.ZONEID,
           Z.LOCATION_TXT,
           Z.ZONE_NM      
      FROM WHS_ZONE Z (NOLOCK)
     WHERE Z.ZONEID = @StorageZonesId;

    /*Section="End"*/
END;
