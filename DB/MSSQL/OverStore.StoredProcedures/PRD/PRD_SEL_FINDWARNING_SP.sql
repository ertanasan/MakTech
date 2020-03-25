-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDWARNING_SP
    @Warning VARCHAR(1000)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           W.WARNINGID,
           W.WARNING_TXT,
           W.COMMENT_DSC      
      FROM PRD_WARNING W (NOLOCK)
     WHERE W.WARNING_TXT = @Warning;

/*Section="End"*/
END;
