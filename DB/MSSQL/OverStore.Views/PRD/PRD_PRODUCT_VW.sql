﻿CREATE VIEW [PRD_PRODUCT_VW] AS 
SELECT P.*
	 , SG.SUBGROUP_NM
	 , SG.CATEGORY
	 , C.CATEGORY_NM
	 , SG1.SUPERGROUP1_NM
	 , SG2.SUPERGROUP2_NM
	 , SG3.SUPERGROUP3_NM
	 , CASE WHEN P.UNIT = 1 THEN 'Kg' ELSE 'Adet' END UNIT_NM
	 , B.BARCODE_TXT
	 , SP.PRICE_AMT UNITPRICE_AMT
  FROM PRD_PRODUCT P (NOLOCK)
  LEFT JOIN PRC_SALEPRICE_VW SP (NOLOCK) ON P.PRODUCTID = SP.PRODUCT
  LEFT JOIN PRD_SUBGROUP SG (NOLOCK) ON P.SUBGROUP = SG.SUBGROUPID
  LEFT JOIN PRD_CATEGORY C (NOLOCK) ON SG.CATEGORY = C.CATEGORYID
  LEFT JOIN PRD_SUPERGROUP1 SG1 (NOLOCK) ON P.SUPERGROUP1 = SG1.SUPERGROUP1ID
  LEFT JOIN PRD_SUPERGROUP2 SG2 (NOLOCK) ON P.SUPERGROUP2 = SG2.SUPERGROUP2ID
  LEFT JOIN PRD_SUPERGROUP3 SG3 (NOLOCK) ON P.SUPERGROUP3 = SG3.SUPERGROUP3ID
  LEFT JOIN (SELECT PRODUCT, MAX(BARCODE_TXT) BARCODE_TXT FROM PRD_BARCODE GROUP BY PRODUCT) B ON P.PRODUCTID = B.PRODUCT
 WHERE P.DELETED_FL = 'N'