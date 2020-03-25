-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FIXTURE_SP
    @FixtureId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           F.FIXTUREID,
           F.FIXTURE_NM      
      FROM PRD_FIXTURE F (NOLOCK)
     WHERE F.FIXTUREID = @FixtureId;

    /*Section="End"*/
END;
