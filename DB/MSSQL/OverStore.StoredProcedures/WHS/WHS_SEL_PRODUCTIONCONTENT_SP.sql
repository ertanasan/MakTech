-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_PRODUCTIONCONTENT_SP
    @ProductionContentId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PRODUCTIONCONTENTID,
           P.PRODUCTION,
           P.PRODUCT,
           P.SHARE_RT      
      FROM WHS_PRODUCTIONCONTENT P (NOLOCK)
     WHERE P.PRODUCTIONCONTENTID = @ProductionContentId;

    /*Section="End"*/
END;
