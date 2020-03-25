-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_COUNTRY_SP
    @CountryId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.COUNTRYID,
           C.COUNTRY_NM,
           C.COMMENT_DSC      
      FROM PRD_COUNTRY C (NOLOCK)
     WHERE C.COUNTRYID = @CountryId;

    /*Section="End"*/
END;
