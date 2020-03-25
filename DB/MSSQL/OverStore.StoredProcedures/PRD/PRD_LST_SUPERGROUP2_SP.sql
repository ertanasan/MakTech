-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_SUPERGROUP2_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SUPERGROUP2ID,
           S.SUPERGROUP2_NM,
           S.COMMENT_DSC
      FROM PRD_SUPERGROUP2 S (NOLOCK)
     ORDER BY SUPERGROUP2_NM;

/*Section="End"*/
END;
