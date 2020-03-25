-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_GATHERINGPALLETSTATUS_SP
    @StatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           G.GATHERINGPALLETSTATUSID,
           G.STATUS_NM      
      FROM WHS_GATHERINGPALLETSTATUS G (NOLOCK)
     WHERE G.GATHERINGPALLETSTATUSID = @StatusId;

    /*Section="End"*/
END;
