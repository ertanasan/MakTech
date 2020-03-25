﻿CREATE PROCEDURE WHS_RPT_DRILLCOUNTPERFDETAIL_SP @StoreId INT AS
BEGIN

	DECLARE @LastCountingDate DATE;
	SELECT @LastCountingDate = MAX(PLANNED_DT) FROM WHS_STOCKTAKINGSCHEDULE WHERE STORE = @StoreId AND COUNTINGTYPE = 1 AND STATUS = 2

	SELECT STORE_NM, COUNTING_DT, LASTCOUNTING_DT, PRODUCTCODE_NM, PRODUCT_NM, PRICE_AMT, SONDAJSTOK, STOCK, DIFF_AMT, SALE_QTY, SALE_AMT
	  FROM WHS_DRILLCOUNTSUMMARY
	 WHERE STORE = @StoreId
	   AND LASTCOUNTING_DT = @LastCountingDate
	 ORDER BY DIFF_AMT
END