-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_BARCODETYPE_SP
    @BarcodeTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           B.BARCODETYPEID,
           B.BARCODETYPE_NM,
           B.COMMENT_DSC      
      FROM PRD_BARCODETYPE B (NOLOCK)
     WHERE B.BARCODETYPEID = @BarcodeTypeId;

    /*Section="End"*/
END;
