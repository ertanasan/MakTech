-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_COUNTINGTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.COUNTINGTYPEID,
           C.COUNTINGTYPE_NM
      FROM WHS_COUNTINGTYPE C (NOLOCK)
     ORDER BY COUNTINGTYPE_NM;

/*Section="End"*/
END;
