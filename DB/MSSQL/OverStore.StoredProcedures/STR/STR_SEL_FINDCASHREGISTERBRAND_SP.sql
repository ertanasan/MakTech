-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_FINDCASHREGISTERBRAND_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           C.CASHREGISTERBRANDID,
           C.BRAND_NM,
           C.COMMENT_DSC      
      FROM STR_CASHREGISTERBRAND C (NOLOCK)
     WHERE C.BRAND_NM = @Name;

/*Section="End"*/
END;
