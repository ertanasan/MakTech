-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_SEASONTYPE_SP
    @SeasonTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SEASONTYPEID,
           S.SEASONTYPE_NM,
           S.COMMENT_DSC      
      FROM PRD_SEASONTYPE S (NOLOCK)
     WHERE S.SEASONTYPEID = @SeasonTypeId;

    /*Section="End"*/
END;
