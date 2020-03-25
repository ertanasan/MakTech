-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_SUPPLIERTYPE_SP
    @SupplierTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           S.SUPPLIERTYPEID,
           S.SUPPLIERTYPE_NM      
      FROM WHS_SUPPLIERTYPE S (NOLOCK)
     WHERE S.SUPPLIERTYPEID = @SupplierTypeId;

    /*Section="End"*/
END;
