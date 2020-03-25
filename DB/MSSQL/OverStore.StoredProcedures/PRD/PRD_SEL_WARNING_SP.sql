-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_WARNING_SP
    @WarningId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           W.WARNINGID,
           W.WARNING_TXT,
           W.COMMENT_DSC      
      FROM PRD_WARNING W (NOLOCK)
     WHERE W.WARNINGID = @WarningId;

    /*Section="End"*/
END;
