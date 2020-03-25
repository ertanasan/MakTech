-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FIXTUREMODEL_SP
    @FixtureModelId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           F.FIXTUREMODELID,
           F.BRAND,
           F.MODEL_NM      
      FROM PRD_FIXTUREMODEL F (NOLOCK)
     WHERE F.FIXTUREMODELID = @FixtureModelId;

    /*Section="End"*/
END;
