-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_SCALEBRAND_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SCALEBRANDID,
           S.BRAND_NM,
           S.COMMENT_DSC
      FROM STR_SCALEBRAND S (NOLOCK)
     ORDER BY BRAND_NM;

/*Section="End"*/
END;
