-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_SUPERGROUP3_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SUPERGROUP3ID,
           S.SUPERGROUP3_NM,
           S.COMMENT_DSC
      FROM PRD_SUPERGROUP3 S (NOLOCK)
     ORDER BY SUPERGROUP3_NM;

/*Section="End"*/
END;
