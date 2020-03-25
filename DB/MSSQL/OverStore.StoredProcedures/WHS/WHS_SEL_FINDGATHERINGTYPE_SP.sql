-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_FINDGATHERINGTYPE_SP
    @GatheringTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           G.GATHERINGTYPEID,
           G.GATHERINGTYPE_NM
      FROM WHS_GATHERINGTYPE G (NOLOCK)
     WHERE G.GATHERINGTYPE_NM = @GatheringTypeName;

/*Section="End"*/
END;
