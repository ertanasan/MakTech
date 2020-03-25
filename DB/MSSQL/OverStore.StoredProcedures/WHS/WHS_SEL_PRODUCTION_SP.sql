-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_PRODUCTION_SP
    @ProductionId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PRODUCTIONID,
           P.PRODUCT      
      FROM WHS_PRODUCTION P (NOLOCK)
     WHERE P.PRODUCTIONID = @ProductionId;

    /*Section="End"*/
END;
