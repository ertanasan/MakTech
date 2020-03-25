-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_BARCODETYPEINT_SP
    @BarcodeTypeID INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           B.BARCODETYPEINTID,
           B.BARCODETYPE_NM,
           B.COMMENT_DSC
      FROM PRD_BARCODETYPEINT B (NOLOCK)
     WHERE B.BARCODETYPEINTID = @BarcodeTypeID;

    /*Section="End"*/
END;
