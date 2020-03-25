-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_SUPERGROUP3_SP
    @SuperGroup3Id INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SUPERGROUP3ID,
           S.SUPERGROUP3_NM,
           S.COMMENT_DSC      
      FROM PRD_SUPERGROUP3 S (NOLOCK)
     WHERE S.SUPERGROUP3ID = @SuperGroup3Id;

    /*Section="End"*/
END;
