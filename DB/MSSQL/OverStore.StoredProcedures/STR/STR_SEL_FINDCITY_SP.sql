-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_FINDCITY_SP
    @CityName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           C.CITYID,
           C.CITY_NM,
           C.PLATECODE_TXT      
      FROM STR_CITY C (NOLOCK)
     WHERE C.CITY_NM = @CityName;

/*Section="End"*/
END;
