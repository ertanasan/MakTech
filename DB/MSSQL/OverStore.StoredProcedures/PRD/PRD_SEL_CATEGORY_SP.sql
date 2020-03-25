-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_CATEGORY_SP
    @CategoryID INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CATEGORYID,
           C.CATEGORY_NM,
           C.COMMENT_DSC      
      FROM PRD_CATEGORY C (NOLOCK)
     WHERE C.CATEGORYID = @CategoryID;

    /*Section="End"*/
END;
