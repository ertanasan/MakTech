-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_PRODUCTION_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PRODUCTIONID,
           P.PRODUCT,
		   PP.NAME_NM PRODUCT_NM
      FROM WHS_PRODUCTION P (NOLOCK)
	  JOIN PRD_PRODUCT PP (NOLOCK) ON P.PRODUCT = PP.PRODUCTID
     ORDER BY PRODUCT;

/*Section="End"*/
END;
