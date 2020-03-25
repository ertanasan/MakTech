-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_FIXTURE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           F.FIXTUREID,
           F.FIXTURE_NM
      FROM PRD_FIXTURE F (NOLOCK)
     ORDER BY FIXTURE_NM;

/*Section="End"*/
END;
