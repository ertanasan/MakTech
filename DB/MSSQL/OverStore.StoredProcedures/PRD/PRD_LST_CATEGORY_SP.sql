-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_CATEGORY_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CATEGORYID,
           C.CATEGORY_NM,
           C.COMMENT_DSC
      FROM PRD_CATEGORY C (NOLOCK)
     ORDER BY CATEGORY_NM;

/*Section="End"*/
END;
