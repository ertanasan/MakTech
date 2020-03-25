-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_PRODUCTIONCONTENT_SP @Production INT
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PRODUCTIONCONTENTID,
           P.PRODUCTION,
           P.PRODUCT,
           P.SHARE_RT
      FROM WHS_PRODUCTIONCONTENT P (NOLOCK)
	 WHERE P.PRODUCTION = @Production
     ORDER BY PRODUCTIONCONTENTID;

/*Section="End"*/
END;
