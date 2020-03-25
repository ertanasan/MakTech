﻿CREATE PROCEDURE STR_LST_STORECASHREGISTERS_SP @StoreId INT AS
BEGIN
	SELECT B.CASHREGISTERBRANDID, B.BRAND_NM, B.COMMENT_DSC, MAX(CR.PRICEFILEPATH_TXT) PRICEFILEPATH_TXT
	  FROM STR_CASHREGISTER CR
	  JOIN STR_CASHREGISTERMODEL M ON CR.CASHREGISTERMODEL = M.CASHREGISTERMODELID
	  JOIN STR_CASHREGISTERBRAND B ON M.BRAND = B.CASHREGISTERBRANDID
	 WHERE STORE = @StoreId
	   AND CR.DELETED_FL = 'N'
	 GROUP BY B.CASHREGISTERBRANDID, B.BRAND_NM, B.COMMENT_DSC
END