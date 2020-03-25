-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDSUPERGROUP1_SP
    @SuperGroup1Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.SUPERGROUP1ID,
           S.SUPERGROUP1_NM,
           S.COMMENT_DSC      
      FROM PRD_SUPERGROUP1 S (NOLOCK)
     WHERE S.SUPERGROUP1_NM = @SuperGroup1Name;

/*Section="End"*/
END;
