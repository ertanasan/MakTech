-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_FINDBARCODETYPEINT_SP
    @BarcodeType VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           B.BARCODETYPEINTID,
           B.BARCODETYPE_NM,
           B.COMMENT_DSC
      FROM PRD_BARCODETYPEINT B (NOLOCK)
     WHERE B.BARCODETYPE_NM = @BarcodeType;

/*Section="End"*/
END;
