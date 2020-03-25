-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_FIXTUREBRAND_SP
    @Fixture INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           F.FIXTUREBRANDID,
           F.FIXTURE,
           F.BRAND_NM
      FROM PRD_FIXTUREBRAND F (NOLOCK)
     WHERE (@Fixture IS NULL OR F.FIXTURE = @Fixture)
     ORDER BY BRAND_NM;

/*Section="End"*/
END;
