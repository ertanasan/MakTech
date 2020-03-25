-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_FINDSUPPLIERTYPE_SP
    @SupplierTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           S.SUPPLIERTYPEID,
           S.SUPPLIERTYPE_NM      
      FROM WHS_SUPPLIERTYPE S (NOLOCK)
     WHERE S.SUPPLIERTYPE_NM = @SupplierTypeName;

/*Section="End"*/
END;
