-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_BARCODETYPEINT_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           B.BARCODETYPEINTID,
           B.BARCODETYPE_NM,
           B.COMMENT_DSC
      FROM PRD_BARCODETYPEINT B (NOLOCK)
     ORDER BY BARCODETYPE_NM;

/*Section="End"*/
END;
