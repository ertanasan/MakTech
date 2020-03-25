-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDSUPERGROUP3_SP
    @SuperGroup3Name VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.SUPERGROUP3ID,
           S.SUPERGROUP3_NM,
           S.COMMENT_DSC      
      FROM PRD_SUPERGROUP3 S (NOLOCK)
     WHERE S.SUPERGROUP3_NM = @SuperGroup3Name;

/*Section="End"*/
END;
