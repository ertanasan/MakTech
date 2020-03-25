-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FIXTUREBRAND_SP
    @FixtureBrandId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           F.FIXTUREBRANDID,
           F.FIXTURE,
           F.BRAND_NM      
      FROM PRD_FIXTUREBRAND F (NOLOCK)
     WHERE F.FIXTUREBRANDID = @FixtureBrandId;

    /*Section="End"*/
END;
