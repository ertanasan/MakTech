-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_GATHERINGSTATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           G.GATHERINGSTATUSID,
           G.GATHERINGSTATUS_NM
      FROM WHS_GATHERINGSTATUS G (NOLOCK)
     ORDER BY GATHERINGSTATUSID;

/*Section="End"*/
END;
