-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_FINDSCALEBRAND_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.SCALEBRANDID,
           S.BRAND_NM,
           S.COMMENT_DSC      
      FROM STR_SCALEBRAND S (NOLOCK)
     WHERE S.BRAND_NM = @Name;

/*Section="End"*/
END;
