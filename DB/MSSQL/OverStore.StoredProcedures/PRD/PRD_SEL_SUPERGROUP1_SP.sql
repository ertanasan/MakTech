-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_SUPERGROUP1_SP
    @SuperGroup1Id INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SUPERGROUP1ID,
           S.SUPERGROUP1_NM,
           S.COMMENT_DSC      
      FROM PRD_SUPERGROUP1 S (NOLOCK)
     WHERE S.SUPERGROUP1ID = @SuperGroup1Id;

    /*Section="End"*/
END;
