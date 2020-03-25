-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_SUPPLIERTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SUPPLIERTYPEID,
           S.SUPPLIERTYPE_NM
      FROM WHS_SUPPLIERTYPE S (NOLOCK)
     ORDER BY SUPPLIERTYPE_NM;

/*Section="End"*/
END;
