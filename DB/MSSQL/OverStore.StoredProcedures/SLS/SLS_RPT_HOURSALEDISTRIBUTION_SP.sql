﻿CREATE PROCEDURE SLS_RPT_HOURSALEDISTRIBUTION_SP @StartDate DATE, @EndDate DATE AS
BEGIN

	SELECT *
	  INTO #HOURS
	  FROM (
	SELECT 1 ID, 0 MINHOUR, 9 MAXHOUR, '0-10' DSC UNION ALL
	SELECT 2, 10, 10, '10-11' UNION ALL
	SELECT 3, 11, 11, '11-12' UNION ALL
	SELECT 4, 12, 12, '12-13' UNION ALL
	SELECT 5, 13, 13, '13-14' UNION ALL
	SELECT 6, 14, 14, '14-15' UNION ALL
	SELECT 7, 15, 15, '15-16' UNION ALL
	SELECT 8, 16, 16, '16-17' UNION ALL
	SELECT 9, 17, 17, '17-18' UNION ALL
	SELECT 10, 18, 18,'18-19' UNION ALL
	SELECT 11, 19, 19,'19-20' UNION ALL
	SELECT 12, 20, 20,'20-21' UNION ALL
	SELECT 13, 21, 21,'21-22' UNION ALL
	SELECT 14, 22, 23,'22-24') A;

	SELECT STOREID, STORE_NM, REGIONMANAGER_NM
		 , ROUND(SALE_0_10_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_0_10_PCT
		 , ROUND(SALE_10_11_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_10_11_PCT
		 , ROUND(SALE_11_12_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_11_12_PCT
		 , ROUND(SALE_12_13_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_12_13_PCT
		 , ROUND(SALE_13_14_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_13_14_PCT
		 , ROUND(SALE_14_15_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_14_15_PCT
		 , ROUND(SALE_15_16_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_15_16_PCT
		 , ROUND(SALE_16_17_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_16_17_PCT
		 , ROUND(SALE_17_18_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_17_18_PCT
		 , ROUND(SALE_18_19_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_18_19_PCT
		 , ROUND(SALE_19_20_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_19_20_PCT
		 , ROUND(SALE_20_21_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_20_21_PCT
		 , ROUND(SALE_21_22_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_21_22_PCT
		 , ROUND(SALE_22_24_AMT * 1.0 / TOTALSALE_AMT, 3) SALEAMT_22_24_PCT
		 , ROUND(SALE_0_10_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_0_10_PCT
		 , ROUND(SALE_10_11_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_10_11_PCT
		 , ROUND(SALE_11_12_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_11_12_PCT
		 , ROUND(SALE_12_13_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_12_13_PCT
		 , ROUND(SALE_13_14_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_13_14_PCT
		 , ROUND(SALE_14_15_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_14_15_PCT
		 , ROUND(SALE_15_16_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_15_16_PCT
		 , ROUND(SALE_16_17_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_16_17_PCT
		 , ROUND(SALE_17_18_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_17_18_PCT
		 , ROUND(SALE_18_19_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_18_19_PCT
		 , ROUND(SALE_19_20_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_19_20_PCT
		 , ROUND(SALE_20_21_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_20_21_PCT
		 , ROUND(SALE_21_22_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_21_22_PCT
		 , ROUND(SALE_22_24_QTY * 1.0 / TOTALSALE_QTY, 3) SALEQTY_22_24_PCT
		 , SALE_0_10_AMT, SALE_10_11_AMT, SALE_11_12_AMT, SALE_12_13_AMT, SALE_13_14_AMT, SALE_14_15_AMT, SALE_15_16_AMT
		 , SALE_16_17_AMT, SALE_17_18_AMT,SALE_18_19_AMT, SALE_19_20_AMT, SALE_20_21_AMT, SALE_21_22_AMT, SALE_22_24_AMT
		 , SALE_0_10_QTY, SALE_10_11_QTY, SALE_11_12_QTY, SALE_12_13_QTY, SALE_13_14_QTY, SALE_14_15_QTY, SALE_15_16_QTY
		 , SALE_16_17_QTY, SALE_17_18_QTY,SALE_18_19_QTY, SALE_19_20_QTY, SALE_20_21_QTY, SALE_21_22_QTY, SALE_22_24_QTY
	  FROM (
	SELECT ST.STOREID, ST.STORE_NM, RM.MANAGER_NM REGIONMANAGER_NM
		 , SUM(CASE WHEN H.ID = 1 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_0_10_AMT
		 , SUM(CASE WHEN H.ID = 2 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_10_11_AMT
		 , SUM(CASE WHEN H.ID = 3 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_11_12_AMT
		 , SUM(CASE WHEN H.ID = 4 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_12_13_AMT
		 , SUM(CASE WHEN H.ID = 5 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_13_14_AMT
		 , SUM(CASE WHEN H.ID = 6 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_14_15_AMT
		 , SUM(CASE WHEN H.ID = 7 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_15_16_AMT
		 , SUM(CASE WHEN H.ID = 8 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_16_17_AMT
		 , SUM(CASE WHEN H.ID = 9 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_17_18_AMT
		 , SUM(CASE WHEN H.ID = 10 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_18_19_AMT
		 , SUM(CASE WHEN H.ID = 11 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_19_20_AMT
		 , SUM(CASE WHEN H.ID = 12 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_20_21_AMT
		 , SUM(CASE WHEN H.ID = 13 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_21_22_AMT
		 , SUM(CASE WHEN H.ID = 14 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SALE_22_24_AMT
		 , SUM(SALE_AMT - REFUND_AMT) TOTALSALE_AMT
		 , SUM(CASE WHEN H.ID = 1 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_0_10_QTY
		 , SUM(CASE WHEN H.ID = 2 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_10_11_QTY
		 , SUM(CASE WHEN H.ID = 3 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_11_12_QTY
		 , SUM(CASE WHEN H.ID = 4 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_12_13_QTY
		 , SUM(CASE WHEN H.ID = 5 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_13_14_QTY
		 , SUM(CASE WHEN H.ID = 6 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_14_15_QTY
		 , SUM(CASE WHEN H.ID = 7 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_15_16_QTY
		 , SUM(CASE WHEN H.ID = 8 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_16_17_QTY
		 , SUM(CASE WHEN H.ID = 9 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_17_18_QTY
		 , SUM(CASE WHEN H.ID = 10 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_18_19_QTY
		 , SUM(CASE WHEN H.ID = 11 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_19_20_QTY
		 , SUM(CASE WHEN H.ID = 12 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_20_21_QTY
		 , SUM(CASE WHEN H.ID = 13 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_21_22_QTY
		 , SUM(CASE WHEN H.ID = 14 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SALE_22_24_QTY
		 , SUM(SALE_QTY + REFUND_QTY) TOTALSALE_QTY
	  FROM SLS_SALESUMMARYHOUR_SYN S
	  JOIN dbo.STR_GETUSERSTORES_FN() ST ON S.STORE = ST.STOREID
	  JOIN #HOURS H ON S.SALEHOUR BETWEEN H.MINHOUR AND H.MAXHOUR
	  LEFT JOIN STR_REGIONMANAGERS RM ON ST.REGIONMANAGER = RM.REGIONMANAGERSID
	 WHERE TRANSACTION_DT BETWEEN @StartDate AND @EndDate
	 GROUP BY ST.STOREID, ST.STORE_NM, RM.MANAGER_NM) A
	 ORDER BY TOTALSALE_AMT DESC
END