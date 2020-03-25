-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_SEL_SCREENPROPERTY_SP
    @OverStoreScreenPropertyId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SCREENPROPERTYID,
           S.SCREEN,
           S.PROPERTY_NM,
           S.VALUE_TXT      
      FROM OSM_SCREENPROPERTY S (NOLOCK)
     WHERE S.SCREENPROPERTYID = @OverStoreScreenPropertyId;

    /*Section="End"*/
END;
