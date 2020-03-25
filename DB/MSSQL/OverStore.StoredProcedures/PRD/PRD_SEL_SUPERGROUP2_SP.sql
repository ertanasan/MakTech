-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_SUPERGROUP2_SP
    @SuperGroup2Id INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SUPERGROUP2ID,
           S.SUPERGROUP2_NM,
           S.COMMENT_DSC      
      FROM PRD_SUPERGROUP2 S (NOLOCK)
     WHERE S.SUPERGROUP2ID = @SuperGroup2Id;

    /*Section="End"*/
END;
