﻿CREATE PROCEDURE PRC_LST_DELISTPRODUCTS_SP AS 
BEGIN
	SELECT DISTINCT B.BARCODE_TXT
	  FROM PRD_PROPERTY P
	  JOIN PRD_BARCODE B ON P.PRODUCT = B.PRODUCT
	  LEFT JOIN (SELECT DISTINCT BARCODE_TXT FROM PRD_PRODUCT JOIN PRD_BARCODE ON PRODUCTID = PRODUCT WHERE ACTIVE_FL = 'Y') AB ON B.BARCODE_TXT = AB.BARCODE_TXT
	 WHERE PROPERTYTYPE = 5
	   AND VALUE_TXT = '1'
	   AND AB.BARCODE_TXT IS NULL
	 UNION ALL
	SELECT BARCODE
	  FROM PRC_DELIST
END