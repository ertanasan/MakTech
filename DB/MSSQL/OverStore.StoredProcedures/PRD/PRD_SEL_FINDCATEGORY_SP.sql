-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDCATEGORY_SP
    @Category VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           C.CATEGORYID,
           C.CATEGORY_NM,
           C.COMMENT_DSC      
      FROM PRD_CATEGORY C (NOLOCK)
     WHERE C.CATEGORY_NM = @Category;

/*Section="End"*/
END;
