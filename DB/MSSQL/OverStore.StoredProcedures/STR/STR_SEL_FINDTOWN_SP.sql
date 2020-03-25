-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_FINDTOWN_SP
    @TownName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           T.TOWNID,
           T.CITY,
           T.TOWN_NM      
      FROM STR_TOWN T (NOLOCK)
     WHERE T.TOWN_NM = @TownName;

/*Section="End"*/
END;
