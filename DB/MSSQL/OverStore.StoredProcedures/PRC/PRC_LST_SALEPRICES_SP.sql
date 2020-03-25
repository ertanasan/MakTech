﻿CREATE PROCEDURE [dbo].[PRC_LST_SALEPRICES_SP]
	@Store int = 0
AS

BEGIN

	IF OBJECT_ID('tempdb..#PLU') IS NOT NULL DROP TABLE #PLU    
	
	SELECT PRODUCT
		 , MAX(CASE WHEN ORDERNO = 1 THEN BARCODE ELSE '00000000000000000000' END) PLU1
		 , MAX(CASE WHEN ORDERNO = 2 THEN BARCODE ELSE '00000000000000000000' END) PLU2
		 , MAX(CASE WHEN ORDERNO = 3 THEN BARCODE ELSE '00000000000000000000' END) PLU3
	  INTO #PLU
	  FROM (
	SELECT B.PRODUCT, B.BARCODE_TXT BARCODE, ROW_NUMBER() OVER (PARTITION BY PRODUCT ORDER BY B.BARCODEID) ORDERNO
	  FROM PRD_BARCODE B) A
	 GROUP BY PRODUCT

	select prd.PRODUCTCODE_NM, prd.PRODUCT_NM, plu.PLU1, plu.PLU2, plu.PLU3, prc.PRICE_AMT, prd.SALEVAT_RT, prd.UNIT
		 , pf.PRODUCTFAMILY_NM, pt.PRODUCTTYPE_NM
	  from PRC_PRODUCT prc
	  join PRD_PRODUCT prd ON prc.PRODUCT = prd.PRODUCTID
	  join #PLU plu ON prd.PRODUCTID = plu.PRODUCT
	  left join PRD_PRODUCTTYPE pt ON prd.TYPE = pt.PRODUCTTYPEID
	  left join PRD_PRODUCTFAMILY pf ON pt.FAMILY = pf.PRODUCTFAMILYID
	 where prc.TYPE = 1 -- SATIŞ FİYATI

END;