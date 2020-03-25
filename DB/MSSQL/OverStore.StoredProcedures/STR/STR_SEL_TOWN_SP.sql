-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_TOWN_SP
    @TownId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           T.TOWNID,
           T.CITY,
           T.TOWN_NM      
      FROM STR_TOWN T (NOLOCK)
     WHERE T.TOWNID = @TownId;

    /*Section="End"*/
END;
