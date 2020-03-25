-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_FINDGATHERINGPALLETSTATUS_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           G.GATHERINGPALLETSTATUSID,
           G.STATUS_NM      
      FROM WHS_GATHERINGPALLETSTATUS G (NOLOCK)
     WHERE G.STATUS_NM = @Name;

/*Section="End"*/
END;
