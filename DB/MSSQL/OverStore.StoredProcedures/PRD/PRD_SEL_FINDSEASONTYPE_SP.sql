-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDSEASONTYPE_SP
    @SeasonTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.SEASONTYPEID,
           S.SEASONTYPE_NM,
           S.COMMENT_DSC      
      FROM PRD_SEASONTYPE S (NOLOCK)
     WHERE S.SEASONTYPE_NM = @SeasonTypeName;

/*Section="End"*/
END;
