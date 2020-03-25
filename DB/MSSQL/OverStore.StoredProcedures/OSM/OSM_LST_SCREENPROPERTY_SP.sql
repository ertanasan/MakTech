-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_LST_SCREENPROPERTY_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SCREENPROPERTYID,
           S.SCREEN,
           S.PROPERTY_NM,
           S.VALUE_TXT
      FROM OSM_SCREENPROPERTY S (NOLOCK);

/*Section="End"*/
END;
