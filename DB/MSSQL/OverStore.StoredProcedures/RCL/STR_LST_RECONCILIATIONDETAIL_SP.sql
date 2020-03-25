CREATE PROCEDURE STR_LST_RECONCILIATIONDETAIL_SP @StoreId INT = -1, @StartDate DATE, @EndDate DATE AS

BEGIN

  IF OBJECT_ID('tempdb.dbo.#sales', 'U') IS NOT NULL  DROP TABLE #sales;
  IF OBJECT_ID('tempdb.dbo.#rec', 'U') IS NOT NULL  DROP TABLE #rec;
  IF OBJECT_ID('tempdb.dbo.#loomis', 'U') IS NOT NULL  DROP TABLE #loomis;
  IF OBJECT_ID('tempdb.dbo.#kk', 'U') IS NOT NULL  DROP TABLE #kk;
  
  SELECT Z.*
    INTO #sales
    FROM SLS_SALEZETCOMPARE_VW Z
   WHERE Z.DATE_DT BETWEEN @StartDate AND @EndDate 
  
  SELECT *
    INTO #rec
    FROM (
  SELECT STORE, TRANSACTION_DT, TOBANK_AMT, CARDTOTAL_AMT
    FROM (
  select STORE, TRANSACTION_DT, TOBANK_AMT, CARDTOTAL_AMT, ROW_NUMBER() OVER (PARTITION BY STORE, TRANSACTION_DT ORDER BY CREATE_DT DESC) ROWNO
    from RCL_RECONCILIATION R
   WHERE R.TRANSACTION_DT BETWEEN @StartDate AND @EndDate 
     AND DELETED_FL = 'N') A
   WHERE ROWNO = 1
   UNION ALL
  SELECT STORE, RECONCILIATION_DT, BANK_AMT, CARD_AMT
    FROM RCL_STORE
   WHERE RECONCILIATION_DT BETWEEN @StartDate AND @EndDate 
     AND DELETED_FL = 'N'
     AND COMPLETE_FL = 'Y') AA
  
  select cha_kod, cha_tarihi, sum(cha_meblag) cha_meblag, cast(right(cha_kod,3) as int) magaza, count(*) adet
    into #loomis
    from MIK_CURRENTTRANSACTION_SYN (NOLOCK) T
   WHERE T.cha_belge_tarih BETWEEN @StartDate AND @EndDate 
     and cha_evrakno_seri = 'ML'
     and cha_kod != '100.01.999'
   group by cha_kod, cha_tarihi
  
  select cha_tarihi, sum(cha_meblag) cha_meblag, cast(right(cha_kod,3) as int) magaza, count(*) adet
    into #kk
    from MIK_CURRENTTRANSACTION_SYN (NOLOCK) T
   WHERE T.cha_tarihi BETWEEN @StartDate AND @EndDate 
     and cha_evrakno_seri = 'POS'
     and cha_kod like '100%'
   group by cha_tarihi, cast(right(cha_kod,3) as int)
  
  SELECT Z.STOREID, Z.STORE_NM, Z.TERMINAL, Z.DATE_DT, Z.RECEIPT_AMT, Z.REFUND_AMT, Z.ZETRECEIPT_AMT, Z.ZETREFUND_AMT, Z.DIFF ZDIFF
	   , R.TOBANK_AMT, L.cha_meblag LOOMIS_AMT, L.cha_meblag - R.TOBANK_AMT LOOMISDIFF
	   , R.CARDTOTAL_AMT, K.cha_meblag MIKROKK_AMT, K.cha_meblag - R.CARDTOTAL_AMT CARDDIFF
  	   , CASE WHEN ABS(DIFF) < 0.1 THEN 1 ELSE 0 END SALESTATUS
  	   , CASE WHEN TOBANK_AMT IS NOT NULL THEN 1 ELSE 0 END RECSTATUS
  	   , CASE WHEN L.cha_meblag IS NOT NULL THEN 1 ELSE 0 END LOOMISSTATUS
  	   , CASE WHEN K.cha_meblag IS NOT NULL THEN 1 ELSE 0 END KKSTATUS
    -- into #result
    FROM #sales Z
    JOIN STR_STORE ST ON Z.STOREID = ST.STOREID AND ST.DELETED_FL = 'N'
    LEFT JOIN #rec R ON Z.STOREID = R.STORE AND Z.DATE_DT = R.TRANSACTION_DT 
    LEFT JOIN #loomis L ON Z.STOREID = L.magaza AND Z.DATE_DT = L.cha_tarihi
    LEFT JOIN #kk K ON Z.STOREID = K.magaza AND Z.DATE_DT = K.cha_tarihi
   WHERE (@StoreId = -1 OR Z.STOREID = @StoreId)
   ORDER BY ABS(L.cha_meblag - R.TOBANK_AMT) DESC

END