-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_WARNING_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           W.WARNINGID,
           W.WARNING_TXT,
           W.COMMENT_DSC
      FROM PRD_WARNING W (NOLOCK)
     ORDER BY WARNING_TXT;

/*Section="End"*/
END;
