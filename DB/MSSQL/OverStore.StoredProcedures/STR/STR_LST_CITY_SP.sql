-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_CITY_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CITYID,
           C.CITY_NM,
           C.PLATECODE_TXT
      FROM STR_CITY C (NOLOCK)
     ORDER BY CITY_NM;

/*Section="End"*/
END;
