-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_ATTRIBUTETYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           A.ATTRIBUTETYPEID,
           A.ATTRIBUTETYPE_NM
      FROM HDK_ATTRIBUTETYPE A (NOLOCK)
     ORDER BY ATTRIBUTETYPE_NM;

/*Section="End"*/
END;
