-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_BARCODETYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           B.BARCODETYPEID,
           B.BARCODETYPE_NM,
           B.COMMENT_DSC
      FROM PRD_BARCODETYPE B (NOLOCK)
     ORDER BY BARCODETYPE_NM;

/*Section="End"*/
END;
