-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_DRILLPRODUCT_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           D.DRILLPRODUCTID,
           D.COUNTING_DT,
           D.PRODUCT,
           D.STORE
      FROM WHS_DRILLPRODUCT D (NOLOCK)
     ORDER BY COUNTING_DT;

/*Section="End"*/
END;
