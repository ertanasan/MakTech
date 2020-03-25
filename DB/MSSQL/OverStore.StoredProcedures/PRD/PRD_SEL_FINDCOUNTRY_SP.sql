-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDCOUNTRY_SP
    @CountryName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           C.COUNTRYID,
           C.COUNTRY_NM,
           C.COMMENT_DSC      
      FROM PRD_COUNTRY C (NOLOCK)
     WHERE C.COUNTRY_NM = @CountryName;

/*Section="End"*/
END;
