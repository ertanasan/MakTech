-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_SHIPMENTTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           S.SHIPMENTTYPEID,
           S.SHIPMENTTYPE_NM
      FROM WHS_SHIPMENTTYPE S (NOLOCK)
     ORDER BY SHIPMENTTYPE_NM;

/*Section="End"*/
END;
