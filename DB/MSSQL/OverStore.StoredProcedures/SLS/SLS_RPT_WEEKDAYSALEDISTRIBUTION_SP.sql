﻿CREATE PROCEDURE SLS_RPT_WEEKDAYSALEDISTRIBUTION_SP @StartDate DATE, @EndDate DATE AS
BEGIN

	SELECT STOREID, STORE_NM, REGIONMANAGER_NM
		 , ROUND(MONDAYSALE_AMT * 1.0 / TOTALSALE_AMT, 3) MONDAYAMT_PCT
		 , ROUND(TUESDAYSALE_AMT * 1.0 / TOTALSALE_AMT, 3) TUESDAYAMT_PCT
		 , ROUND(WEDNESDAYSALE_AMT * 1.0 / TOTALSALE_AMT, 3) WEDNESDAYAMT_PCT
		 , ROUND(THURSDAYSALE_AMT * 1.0 / TOTALSALE_AMT, 3) THURSDAYAMT_PCT
		 , ROUND(FRIDAYSALE_AMT * 1.0 / TOTALSALE_AMT, 3) FRIDAYAMT_PCT
		 , ROUND(SATURDAYSALE_AMT * 1.0 / TOTALSALE_AMT, 3) SATURDAYAMT_PCT
		 , ROUND(SUNDAYSALE_AMT * 1.0 / TOTALSALE_AMT, 3) SUNDAYAMT_PCT
		 , ROUND(MONDAYSALE_QTY * 1.0 / TOTALSALE_QTY, 3) MONDAYQTY_PCT
		 , ROUND(TUESDAYSALE_QTY * 1.0 / TOTALSALE_QTY, 3) TUESDAYQTY_PCT
		 , ROUND(WEDNESDAYSALE_QTY * 1.0 / TOTALSALE_QTY, 3) WEDNESDAYQTY_PCT
		 , ROUND(THURSDAYSALE_QTY * 1.0 / TOTALSALE_QTY, 3) THURSDAYQTY_PCT
		 , ROUND(FRIDAYSALE_QTY * 1.0 / TOTALSALE_QTY, 3) FRIDAYQTY_PCT
		 , ROUND(SATURDAYSALE_QTY * 1.0 / TOTALSALE_QTY, 3) SATURDAYQTY_PCT
		 , ROUND(SUNDAYSALE_QTY * 1.0 / TOTALSALE_QTY, 3) SUNDAYQTY_PCT
		 , MONDAYSALE_AMT, TUESDAYSALE_AMT, WEDNESDAYSALE_AMT, THURSDAYSALE_AMT, FRIDAYSALE_AMT, SATURDAYSALE_AMT, SUNDAYSALE_AMT
		 , MONDAYSALE_QTY, TUESDAYSALE_QTY, WEDNESDAYSALE_QTY, THURSDAYSALE_QTY, FRIDAYSALE_QTY, SATURDAYSALE_QTY, SUNDAYSALE_QTY
	  FROM (
	SELECT ST.STOREID, ST.STORE_NM, RM.MANAGER_NM REGIONMANAGER_NM
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 1 THEN SALE_AMT - REFUND_AMT ELSE 0 END) MONDAYSALE_AMT
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 2 THEN SALE_AMT - REFUND_AMT ELSE 0 END) TUESDAYSALE_AMT
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 3 THEN SALE_AMT - REFUND_AMT ELSE 0 END) WEDNESDAYSALE_AMT
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 4 THEN SALE_AMT - REFUND_AMT ELSE 0 END) THURSDAYSALE_AMT
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 5 THEN SALE_AMT - REFUND_AMT ELSE 0 END) FRIDAYSALE_AMT
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 6 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SATURDAYSALE_AMT
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 7 THEN SALE_AMT - REFUND_AMT ELSE 0 END) SUNDAYSALE_AMT
		 , SUM(SALE_AMT - REFUND_AMT) TOTALSALE_AMT
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 1 THEN SALE_QTY + REFUND_QTY ELSE 0 END) MONDAYSALE_QTY
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 2 THEN SALE_QTY + REFUND_QTY ELSE 0 END) TUESDAYSALE_QTY
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 3 THEN SALE_QTY + REFUND_QTY ELSE 0 END) WEDNESDAYSALE_QTY
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 4 THEN SALE_QTY + REFUND_QTY ELSE 0 END) THURSDAYSALE_QTY
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 5 THEN SALE_QTY + REFUND_QTY ELSE 0 END) FRIDAYSALE_QTY
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 6 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SATURDAYSALE_QTY
		 , SUM(CASE WHEN DT.DAYOFWEEK_NO = 7 THEN SALE_QTY + REFUND_QTY ELSE 0 END) SUNDAYSALE_QTY
		 , SUM(SALE_QTY + REFUND_QTY) TOTALSALE_QTY
	  FROM SLS_SALESUMMARYHOUR_SYN S
	  JOIN dbo.STR_GETUSERSTORES_FN() ST ON S.STORE = ST.STOREID
	  JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
	  LEFT JOIN STR_REGIONMANAGERS RM ON ST.REGIONMANAGER = RM.REGIONMANAGERSID
	 WHERE TRANSACTION_DT BETWEEN @StartDate AND @EndDate
	 GROUP BY ST.STOREID, ST.STORE_NM, RM.MANAGER_NM) A
	 ORDER BY TOTALSALE_AMT DESC
END