-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_CASHREGISTERBRAND_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CASHREGISTERBRANDID,
           C.BRAND_NM,
           C.COMMENT_DSC
      FROM STR_CASHREGISTERBRAND C (NOLOCK)
     ORDER BY BRAND_NM;

/*Section="End"*/
END;
