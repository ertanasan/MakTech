-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_GATHERINGSTATUS_SP
    @GatheringStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           G.GATHERINGSTATUSID,
           G.GATHERINGSTATUS_NM      
      FROM WHS_GATHERINGSTATUS G (NOLOCK)
     WHERE G.GATHERINGSTATUSID = @GatheringStatusId;

    /*Section="End"*/
END;
