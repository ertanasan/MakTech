-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_SCALEBRAND_SP
    @ScaleBrandId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SCALEBRANDID,
           S.BRAND_NM,
           S.COMMENT_DSC      
      FROM STR_SCALEBRAND S (NOLOCK)
     WHERE S.SCALEBRANDID = @ScaleBrandId;

    /*Section="End"*/
END;
