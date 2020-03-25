-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_TOWN_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           T.TOWNID,
           T.CITY,
           T.TOWN_NM
      FROM STR_TOWN T (NOLOCK)
     ORDER BY TOWN_NM;

/*Section="End"*/
END;
