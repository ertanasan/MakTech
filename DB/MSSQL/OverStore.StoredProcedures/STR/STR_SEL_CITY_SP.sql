-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_CITY_SP
    @CityId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CITYID,
           C.CITY_NM,
           C.PLATECODE_TXT      
      FROM STR_CITY C (NOLOCK)
     WHERE C.CITYID = @CityId;

    /*Section="End"*/
END;
