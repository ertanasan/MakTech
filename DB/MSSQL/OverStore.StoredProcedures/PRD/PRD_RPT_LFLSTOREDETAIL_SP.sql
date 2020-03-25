﻿CREATE PROCEDURE [dbo].[PRD_RPT_LFLSTOREDETAIL_SP]
  @StartDate DATE,  
  @EndDate DATE,  
  @StartCompDate DATE,  
  @EndCompDate DATE,
  @Product INT,
  @Store INT WITH RECOMPILE AS  
BEGIN  

	IF OBJECT_ID('tempdb.dbo.#LFLSTORES', 'U') IS NOT NULL DROP TABLE #LFLSTORES; 

	WITH STORES AS (
	SELECT *
	  FROM (
	SELECT STORE, COUNT(DISTINCT TRANSACTION_DT) SALEDAY_CNT, DATEDIFF(DAY, @StartDate, @EndDate)+1 DAY_CNT
	  FROM SLS_STOREDAILYPRODUCT_SYN 
	 WHERE TRANSACTION_DT BETWEEN @StartDate AND @EndDate
	 GROUP BY STORE) A
	 WHERE (SALEDAY_CNT * 1.0 / DAY_CNT) > 0.9),
	 COMPSTORES AS (
	SELECT *
	  FROM (
	SELECT STORE, COUNT(DISTINCT TRANSACTION_DT) SALEDAY_CNT, DATEDIFF(DAY, @StartCompDate, @EndCompDate)+1 DAY_CNT
	  FROM SLS_STOREDAILYPRODUCT_SYN 
	 WHERE TRANSACTION_DT BETWEEN @StartCompDate AND @EndCompDate
	 GROUP BY STORE) A
	 WHERE (SALEDAY_CNT * 1.0 / DAY_CNT) > 0.9)
	SELECT CASE WHEN ST.STORE IS NOT NULL AND CST.STORE IS NOT NULL THEN 'LFL' 
				WHEN ST.STORE IS NOT NULL THEN 'NEWSTORE' 
				ELSE 'OLDSTORE' 
		   END STOREGROUP, ST.STORE
	  INTO #LFLSTORES
	  FROM STORES ST
	  FULL OUTER JOIN COMPSTORES CST ON ST.STORE = CST.STORE

	DECLARE @lflstorecount INT, @newstorecount INT, @oldstorecount INT
	SELECT @lflstorecount = SUM(CASE WHEN STOREGROUP = 'LFL' THEN 1 ELSE 0 END)
		 , @newstorecount = SUM(CASE WHEN STOREGROUP = 'NEWSTORE' THEN 1 ELSE 0 END)
		 , @oldstorecount = SUM(CASE WHEN STOREGROUP = 'OLDSTORE' THEN 1 ELSE 0 END)
	  FROM #LFLSTORES

	SELECT ST.STOREID, ST.STORE_NM, P.CATEGORY_NM, 
		   P.CODE_NM,
		   P.NAME_NM,
		   SUM(S.LFLQUANTITY) LFLQUANTITY,    
		   SUM(S.QUANTITY) QUANTITY,
		   SUM(S.LFLPRICE) LFLPRICE,    
		   SUM(S.PRICE) PRICE,
		   SUM(S2.LFLCOMP_QUANTITY) LFLCOMP_QUANTITY,
		   SUM(S2.COMP_QUANTITY) COMP_QUANTITY,
		   SUM(S2.LFLCOMP_PRICE) LFLCOMP_PRICE,
		   SUM(S2.COMP_PRICE) COMP_PRICE
      FROM (SELECT S.STORE, PRODUCT, SUM(QUANTITY) QUANTITY, SUM(PRICE) PRICE
				 , SUM(CASE WHEN LS.STORE IS NOT NULL THEN QUANTITY ELSE 0 END) LFLQUANTITY
				 , SUM(CASE WHEN LS.STORE IS NOT NULL THEN PRICE ELSE 0 END) LFLPRICE
			  FROM SLS_STOREDAILYPRODUCT_SYN  S
			  LEFT JOIN #LFLSTORES LS ON S.STORE = LS.STORE AND STOREGROUP = 'LFL'
			 WHERE TRANSACTION_DT BETWEEN @StartDate AND @EndDate
			   AND (@Product = -1 OR PRODUCT = @Product)
			   AND (@Store = -1 OR S.STORE = @Store)
			 GROUP BY S.STORE, PRODUCT) S 
	  FULL OUTER JOIN (SELECT S.STORE, PRODUCT, SUM(QUANTITY) COMP_QUANTITY, SUM(PRICE) COMP_PRICE 
							, SUM(CASE WHEN LS.STORE IS NOT NULL THEN QUANTITY ELSE 0 END) LFLCOMP_QUANTITY
							, SUM(CASE WHEN LS.STORE IS NOT NULL THEN PRICE ELSE 0 END) LFLCOMP_PRICE
						 FROM SLS_STOREDAILYPRODUCT_SYN S
						 LEFT JOIN #LFLSTORES LS ON S.STORE = LS.STORE AND STOREGROUP = 'LFL'
						WHERE TRANSACTION_DT BETWEEN @StartCompDate AND @EndCompDate
						  AND (@Product = -1 OR PRODUCT = @Product)
						  AND (@Store = -1 OR S.STORE = @Store)
						GROUP BY S.STORE, PRODUCT) S2 
		ON S.STORE=S2.STORE AND S.PRODUCT = S2.PRODUCT
      JOIN PRD_PRODUCT_VW P ON P.PRODUCTID = COALESCE(S.PRODUCT, S2.PRODUCT)
	  JOIN STR_STORE_VW ST ON ST.STOREID = COALESCE(S.STORE, S2.STORE)
	 GROUP BY ST.STOREID, ST.STORE_NM, P.CATEGORY_NM, P.CODE_NM, P.NAME_NM 
END