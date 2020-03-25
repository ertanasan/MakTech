-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_GATHERINGTYPE_SP
    @GatheringTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           G.GATHERINGTYPEID,
           G.GATHERINGTYPE_NM      
      FROM WHS_GATHERINGTYPE G (NOLOCK)
     WHERE G.GATHERINGTYPEID = @GatheringTypeId;

    /*Section="End"*/
END;
