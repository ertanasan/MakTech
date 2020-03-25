-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_DRILLPRODUCT_SP
    @DrillProductId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           D.DRILLPRODUCTID,
           D.COUNTING_DT,
           D.PRODUCT,
           D.STORE
      FROM WHS_DRILLPRODUCT D (NOLOCK)
     WHERE D.DRILLPRODUCTID = @DrillProductId;

    /*Section="End"*/
END;
