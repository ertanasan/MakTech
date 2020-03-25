CREATE PROCEDURE STR_LST_STORESALES_SP AS      
BEGIN      
  
  DECLARE @currentDate DATE = dbo.STR_GETUSERCURRENTDATE_FN();

  DECLARE @thisyear INT = DATEPART(YEAR, @currentDate);
  DECLARE @lastyear INT = @thisyear - 1;
  
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

  SELECT D.STORE store,     
	     ST.STORE_NM storename,
	     ST.TERMINAL terminal,
	     ST.REGION_NM parentbranch,
         ST.ACTIVE_FL isactive,
         TODAY_DT today,     
         DAILYSALE_AMT t_amount,     
         DAILYREFUND_AMT t_refund,    
         DAILYSALE_CNT t_sale,    
         DAILYREFUND_CNT t_refundcount,    
         DAILYSALEAVG_AMT t_saleavg,    
         LASTWEEKTODAY_DT lastweektoday,    
         LASTWEEKSALE_AMT lwt_amount,    
         LASTWEEKREFUND_AMT lwt_refund,    
         LASTWEEKSALE_CNT lwt_sale,    
         LASTWEEKREFUND_CNT lwt_refundcount,    
         LASTWEEKSALEAVG_AMT lwt_saleavg,    
         WEEK_NO weekno,    
         WEEKLYSALE_AMT weekly_amount,    
         WEEKLYREFUND_AMT weekly_refund,    
         WEEKLYSALE_CNT weekly_sale,    
         WEEKLYREFUND_CNT weekly_refundcount,    
         WEEKLYSALEAVG_AMT weekly_saleavg,    
         PREVWEEK_NO prevweekno,    
         PREVWEEKSALE_AMT prevweek_amount,    
         PREVWEEKREFUND_AMT prevweek_refund,    
         PREVWEEKSALE_CNT prevweek_sale,    
         PREVWEEKREFUND_CNT prevweek_refundcount,    
         PREVWEEKSALEAVG_AMT prevweek_saleavg,    
         YEARMONTH_NO yearmonth,    
         MONTHLYSALE_AMT monthly_amount,    
         MONTHLYREFUND_AMT monthly_refund,    
         MONTHLYSALE_CNT monthly_sale,    
         MONTHLYREFUND_CNT monthly_refundcount,    
         MONTHLYSALEAVG_AMT monthly_saleavg,    
         PREVYEARMONTH_NO prevyearmonth,    
         PREVMONTHSALE_AMT prevmonth_amount,    
         PREVMONTHREFUND_AMT prevmonth_refund,    
         PREVMONTHSALE_CNT prevmonth_sale,    
         PREVMONTHREFUND_CNT prevmonth_refundcount,    
         PREVMONTHSALEAVG_AMT prevmonth_saleavg,    
         YESTERDAY_DT yesterday,    
         YESTERDAYSALE_AMT y_amount,    
         YESTERDAYREFUND_AMT y_refund,    
         YESTERDAYSALE_CNT y_sale,    
         YESTERDAYREFUND_CNT y_refundcount,    
         YESTERDAYSALEAVG_AMT y_saleavg,    
         LWYESTERDAY_DT lastweekyesterday,    
         LWYESTERDAYSALE_AMT lwy_amount,    
         LWYESTERDAYREFUND_AMT lwy_refund,    
         LWYESTERDAYSALE_CNT lwy_sale,    
         LWYESTERDAYREFUND_CNT lwy_refundcount,    
         LWYESTERDAYSALEAVG_AMT lwy_saleavg,
	     
         YEAR_NO yearno,    
         ANNUALSALE_AMT annual_amount,    
         ANNUALREFUND_AMT annual_refund,    
         ANNUALSALE_CNT annual_sale,    
         ANNUALREFUND_CNT annual_refundcount,    
         ANNUALSALEAVG_AMT annual_saleavg,    
         PREVYEAR_NO prevyearno,    
         PREVYEARSALE_AMT prevyear_amount,    
         PREVYEARREFUND_AMT prevyear_refund,    
         PREVYEARSALE_CNT prevyear_sale,    
         PREVYEARREFUND_CNT prevyear_refundcount,    
         PREVYEARSALEAVG_AMT prevyear_saleavg,    
  	     
         MONTHDAY_CNT monthly_daycount,
         PREVMONTHDAY_CNT prevmonth_daycount,
         YEARDAY_CNT annual_daycount,
         PREVYEARDAY_CNT prevyear_daycount,

		 K.STOCKSALEPCT,
		 K.MAKBULORDER,
		 K.REGIONORDER,
		 K.REGIONSTORECOUNT
    FROM SLS_SALEDASHBOARD D    
	JOIN dbo.STR_GETUSERSTORESALL_FN() FN ON D.STORE = FN.STOREID
	JOIN STR_STOREALL_VW ST ON D.STORE = ST.STOREID
	LEFT JOIN #STOCKSALEKPI K ON ST.STOREID = K.STORE
   WHERE D.TODAY_DT = @currentDate
     AND (DATEPART(YEAR, ST.OPENING_DT) < @thisyear OR DATEPART(YEAR, ISNULL(ST.CLOSING_DT, '2050-12-31')) >= @lastyear)
   
END;  