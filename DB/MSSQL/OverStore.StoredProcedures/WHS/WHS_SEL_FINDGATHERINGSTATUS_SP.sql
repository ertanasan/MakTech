-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_FINDGATHERINGSTATUS_SP
    @StatusName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           G.GATHERINGSTATUSID,
           G.GATHERINGSTATUS_NM      
      FROM WHS_GATHERINGSTATUS G (NOLOCK)
     WHERE G.GATHERINGSTATUS_NM = @StatusName;

/*Section="End"*/
END;
