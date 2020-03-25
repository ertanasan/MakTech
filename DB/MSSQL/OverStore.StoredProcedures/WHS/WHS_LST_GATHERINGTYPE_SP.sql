-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_GATHERINGTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           G.GATHERINGTYPEID,
           G.GATHERINGTYPE_NM
      FROM WHS_GATHERINGTYPE G (NOLOCK)
     ORDER BY GATHERINGTYPE_NM;

/*Section="End"*/
END;
