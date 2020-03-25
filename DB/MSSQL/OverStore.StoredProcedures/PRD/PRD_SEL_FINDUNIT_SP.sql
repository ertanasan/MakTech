-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDUNIT_SP
    @Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           U.UNITID,
           U.UNIT_NM,
           U.COMMENT_DSC
      FROM PRD_UNIT U (NOLOCK)
     WHERE U.UNIT_NM = @Name;

/*Section="End"*/
END;
