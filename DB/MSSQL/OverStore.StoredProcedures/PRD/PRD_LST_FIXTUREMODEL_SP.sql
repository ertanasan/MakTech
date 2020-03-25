-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_FIXTUREMODEL_SP
    @Brand INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           F.FIXTUREMODELID,
           F.BRAND,
           F.MODEL_NM
      FROM PRD_FIXTUREMODEL F (NOLOCK)
     WHERE (@Brand IS NULL OR F.BRAND = @Brand)
     ORDER BY MODEL_NM;

/*Section="End"*/
END;
