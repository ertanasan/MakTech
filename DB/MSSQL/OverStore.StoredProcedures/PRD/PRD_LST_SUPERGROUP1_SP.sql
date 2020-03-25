-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_SUPERGROUP1_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SUPERGROUP1ID,
           S.SUPERGROUP1_NM,
           S.COMMENT_DSC
      FROM PRD_SUPERGROUP1 S (NOLOCK)
     ORDER BY SUPERGROUP1_NM;

/*Section="End"*/
END;
