-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_SEL_BARCODE_SP
    @ProductBarcodeId INT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Query"*/
    -- Select
    SELECT
           B.BARCODEID,
           B.ORGANIZATION,
           B.DELETED_FL,
           B.CREATE_DT,
           B.UPDATE_DT,
           B.CREATEUSER,
           B.UPDATEUSER,
           B.PRODUCT,
           B.BARCODETYPE,
           B.BARCODE_TXT
      FROM PRD_BARCODE B (NOLOCK)
     WHERE B.BARCODEID = @ProductBarcodeId
       AND (@Organization IS NULL OR B.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
