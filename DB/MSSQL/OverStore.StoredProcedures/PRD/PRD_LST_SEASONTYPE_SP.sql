-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_SEASONTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SEASONTYPEID,
           S.SEASONTYPE_NM,
           S.COMMENT_DSC
      FROM PRD_SEASONTYPE S (NOLOCK)
     ORDER BY SEASONTYPE_NM;

/*Section="End"*/
END;
