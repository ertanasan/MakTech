-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_COUNTINGTYPE_SP
    @CountingTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.COUNTINGTYPEID,
           C.COUNTINGTYPE_NM      
      FROM WHS_COUNTINGTYPE C (NOLOCK)
     WHERE C.COUNTINGTYPEID = @CountingTypeId;

    /*Section="End"*/
END;
