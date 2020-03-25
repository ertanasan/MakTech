﻿CREATE PROCEDURE STR_LST_STORESALESDET_SP AS  
BEGIN  
	IF OBJECT_ID('tempdb..#STOCKSALEKPI') IS NOT NULL DROP TABLE #STOCKSALEKPI
	SELECT *, ROW_NUMBER() OVER (ORDER BY STOCKSALEPCT) MAKBULORDER, 
  			ROW_NUMBER() OVER (PARTITION BY REGIONMANAGER ORDER BY STOCKSALEPCT) REGIONORDER,
			COUNT(*) OVER (PARTITION BY REGIONMANAGER) REGIONSTORECOUNT
	  INTO #STOCKSALEKPI
	  FROM (
	SELECT CS.STORE, REGIONMANAGER, ROUND(SUM(CS.STOCK * SP.PRICE_AMT) / SUM(CS.AVGDAILYSALE * SP.PRICE_AMT), 2) STOCKSALEPCT
	  FROM INV_CURRENTSTOCK CS
	  JOIN PRC_SALEPRICE_VW SP ON CS.PRODUCT = SP.PRODUCT
	  JOIN STR_STORE ST ON CS.STORE = ST.STOREID
	 GROUP BY CS.STORE, REGIONMANAGER
	HAVING SUM(CS.AVGDAILYSALE * SP.PRICE_AMT) > 1000) A

	DECLARE @currentDate DATE = dbo.STR_GETUSERCURRENTDATE_FN();
	SELECT A.*
      FROM (
	 SELECT S.STOREID, S.STORE_NM, DB.DAILYLAST_TM LASTTRANSACTION_TM, 
  			DB.DAILYSALE_AMT - DB.DAILYREFUND_AMT DAILY_AMT, 
			DB.LASTWEEKSALE_AMT - DB.LASTWEEKREFUND_AMT LASTWEEKDAILY_AMT, 
			CASE WHEN (DB.LASTWEEKSALE_AMT - DB.LASTWEEKREFUND_AMT) != 0 THEN (DB.DAILYSALE_AMT - DB.DAILYREFUND_AMT - DB.LASTWEEKSALE_AMT + DB.LASTWEEKREFUND_AMT) * 1.0 / (DB.LASTWEEKSALE_AMT - DB.LASTWEEKREFUND_AMT) ELSE 0 END DAILY_PCT,
  			DB.WEEKLYSALE_AMT-DB.WEEKLYREFUND_AMT WEEKLY_AMT, 
			DB.PREVWEEKSALE_AMT - DB.PREVWEEKREFUND_AMT PREVWEEK_AMT, 
			CASE WHEN (DB.PREVWEEKSALE_AMT - DB.PREVWEEKREFUND_AMT) != 0 THEN (DB.WEEKLYSALE_AMT - DB.WEEKLYREFUND_AMT - DB.PREVWEEKSALE_AMT + DB.PREVWEEKREFUND_AMT) * 1.0 / (DB.PREVWEEKSALE_AMT - DB.PREVWEEKREFUND_AMT) ELSE 0 END WEEKLY_PCT,
  			DB.MONTHLYSALE_AMT - DB.MONTHLYREFUND_AMT MONTHLY_AMT,
			DB.PREVMONTHSALE_AMT - DB.PREVMONTHREFUND_AMT PREVMONTH_AMT, 
			CASE WHEN (DB.PREVMONTHSALE_AMT -DB.PREVMONTHREFUND_AMT) != 0 THEN (DB.MONTHLYSALE_AMT - DB.MONTHLYREFUND_AMT - DB.PREVMONTHSALE_AMT + DB.PREVMONTHREFUND_AMT) * 1.0 / (DB.PREVMONTHSALE_AMT - DB.PREVMONTHREFUND_AMT) ELSE 0 END MONTHLY_PCT,
  			CAST(ROW_NUMBER() OVER (ORDER BY DB.DAILYSALE_AMT-DB.DAILYREFUND_AMT DESC) AS VARCHAR(4))+' / '+
  			CAST(ROW_NUMBER() OVER (ORDER BY DB.WEEKLYSALE_AMT-DB.WEEKLYREFUND_AMT DESC) AS VARCHAR(4))+' / '+ 
  			CAST(ROW_NUMBER() OVER (ORDER BY DB.MONTHLYSALE_AMT-DB.MONTHLYREFUND_AMT DESC) AS VARCHAR(4)) STORERANK,
  			RM.MANAGER_NM,
  			CAST(ROW_NUMBER() OVER (PARTITION BY S.REGIONMANAGER ORDER BY DB.DAILYSALE_AMT-DB.DAILYREFUND_AMT DESC) AS VARCHAR(4))+' / '+
  			CAST(ROW_NUMBER() OVER (PARTITION BY S.REGIONMANAGER ORDER BY DB.WEEKLYSALE_AMT-DB.WEEKLYREFUND_AMT DESC) AS VARCHAR(4))+' / '+ 
  			CAST(ROW_NUMBER() OVER (PARTITION BY S.REGIONMANAGER ORDER BY DB.MONTHLYSALE_AMT-DB.MONTHLYREFUND_AMT DESC) AS VARCHAR(4)) REGIONRANK,
			SSKPI.STOCKSALEPCT, MAKBULORDER, REGIONORDER, REGIONSTORECOUNT
	   FROM STR_STORE (nolock) S
	   LEFT JOIN STR_REGIONMANAGERS RM ON S.REGIONMANAGER = RM.REGIONMANAGERSID
	   JOIN SLS_SALEDASHBOARD DB ON S.STOREID = DB.STORE AND TODAY_DT = @currentDate
	   LEFT JOIN #STOCKSALEKPI SSKPI ON S.STOREID = SSKPI.STORE) A
	JOIN dbo.STR_GETUSERSTORES_FN() US ON A.STOREID = US.STOREID
    ORDER BY 4 desc
END;