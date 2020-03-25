-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_SUPPLIER_SP
    @SupplierId INT
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
           S.SUPPLIERID,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.SUPPLIER_NM,
           S.SUPPLIERTYPE      
      FROM WHS_SUPPLIER S (NOLOCK)
     WHERE S.SUPPLIERID = @SupplierId     
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
