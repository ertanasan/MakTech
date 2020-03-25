-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRD_LST_BARCODE_SP
    @Product INT = NULL
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
    -- Select all
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
     WHERE (@Product IS NULL OR B.PRODUCT = @Product)
       AND (@Organization IS NULL OR B.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY BARCODE_TXT;

/*Section="End"*/
END;
