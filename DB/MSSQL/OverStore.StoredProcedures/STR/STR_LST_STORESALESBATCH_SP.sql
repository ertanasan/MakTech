CREATE PROCEDURE STR_LST_STORESALESBATCH_SP AS
BEGIN          
          
 IF OBJECT_ID('tempdb..#dailyvalues') IS NOT NULL DROP TABLE #dailyvalues          
 IF OBJECT_ID('tempdb..#lastweektoday') IS NOT NULL DROP TABLE #lastweektoday          
 IF OBJECT_ID('tempdb..#weeklyvalues') IS NOT NULL DROP TABLE #weeklyvalues          
 IF OBJECT_ID('tempdb..#lastweek') IS NOT NULL DROP TABLE #lastweek          
 IF OBJECT_ID('tempdb..#monthlyvalues') IS NOT NULL DROP TABLE #monthlyvalues          
 IF OBJECT_ID('tempdb..#annualvalues') IS NOT NULL DROP TABLE #annualvalues
 IF OBJECT_ID('tempdb..#prevyear') IS NOT NULL DROP TABLE #prevyear
 IF OBJECT_ID('tempdb..#prevmonth') IS NOT NULL DROP TABLE #prevmonth          
 IF OBJECT_ID('tempdb..#yesterdayvalues') IS NOT NULL DROP TABLE #yesterdayvalues          
 IF OBJECT_ID('tempdb..#lastweekyesterday') IS NOT NULL DROP TABLE #lastweekyesterday          
 IF OBJECT_ID('tempdb..#resulttable') IS NOT NULL DROP TABLE #resulttable      
 IF OBJECT_ID('tempdb..#finalresult') IS NOT NULL DROP TABLE #finalresult
           
 declare @now datetime = getdate();          
          
 declare @time time = cast(getdate() as time);          
 if @time < '09:30' 
 begin
    set @now = @now - 1;          
    set @time = '23:59'
 end
           
 declare @today DATE = cast(@now as DATE);          
 declare @yesterday date = CAST(@now-1 AS DATE);          
 declare @lastweektoday DATE = CAST(@now-7 AS DATE);          
 declare @lastweekyesterday DATE = CAST(@now-8 AS DATE);          
 declare @weekno int, @prevweekno int, @yearmonth int, @prevyearmonth int;          
 select @weekno = yearweek_no, @yearmonth = left(STYLE112_TXT,6) from RPT_DATE where date_dt = @today          
 declare @prevyear int = DATEPART(YEAR, DATEADD(YEAR, -1, @today))

 select @prevweekno = yearweek_no            
   from RPT_DATE (nolock)          
  where date_dt = (          
 select max(d1.DATE_DT)          
   from RPT_DATE (nolock) d1          
  where d1.date_dt < @today          
    and d1.yearweek_no != @weekno)          
 select @prevyearmonth = left(STYLE112_TXT,6)            
   from RPT_DATE (nolock)          
  where date_dt = (          
 select max(d1.DATE_DT)          
   from RPT_DATE (nolock) d1          
  where d1.date_dt < @today          
    and left(d1.STYLE112_TXT,6)  != @yearmonth)     
   
 --SELECT @today, @weekno, @prevweekno  
          
 select STORE, s.TRANSACTION_DT          
      , sum(s.total_amt) NETAMOUNTVAT          
      , sum(case when s.TRANSACTIONTYPE != 5 THEN S.TOTAL_AMT ELSE 0 END) AMOUNTVAT          
      , -1*sum(case when s.TRANSACTIONTYPE = 5 THEN S.TOTAL_AMT ELSE 0 END) REFUNDAMOUNTVAT          
      , sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) SALE          
      , sum(case when s.TRANSACTIONTYPE = 5 THEN 1 ELSE 0 END) REFUND          
      , sum(case when s.TRANSACTIONTYPE != 5 THEN S.TOTAL_AMT ELSE 0 END) / sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) SALEAVG          
      , max(s.TRANSACTION_TM) LASTTIME          
   into #dailyvalues          
   from sls_sale (nolock) s where TRANSACTION_DT = @today and cancelled_fl = 'N'
  group by store, s.TRANSACTION_DT       
 having sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) <> 0  

 SELECT STORE, TRANSACTION_DT, SALE_AMT + REFUND_AMT NETAMOUNTVAT, 
 	    SALE_AMT AMOUNTVAT, -1*REFUND_AMT REFUNDAMOUNTVAT,
 	    SALE_QTY SALE, REFUND_QTY REFUND, SALE_AMT / SALE_QTY SALEAVG
   INTO #yesterdayvalues
   FROM SLS_STOREDAILYPAYMENT_SYN
  WHERE TRANSACTION_DT = @yesterday
    AND SALE_QTY <> 0

 -- BUGUN'E GORE GEÇEN HAFTA BUGUN          
 select s.store, s.TRANSACTION_DT, sum(s.total_amt) NETAMOUNTVAT          
      , sum(case when s.TRANSACTIONTYPE != 5 THEN S.TOTAL_AMT ELSE 0 END) AMOUNTVAT          
      , -1*sum(case when s.TRANSACTIONTYPE = 5 THEN S.TOTAL_AMT ELSE 0 END) REFUNDAMOUNTVAT          
      , sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) SALE          
      , sum(case when s.TRANSACTIONTYPE = 5 THEN 1 ELSE 0 END) REFUND          
      , sum(case when s.TRANSACTIONTYPE != 5 THEN S.TOTAL_AMT ELSE 0 END) / sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) SALEAVG          
      , max(s.TRANSACTION_TM) LASTTIME          
   into #lastweektoday          
   from sls_sale (nolock) s          
   join #dailyvalues dv on s.STORE = dv.STORE          
  where S.TRANSACTION_DT = @lastweektoday   
    and cancelled_fl = 'N'
    and cast(TRANSACTION_TM AS TIME) <= cast(LASTTIME AS TIME)           
  group by s.store, s.TRANSACTION_DT          
          
 SELECT STORE, TRANSACTION_DT, SALE_AMT + REFUND_AMT NETAMOUNTVAT, 
  	    SALE_AMT AMOUNTVAT, -1*REFUND_AMT REFUNDAMOUNTVAT,
  	    SALE_QTY SALE, REFUND_QTY REFUND, SALE_AMT / SALE_QTY SALEAVG
   INTO #lastweekyesterday
   FROM SLS_STOREDAILYPAYMENT_SYN
  WHERE TRANSACTION_DT = @lastweekyesterday
    AND SALE_QTY <> 0

 -- HAFTALIK TOPLAMLAR          
 SELECT STORE, CAST(RIGHT(@weekno,2) AS int) week_no, SUM(COUNTOFDAYS) gunsayi, SUM(AMOUNTVAT) AMOUNTVAT, SUM(REFUNDAMOUNTVAT) REFUNDAMOUNTVAT
 	  , SUM(SALE) SALE, SUM(REFUND) REFUND, SUM(AMOUNTVAT) / SUM(SALE) SALEAVG, MAX(LASTTIME) LASTTIME
   INTO #weeklyvalues
   FROM (
 SELECT S.STORE, COUNT(*) COUNTOFDAYS,  SUM(SALE_AMT + REFUND_AMT) NETAMOUNTVAT, 
 	    SUM(SALE_AMT) AMOUNTVAT, SUM(-1*REFUND_AMT) REFUNDAMOUNTVAT,
 	    SUM(SALE_QTY) SALE, SUM(REFUND_QTY) REFUND, MAX(S.TRANSACTION_DT) LASTTIME
   FROM SLS_STOREDAILYPAYMENT_SYN S
   JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
  WHERE DT.YEARWEEK_NO = @weekno
    AND S.TRANSACTION_DT < @today
  GROUP BY S.STORE
  UNION ALL SELECT STORE, 1, NETAMOUNTVAT, AMOUNTVAT, REFUNDAMOUNTVAT, SALE, REFUND, LASTTIME FROM  #dailyvalues) A
  GROUP BY STORE
 HAVING SUM(SALE) <> 0

 -- BU HAFTAYA GÖRE GEÇEN HAFTA          
 SELECT STORE, CAST(RIGHT(@prevweekno,2) AS int) week_no, SUM(AMOUNTVAT) AMOUNTVAT, SUM(REFUNDAMOUNTVAT) REFUNDAMOUNTVAT
 	  , SUM(SALE) SALE, SUM(REFUND) REFUND, SUM(AMOUNTVAT) / SUM(SALE) SALEAVG
   INTO #lastweek
   FROM (
 SELECT S.STORE, SUM(SALE_AMT + REFUND_AMT) NETAMOUNTVAT, 
 	    SUM(SALE_AMT) AMOUNTVAT, SUM(-1*REFUND_AMT) REFUNDAMOUNTVAT,
 	    SUM(SALE_QTY) SALE, SUM(REFUND_QTY) REFUND
   FROM SLS_STOREDAILYPAYMENT_SYN S
   JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
  WHERE DT.YEARWEEK_NO = @prevweekno
    AND S.TRANSACTION_DT < @lastweektoday
  GROUP BY S.STORE
  UNION ALL SELECT STORE, NETAMOUNTVAT, AMOUNTVAT, REFUNDAMOUNTVAT, SALE, REFUND FROM  #lastweektoday) A
  GROUP BY STORE
 HAVING SUM(SALE) <> 0
          
 -- AYLIK SATIŞLAR          
 SELECT STORE, @yearmonth yearmonth, SUM(COUNTOFDAYS) numberofdays, SUM(AMOUNTVAT) AMOUNTVAT, SUM(REFUNDAMOUNTVAT) REFUNDAMOUNTVAT
 	  , SUM(SALE) SALE, SUM(REFUND) REFUND, SUM(AMOUNTVAT) / SUM(SALE) SALEAVG, MAX(LASTTIME) LASTTIME
   into #monthlyvalues          
   FROM (
 SELECT S.STORE, COUNT(*) COUNTOFDAYS,  SUM(SALE_AMT + REFUND_AMT) NETAMOUNTVAT, 
 	    SUM(SALE_AMT) AMOUNTVAT, SUM(-1*REFUND_AMT) REFUNDAMOUNTVAT,
 	    SUM(SALE_QTY) SALE, SUM(REFUND_QTY) REFUND, MAX(TRANSACTION_DT) LASTTIME
   FROM SLS_STOREDAILYPAYMENT_SYN S
   JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
  WHERE DT.YEARMONTH_NO = @yearmonth
    AND S.TRANSACTION_DT < @today
  GROUP BY S.STORE
  UNION ALL SELECT STORE, 1, NETAMOUNTVAT, AMOUNTVAT, REFUNDAMOUNTVAT, SALE, REFUND, LASTTIME FROM  #dailyvalues) A
  GROUP BY STORE
 HAVING SUM(SALE) <> 0;

 -- ÖNCEKİ AY SATIŞLAR          
 WITH LASTMONTHTODAY AS (
 select s.store, s.TRANSACTION_DT, sum(s.total_amt) NETAMOUNTVAT          
       , sum(case when s.TRANSACTIONTYPE != 5 THEN S.TOTAL_AMT ELSE 0 END) AMOUNTVAT          
       , -1*sum(case when s.TRANSACTIONTYPE = 5 THEN S.TOTAL_AMT ELSE 0 END) REFUNDAMOUNTVAT          
       , sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) SALE          
       , sum(case when s.TRANSACTIONTYPE = 5 THEN 1 ELSE 0 END) REFUND          
       , sum(case when s.TRANSACTIONTYPE != 5 THEN S.TOTAL_AMT ELSE 0 END) / sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) SALEAVG          
       , max(s.TRANSACTION_TM) LASTTIME          
    from sls_sale (nolock) s          
    -- join #dailyvalues dv on s.STORE = dv.STORE          
   where S.TRANSACTION_DT = DATEADD(MONTH, -1, @today)
     and cancelled_fl = 'N'
     and cast(TRANSACTION_TM AS TIME) <= @time
   group by s.store, s.TRANSACTION_DT) 
 SELECT STORE, @prevyearmonth yearmonth, SUM(numberofdays) numberofdays, SUM(AMOUNTVAT) AMOUNTVAT, SUM(REFUNDAMOUNTVAT) REFUNDAMOUNTVAT
 	 , SUM(SALE) SALE, SUM(REFUND) REFUND, SUM(AMOUNTVAT) / SUM(SALE) SALEAVG
   INTO #prevmonth
   FROM (
 SELECT S.STORE, COUNT(*) numberofdays, SUM(SALE_AMT + REFUND_AMT) NETAMOUNTVAT, 
 	   SUM(SALE_AMT) AMOUNTVAT, SUM(-1*REFUND_AMT) REFUNDAMOUNTVAT,
 	   SUM(SALE_QTY) SALE, SUM(REFUND_QTY) REFUND
   FROM SLS_STOREDAILYPAYMENT_SYN S
   JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
  WHERE DT.YEARMONTH_NO = @prevyearmonth
    AND S.TRANSACTION_DT < DATEADD(MONTH, -1, @today)
  GROUP BY S.STORE
  UNION ALL SELECT STORE, 1, NETAMOUNTVAT, AMOUNTVAT, REFUNDAMOUNTVAT, SALE, REFUND FROM  LASTMONTHTODAY) A
  GROUP BY STORE
 HAVING SUM(SALE) <> 0
          
 -- YILLIK SATIŞLAR          
 SELECT STORE, DATEPART(YEAR, @today) year_no, SUM(COUNTOFDAYS) numberofdays, SUM(AMOUNTVAT) AMOUNTVAT, SUM(REFUNDAMOUNTVAT) REFUNDAMOUNTVAT
 	  , SUM(SALE) SALE, SUM(REFUND) REFUND, SUM(AMOUNTVAT) / SUM(SALE) SALEAVG, MAX(LASTTIME) LASTTIME
   into #annualvalues
   FROM (
 SELECT S.STORE, COUNT(*) COUNTOFDAYS,  SUM(SALE_AMT + REFUND_AMT) NETAMOUNTVAT, 
 	    SUM(SALE_AMT) AMOUNTVAT, SUM(-1*REFUND_AMT) REFUNDAMOUNTVAT,
 	    SUM(SALE_QTY) SALE, SUM(REFUND_QTY) REFUND, MAX(TRANSACTION_DT) LASTTIME
   FROM SLS_STOREDAILYPAYMENT_SYN S
   JOIN RPT_DATE TODAYDT ON TODAYDT.DATE_DT = @today
   JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT AND DT.YEAR_NO = TODAYDT.YEAR_NO
  WHERE S.TRANSACTION_DT < @today
  GROUP BY S.STORE 
  UNION ALL SELECT STORE, 1, NETAMOUNTVAT, AMOUNTVAT, REFUNDAMOUNTVAT, SALE, REFUND, LASTTIME FROM  #dailyvalues) A
  GROUP BY STORE
 HAVING SUM(SALE) <> 0;

-- ÖNCEKİ YIL SATIŞLAR          
 WITH LASTYEARTODAY AS (
 select s.store, s.TRANSACTION_DT, sum(s.total_amt) NETAMOUNTVAT          
       , sum(case when s.TRANSACTIONTYPE != 5 THEN S.TOTAL_AMT ELSE 0 END) AMOUNTVAT          
       , -1*sum(case when s.TRANSACTIONTYPE = 5 THEN S.TOTAL_AMT ELSE 0 END) REFUNDAMOUNTVAT          
       , sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) SALE          
       , sum(case when s.TRANSACTIONTYPE = 5 THEN 1 ELSE 0 END) REFUND          
       , sum(case when s.TRANSACTIONTYPE != 5 THEN S.TOTAL_AMT ELSE 0 END) / sum(case when s.TRANSACTIONTYPE != 5 THEN 1 ELSE 0 END) SALEAVG          
       , max(s.TRANSACTION_TM) LASTTIME          
    from sls_sale (nolock) s          
    -- join #dailyvalues dv on s.STORE = dv.STORE          
   where S.TRANSACTION_DT = DATEADD(YEAR, -1, @today)
     and cancelled_fl = 'N'
     and cast(TRANSACTION_TM AS TIME) <= @time
   group by s.store, s.TRANSACTION_DT) 
 SELECT STORE, @prevyear year_no, SUM(numberofdays) numberofdays, SUM(AMOUNTVAT) AMOUNTVAT, SUM(REFUNDAMOUNTVAT) REFUNDAMOUNTVAT
 	  , SUM(SALE) SALE, SUM(REFUND) REFUND, SUM(AMOUNTVAT) / SUM(SALE) SALEAVG
   INTO #prevyear
   FROM (
 SELECT S.STORE, COUNT(*) numberofdays, SUM(SALE_AMT + REFUND_AMT) NETAMOUNTVAT, 
 	   SUM(SALE_AMT) AMOUNTVAT, SUM(-1*REFUND_AMT) REFUNDAMOUNTVAT,
 	   SUM(SALE_QTY) SALE, SUM(REFUND_QTY) REFUND
   FROM SLS_STOREDAILYPAYMENT_SYN S
   JOIN RPT_DATE DT ON S.TRANSACTION_DT = DT.DATE_DT
  WHERE DT.YEAR_NO = @prevyear
    AND S.TRANSACTION_DT < DATEADD(YEAR, -1, @today)
  GROUP BY S.STORE
  UNION ALL SELECT STORE, 1, NETAMOUNTVAT, AMOUNTVAT, REFUNDAMOUNTVAT, SALE, REFUND FROM  LASTYEARTODAY) A
  GROUP BY STORE
 HAVING SUM(SALE) <> 0
          
  select s.STOREID store          
       , cast(dv.TRANSACTION_DT as date) today, dv.AMOUNTVAT t_amount, dv.REFUNDAMOUNTVAT t_refund, dv.SALE t_sale, dv.REFUND t_refundcount, dv.SALEAVG t_saleavg          
       , cast(lwt.TRANSACTION_DT as date) lastweektoday, lwt.AMOUNTVAT lwt_amount, lwt.REFUNDAMOUNTVAT lwt_refund, lwt.SALE lwt_sale, lwt.REFUND lwt_refundcount, lwt.SALEAVG lwt_saleavg          
       , wv.week_no weekno, wv.AMOUNTVAT weekly_amount, wv.REFUNDAMOUNTVAT weekly_refund, wv.SALE weekly_sale, wv.REFUND weekly_refundcount, wv.SALEAVG weekly_saleavg          
       , lw.WEEK_NO prevweekno, lw.AMOUNTVAT prevweek_amount, lw.REFUNDAMOUNTVAT prevweek_refund, lw.SALE prevweek_sale, lw.REFUND prevweek_refundcount, lw.SALEAVG prevweek_saleavg          
       , mw.yearmonth yearmonth, mw.AMOUNTVAT monthly_amount, mw.REFUNDAMOUNTVAT monthly_refund, mw.SALE monthly_sale, mw.REFUND monthly_refundcount, mw.SALEAVG monthly_saleavg          
       , pm.yearmonth prevyearmonth, pm.AMOUNTVAT prevmonth_amount, pm.REFUNDAMOUNTVAT prevmonth_refund, pm.SALE prevmonth_sale, pm.REFUND prevmonth_refundcount, pm.SALEAVG prevmonth_saleavg          
       , cast(y.TRANSACTION_DT as date) yesterday, y.AMOUNTVAT y_amount, y.REFUNDAMOUNTVAT y_refund, y.SALE y_sale, y.REFUND y_refundcount, y.SALEAVG y_saleavg          
       , cast(lwy.TRANSACTION_DT as date) lastweekyesterday, lwy.AMOUNTVAT lwy_amount, lwy.REFUNDAMOUNTVAT lwy_refund, lwy.SALE lwy_sale, lwy.REFUND lwy_refundcount, lwy.SALEAVG lwy_saleavg
	   , av.year_no yearno, av.AMOUNTVAT annual_amount, av.REFUNDAMOUNTVAT annual_refund, av.SALE annual_sale, av.REFUND annual_refundcount, av.SALEAVG annual_saleavg
	   , py.year_no prevyearno, py.AMOUNTVAT prevyear_amount, py.REFUNDAMOUNTVAT prevyear_refund, py.SALE prevyear_sale, py.REFUND prevyear_refundcount, py.SALEAVG prevyear_saleavg
       , mw.numberofdays month_nofdays, pm.numberofdays prevmonth_nofdays, av.numberofdays annual_nofdays, py.numberofdays prevyear_nofdays
	   , dv.LASTTIME daily_lasttime
    into #resulttable    
    from str_store (nolock) s          
    left join #dailyvalues dv on s.STOREID = dv.store          
    left join #lastweektoday lwt on s.STOREID = lwt.store          
    left join #weeklyvalues wv on s.STOREID = wv.store          
    left join #lastweek lw on s.STOREID = lw.store          
    left join #monthlyvalues mw on s.STOREID = mw.store          
    left join #prevmonth pm on s.STOREID = pm.store          
    left join #yesterdayvalues y on s.STOREID = y.store          
    left join #lastweekyesterday lwy on s.STOREID = lwy.store 
	left join #annualvalues av on s.STOREID = av.STORE
	left join #prevyear py on s.STOREID = py.STORE
   -- where PRODUCTION_FL = 'Y'          
    
   delete from SLS_SALEDASHBOARD WHERE TODAY_DT = @today
   -- truncate table SLS_SALEDASHBOARD    
    
   insert into SLS_SALEDASHBOARD    
   select store STORE, @today TODAY_DT, t_amount DAILYSALE_AMT, t_refund DAILYREFUND_AMT, t_sale DAILYSALE_CNT, t_refund DAILYREFUND_CNT, t_saleavg DAILYSALEAVG_AMT         
		, lastweektoday LASTWEEKTODAY_DT, lwt_amount LASTWEEKSALE_AMT, lwt_refund LASTWEEKREFUND_AMT, lwt_sale LASTWEEKSALE_CNT, lwt_refund LASTWEEKREFUND_CNT, lwt_saleavg LASTWEEKSALEAVG_AMT    
		, weekno WEEK_NO, weekly_amount WEEKLYSALE_AMT, weekly_refund WEEKLYREFUND_AMT, weekly_sale WEEKLYSALE_CNT, weekly_refund WEEKLYREFUND_CNT, weekly_saleavg WEEKLYSALEAVG_AMT    
		, prevweekno PREVWEEK_NO, prevweek_amount PREVWEEKSALE_AMT, prevweek_refund PREVWEEKREFUND_AMT, prevweek_sale PREVWEEKSALE_CNT, prevweek_refund PREVWEEKREFUND_CNT, prevweek_saleavg PREVWEEKSALEAVG_AMT         
		, yearmonth YEARMONTH_NO, monthly_amount MONTHLYSALE_AMT, monthly_refund MONTHLYREFUND_AMT, monthly_sale MONTHLYSALE_CNT, monthly_refund MONTHLYREFUND_CNT, monthly_saleavg MONTHLYSALEAVG_AMT    
		, prevyearmonth PREVYEARMONTH_NO, prevmonth_amount PREVMONTHSALE_AMT, prevmonth_refund PREVMONTHREFUND_AMT, prevmonth_sale PREVMONTHSALE_CNT, prevmonth_refund PREVMONTHREFUND_CNT, prevmonth_saleavg PREVMONTHSALEAVG_AMT    
		, yesterday YESTERDAY_DT, y_amount YESTERDAYSALE_AMT, y_refund YESTERDAYREFUND_AMT, y_sale YESTERDAYSALE_CNT, y_refund YESTERDAYREFUND_CNT, y_saleavg YESTERDAYSALEAVG_AMT    
		, lastweekyesterday LWYESTERDAY_DT, lwy_amount LWYESTERDAYSALE_AMT, lwy_refund LWYESTERDAYREFUND_AMT, lwy_sale LWYESTERDAYSALE_CNT, lwy_refund LWYESTERDAYREFUND_CNT, lwy_saleavg LWYESTERDAYSALEAVG_AMT    
		, daily_lasttime DAILYLAST_TM
        , yearno YEAR_NO, annual_amount ANNUALSALE_AMT, annual_refund ANNUALREFUND_AMT, annual_sale ANNUALSALE_CNT, annual_refundcount ANNUALREFUND_CNT, annual_saleavg ANNUALSALEAVG_AMT    
		, prevyearno PREVYEAR_NO, prevyear_amount PREVYEARSALE_AMT, prevyear_refund PREVYEARREFUND_AMT, prevyear_sale PREVYEARSALE_CNT, prevyear_refundcount PREVYEARREFUND_CNT, prevyear_saleavg PREVYEARSALEAVG_AMT   
        , month_nofdays, prevmonth_nofdays, annual_nofdays, prevyear_nofdays
	 from #resulttable    
          
END; 