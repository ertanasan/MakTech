-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_COUNTRY_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.COUNTRYID,
           C.COUNTRY_NM,
           C.COMMENT_DSC
      FROM PRD_COUNTRY C (NOLOCK)
     ORDER BY COUNTRY_NM;

/*Section="End"*/
END;
