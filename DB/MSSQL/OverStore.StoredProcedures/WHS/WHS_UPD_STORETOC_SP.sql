CREATE PROCEDURE WHS_UPD_STORETOC_SP @StoreId INT, @RunDay DATE = NULL AS
BEGIN

  SET NOCOUNT OFF  
  -- DECLARE @StoreId INT = 30
  -- DECLARE @today DATE = '2019-04-12' 

  DECLARE @today DATE 

  -- gece saat 12'den sonra batch çalıştığından çalışılan günü bulmak için bir miktar önceye alınıyor. 
  IF @RunDay IS NULL 
  BEGIN
	SET @today = CAST(GETDATE()-0.25 AS DATE)
  END
  ELSE
  BEGIN
    SET @today = @RunDay
  END
  DECLARE @tomorrow DATE = DATEADD(DAY,1,@today)
  DECLARE @yesterday DATE = DATEADD(DAY,-1,@today)
  DECLARE @twodaysago DATE = DATEADD(DAY,-2,@today)
  DECLARE @threedaysago DATE = DATEADD(DAY,-3,@today)
  DECLARE @sevendaysago DATE = DATEADD(DAY,-7,@today)
  DECLARE @limitCoeff NUMERIC(6,2) = [dbo].[WHS_TOCSTORECOEFF_FN] (@today, @StoreId);
  IF @limitCoeff < 1 OR @limitCoeff > 5 SET @limitCoeff = 1

  -- SELECT @today, @yesterday, @twodaysago 

  -- Mağazaya ait limit değerleri al, önceki güne ait varsa onu al, yoksa ortalama üzerinden hesaplama yap. 
  -- bu işlem sadece mağazaya ilk TOC hesaplanırken veya yeni bir ürün olduğunda bir işe yarayacaktır. 
  -- Normalde limit değerleri ürün için bir önceki hesaplamadan alınıyor olacaktır. 
  IF OBJECT_ID('tempdb.dbo.#saleavg', 'U') IS NOT NULL  DROP TABLE #saleavg;
  IF OBJECT_ID('tempdb.dbo.#limits', 'U') IS NOT NULL  DROP TABLE #limits;
  IF OBJECT_ID('tempdb.dbo.#stock', 'U') IS NOT NULL  DROP TABLE #stock;
  IF OBJECT_ID('tempdb.dbo.#buffer', 'U') IS NOT NULL  DROP TABLE #buffer;
  IF OBJECT_ID('tempdb.dbo.#sales', 'U') IS NOT NULL  DROP TABLE #sales;
  IF OBJECT_ID('tempdb.dbo.#intake', 'U') IS NOT NULL  DROP TABLE #intake;
  IF OBJECT_ID('tempdb.dbo.#lastweeksales', 'U') IS NOT NULL  DROP TABLE #lastweeksales;
  
  SELECT PRODUCT, MAX(LAGQUANTITY + QUANTITY + LEADQUANTITY) BUFFER_QTY, AVG(LAGQUANTITY + QUANTITY + LEADQUANTITY)*1.2 BUFFER2_QTY    
    INTO #saleavg
    FROM (  
  SELECT *  
       , ISNULL(LAG(QUANTITY) OVER (PARTITION BY PRODUCT ORDER BY TRANSACTION_DT),0) LAGQUANTITY  
  	   , ISNULL(LEAD(QUANTITY) OVER (PARTITION BY PRODUCT ORDER BY TRANSACTION_DT),0) LEADQUANTITY  
       , LAG(TRANSACTION_DT) OVER (PARTITION BY PRODUCT ORDER BY TRANSACTION_DT) LAGDATE  
       , LEAD(TRANSACTION_DT) OVER (PARTITION BY PRODUCT ORDER BY TRANSACTION_DT) LEADDATE  
       , DATEADD(DAY,-1,TRANSACTION_DT) YESTERDAY  
       , DATEADD(DAY,1,TRANSACTION_DT) TOMORROW  
   FROM (
  SELECT COALESCE(SG.STOCKGROUP+10000, S.PRODUCT) PRODUCT, S.TRANSACTION_DT, SUM(S.QUANTITY) QUANTITY
    FROM SLS_STOREDAILYPRODUCT_SYN S
    JOIN PRD_PRODUCT_VW P ON S.PRODUCT = P.PRODUCTID
    LEFT JOIN PRD_PROPERTY PP ON P.PRODUCTID = PP.PRODUCT AND PP.PROPERTYTYPE = 6
    LEFT JOIN PRD_STOCKGROUP_VW SG ON S.PRODUCT = SG.PRODUCTID AND SG.USAGETYPE_CD = 1
   WHERE STORE = @StoreId
     AND P.CATEGORY_NM != 'Sarf Malzemeleri'
     AND PP.PRODUCT IS NULL
     AND P.ACTIVE_FL = 'Y'
	 AND P.SUPERGROUP3 != 3
   GROUP BY COALESCE(SG.STOCKGROUP+10000, S.PRODUCT), S.TRANSACTION_DT) A  ) B
   GROUP BY PRODUCT

  SELECT A.PRODUCT, COALESCE(B.GREENLIMIT_QTY, A.BUFFER2_QTY) GREENLIMIT_QTY
	   , COALESCE(B.YELLOWLIMIT_QTY, A.BUFFER2_QTY * 0.8) YELLOWLIMIT_QTY
	   , COALESCE(B.REDLIMIT_QTY, A.BUFFER2_QTY * 0.6) REDLIMIT_QTY
	   , ISNULL(B.PERIOD_NO, 1) PERIOD_NO
	   , ISNULL(B.REDREMNANT_QTY, 0) REDREMNANT_QTY
    INTO #limits
    FROM #saleavg A
	LEFT JOIN WHS_TOC (NOLOCK) B ON A.PRODUCT = B.PRODUCT AND B.STORE = @StoreId AND B.TOC_DT = @yesterday
  

  SELECT TRANSACTION_DT, COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID) PRODUCTID, SUM(QUANTITY_QTY) INTAKE_QTY
    INTO #intake
    FROM INV_STOCKTRANSACTIONS_SYN ST    
    JOIN PRD_PRODUCT P ON ST.PRODUCT = P.PRODUCTID  
    LEFT JOIN PRD_STOCKGROUP_VW SG ON P.PRODUCTID = SG.PRODUCTID AND SG.USAGETYPE_CD = 1
   WHERE TRANSACTION_DT BETWEEN DATEADD(DAY,-2,@today) AND @today
     AND ST.WAREHOUSE = @StoreId
     AND ST.TRANSACTIONTYPE = 1
   GROUP BY TRANSACTION_DT, COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID);

  SELECT COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID) PRODUCTID,
    	 -- COALESCE(SG.STOCKGROUP_NM, P.NAME_NM) PRODUCT_NM, 
		 SUM(INV.STOCK) STOCK
    INTO #stock
    FROM dbo.INV_STOCKDATE_FN(@today) INV  
    JOIN STR_STORE ST ON INV.STORE = ST.STOREID  
    JOIN PRD_PRODUCT P ON INV.PRODUCT = P.PRODUCTID  
    LEFT JOIN PRD_STOCKGROUP_VW SG ON P.PRODUCTID = SG.PRODUCTID AND SG.USAGETYPE_CD = 1
   WHERE P.SUPERGROUP1 != 9 -- sarf malzemeleri mağazadan ne kadar çıktığı bilinmediğinden analize dahil edilmiyor. 
     AND ST.STOREID = @StoreId
     AND P.ACTIVE_FL = 'Y'
	 AND P.SUPERGROUP3 != 3
   GROUP BY COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID), COALESCE(SG.STOCKGROUP_NM, P.NAME_NM)

  DECLARE @LastOrderDate DATE
  SELECT @LastOrderDate = MAX(ORDER_DT)
    FROM WHS_STOREORDER
   WHERE STORE = @StoreId
     AND ORDER_DT < @today
     AND CREATEUSER = 1;
  
  WITH OnWayTOCOrders AS (
  SELECT PRODUCT, SUM(ORDER_QTY) ORDER_QTY
    FROM WHS_TOC T (NOLOCK)
    JOIN WHS_TOCDETAIL D (NOLOCK) ON T.TOCID = D.TOCID
   WHERE STORE = @StoreId
     AND TOC_DT > @LastOrderDate AND TOC_DT < @today
   GROUP BY PRODUCT),
   OnWayOrders AS (
  SELECT COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID) PRODUCT,
		 SUM(OD.SHIPPED_QTY * OD.ORDERUNIT_QTY) ORDER_QTY
    FROM WHS_STOREORDER O
	JOIN WHS_STOREORDERDETAIL OD ON O.STOREORDERID = OD.STOREORDER
	JOIN PRD_PRODUCT P ON OD.PRODUCT = P.PRODUCTID  
    LEFT JOIN PRD_STOCKGROUP_VW SG ON P.PRODUCTID = SG.PRODUCTID AND SG.USAGETYPE_CD = 1
   WHERE STORE = @StoreId
	 AND P.SUPERGROUP1 != 9 -- sarf malzemeleri mağazadan ne kadar çıktığı bilinmediğinden analize dahil edilmiyor. 
     AND P.ACTIVE_FL = 'Y'
	 AND P.SUPERGROUP3 != 3
	 AND O.SHIPMENT_DT > @today
   GROUP BY COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID))
  SELECT PRODUCTID, SUM(STOCK) BUFFER_QTY
    INTO #buffer
    FROM (
  SELECT PRODUCTID, STOCK
    FROM #stock
   UNION ALL
  SELECT * FROM OnWayOrders
   UNION ALL
  SELECT * FROM OnWayTOCOrders) A
   GROUP BY PRODUCTID

  -- satışları al
  SELECT COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID) PRODUCTID,
  	     COALESCE(SG.STOCKGROUP_NM, P.NAME_NM) PRODUCT_NM, SUM(CASE WHEN P.UNIT = 1 THEN SD.QUANTITY_QTY/1000.0 ELSE SD.QUANTITY_QTY END) SALES
    INTO #sales
    FROM SLS_SALEDETAIL SD
    JOIN SLS_SALE S ON SD.SALE = S.SALEID
    JOIN PRD_PRODUCT_VW P ON SD.PRODUCT = P.PRODUCTID  
    LEFT JOIN PRD_STOCKGROUP_VW SG ON P.PRODUCTID = SG.PRODUCTID AND SG.USAGETYPE_CD = 1
   WHERE SD.TRANSACTION_DT = @today
     AND SD.STORE = @StoreId
     AND P.SUPERGROUP1 != 9
     AND P.ACTIVE_FL = 'Y'
	 AND P.SUPERGROUP3 != 3
   GROUP BY COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID), COALESCE(SG.STOCKGROUP_NM, P.NAME_NM) 

  -- last week sale
  SELECT COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID) PRODUCTID,
  	     COALESCE(SG.STOCKGROUP_NM, P.NAME_NM) PRODUCT_NM, SUM(CASE WHEN P.UNIT = 1 THEN SD.QUANTITY_QTY/1000.0 ELSE SD.QUANTITY_QTY END) SALES
    INTO #lastweeksales
    FROM SLS_SALEDETAIL SD
    JOIN SLS_SALE S ON SD.SALE = S.SALEID
    JOIN PRD_PRODUCT_VW P ON SD.PRODUCT = P.PRODUCTID  
    LEFT JOIN PRD_STOCKGROUP_VW SG ON P.PRODUCTID = SG.PRODUCTID AND SG.USAGETYPE_CD = 1
   WHERE SD.TRANSACTION_DT >= @sevendaysago 
     AND SD.STORE = @StoreId
     AND P.SUPERGROUP1 != 9
     AND P.ACTIVE_FL = 'Y'
	 AND P.SUPERGROUP3 != 3
   GROUP BY COALESCE(10000+SG.STOCKGROUP, P.PRODUCTID), COALESCE(SG.STOCKGROUP_NM, P.NAME_NM)   

  -- son hafta satışı olmayanları eski verileri ile kayıt at. 
  INSERT INTO WHS_TOC
  (STORE, PRODUCT, TOC_DT, GREENLIMIT_QTY, YELLOWLIMIT_QTY, REDLIMIT_QTY, REDREMNANT_QTY, BUFFER_QTY, STOCK_QTY, SALE_QTY, INTAKE_QTY, PERIOD_NO)
  SELECT @StoreId, l.PRODUCT, @today, l.GREENLIMIT_QTY, l.YELLOWLIMIT_QTY, l.REDLIMIT_QTY, 0, 
		 ISNULL(b.BUFFER_QTY, 0) BUFFER_QTY, ISNULL(s.STOCK, 0) STOCK, ISNULL(sl.SALES, 0) SALES, ISNULL(i.INTAKE_QTY, 0), l.PERIOD_NO
    FROM #limits l
	LEFT JOIN #stock s ON l.PRODUCT = s.PRODUCTID
	LEFT JOIN #buffer b ON l.PRODUCT = b.PRODUCTID
	LEFT JOIN #sales sl ON l.PRODUCT = sl.PRODUCTID
	LEFT JOIN #intake i ON l.PRODUCT = i.PRODUCTID AND i.TRANSACTION_DT = @today 
	LEFT JOIN #lastweeksales lws ON l.PRODUCT = lws.PRODUCTID
   WHERE ISNULL(lws.SALES, 0) = 0
      OR (lws.SALES < l.REDLIMIT_QTY AND s.STOCK > lws.SALES)

  DECLARE toc_cursor CURSOR FOR
  SELECT l.*, ISNULL(s.STOCK, 0) STOCK, ISNULL(b.BUFFER_QTY, 0) BUFFER_QTY, ISNULL(sl.SALES, 0) SALES, ISNULL(i.INTAKE_QTY, 0) INTAKE_QTY
    FROM #limits l
	LEFT JOIN #stock s ON l.PRODUCT = s.PRODUCTID
	LEFT JOIN #buffer b ON l.PRODUCT = b.PRODUCTID
	LEFT JOIN #sales sl ON l.PRODUCT = sl.PRODUCTID
	LEFT JOIN #intake i ON l.PRODUCT = i.PRODUCTID AND i.TRANSACTION_DT = @today 
	LEFT JOIN #lastweeksales lws ON l.PRODUCT = lws.PRODUCTID
   WHERE ISNULL(lws.SALES, 0)  > 0 -- son hafta satışı olanları al.
     AND (lws.SALES >= l.REDLIMIT_QTY OR s.STOCK <= lws.SALES)

  DECLARE @product INT, @greenlimit numeric(10,3), @yellowlimit numeric(10,3), @redlimit numeric(10,3), @periodNo INT
  DECLARE @stock numeric(10,3), @buffer numeric(10,3), @sales numeric(10,3), @intake numeric(10,3)
  DECLARE @newgreenlimit numeric(10,3), @newyellowlimit numeric(10,3), @newredlimit numeric(10,3), @redremnant numeric(10,3), @newredremnant numeric(10,3)
  DECLARE @incAllowed INT, @greenCycleCount INT, @newPeriodNo INT, @totalRedRemnant numeric(10,3), @blackCount INT, @TocId INT
  DECLARE @detailText VARCHAR(1000)

  OPEN toc_cursor    
  FETCH NEXT FROM toc_cursor INTO @product, @greenlimit, @yellowlimit, @redlimit, @periodNo, @redremnant, @stock, @buffer, @sales, @intake
  
  WHILE @@FETCH_STATUS = 0    
  BEGIN    
    SET @newgreenlimit = @greenlimit
    SET @newyellowlimit = @yellowlimit
    SET @newredlimit = @redlimit
	SET @newPeriodNo = @periodNo
	SET @newredremnant = 0
	SET @detailText = ''
	-- yeni limit değerleri hesapla
    -- önceki düşürmeden sonra bir yeşil altı renk ve 6 dönem mavi + yeşil varsa düşür
	SELECT @incAllowed = COUNT(*)
	  FROM WHS_TOC (NOLOCK)
	 WHERE PERIOD_NO = @periodNo
	   AND PRODUCT = @product
	   AND STORE = @StoreId
	   AND BUFFER_QTY < @yellowlimit
    IF (@periodNo = 1 OR @incAllowed > 0)
	BEGIN
	  SELECT @greenCycleCount = SUM(CASE WHEN BUFFER_QTY >= @yellowlimit THEN 1 ELSE 0 END)
	    FROM (SELECT ROW_NUMBER() OVER (ORDER BY TOCID DESC) ROWNO, BUFFER_QTY
				FROM WHS_TOC (NOLOCK)
			   WHERE PERIOD_NO = @periodNo
				 AND PRODUCT = @product
				 AND STORE = @StoreId) A
	   WHERE ROWNO <= 6
	  IF @greenCycleCount = 6 
	  BEGIN
	    SET @newPeriodNo = @periodNo + 1
		SET @newgreenlimit = @greenlimit * 0.8
		SET @newyellowlimit = @newgreenlimit * 0.8
		SET @newredlimit = @newgreenlimit * 0.6
		SET @detailText = @detailText + 'incAllowed: ' + ISNULL(CAST(@incAllowed AS VARCHAR),'') + ', '
		SET @detailText = @detailText + 'greenCycleCount: ' + ISNULL(CAST(@greenCycleCount AS VARCHAR),'') + ', '
		SET @detailText = @detailText + 'periodNo: ' + ISNULL(CAST(@periodNo AS VARCHAR),'') + ', '
		SET @detailText = @detailText + 'yellowlimit: ' + ISNULL(CAST(@yellowlimit AS VARCHAR),'') + ', '
	  END
	END
    -- önceki artırmadan sonra 3 dönem geçmiş ve kırmızıların toplamı kırmızı limiti aşmışsa veya siyah olmuşsa artır. 	
	SELECT @totalRedRemnant = SUM(REDREMNANT_QTY), @blackCount = SUM(CASE WHEN BUFFER_QTY < 0 THEN 1 ELSE 0 END)
	  FROM (SELECT REDREMNANT_QTY, BUFFER_QTY, ROW_NUMBER() OVER (ORDER BY TOCID) ROWNO
			  FROM WHS_TOC (NOLOCK)
			 WHERE PERIOD_NO = @periodNo
			   AND PRODUCT = @product
			   AND STORE = @StoreId) A
	 WHERE A.ROWNO > 3

    IF (@blackCount > 0 OR @totalRedRemnant >= @redlimit) AND (@stock < (@greenlimit + @sales))
	BEGIN
	  SET @newPeriodNo = @periodNo + 1
	  SET @newgreenlimit = @greenlimit * 1.2
	  SET @newyellowlimit = @newgreenlimit * 0.8
	  SET @newredlimit = @newgreenlimit * 0.6
	  SET @detailText = @detailText + 'blackCount: ' + ISNULL(CAST(@blackCount AS VARCHAR),'') + ', '
	  SET @detailText = @detailText + 'totalRedRemnant: ' + ISNULL(CAST(@totalRedRemnant AS VARCHAR),'') + ', '
	  SET @detailText = @detailText + 'redlimit: ' + ISNULL(CAST(@redlimit AS VARCHAR),'') + ', '
	END

	
	IF @buffer < @newredlimit and @buffer >= 0
	BEGIN
	  SET @newredremnant = @newredlimit - @buffer 
	END
	INSERT INTO WHS_TOC
	(STORE, PRODUCT, TOC_DT, GREENLIMIT_QTY, YELLOWLIMIT_QTY, REDLIMIT_QTY, REDREMNANT_QTY, BUFFER_QTY, STOCK_QTY, SALE_QTY, INTAKE_QTY, PERIOD_NO, DETAIL_TXT)
	VALUES
	(@StoreId, @product, @today, @newgreenlimit, @newyellowlimit, @newredlimit, @newredremnant, @buffer, @stock, @sales, @intake, @newPeriodNo, @detailText)

	SELECT @TocId = SCOPE_IDENTITY();
	-- tampon değeri greenlimit'te olanlar için sipariş hesapla, diğerleri için 0 ata. 
	-- satış + dünkü kırmızı ile fark + limit değişim farkı
	IF ROUND((@newgreenlimit*@limitCoeff) - @buffer, 2) > 0 AND @sales > 0  -- satış işle
	BEGIN
	  IF (@limitCoeff > 1) SET @sales = @sales * @limitCoeff * 2;
	  EXEC WHS_INS_TOCDETAIL_SP @TocId, @product, @sales, 1
	END
	IF @redremnant > 0 -- dünkü kırmızıdan dolayı ekle
	BEGIN
	  EXEC WHS_INS_TOCDETAIL_SP @TocId, @product, @redremnant, 2
	END
	IF ROUND(@newgreenlimit - @greenlimit, 2) > 0
	BEGIN
	  DECLARE @limitdiff numeric(10,3) = @newgreenlimit - @greenlimit
	  EXEC WHS_INS_TOCDETAIL_SP @TocId, @product, @limitdiff, 3
	END

    FETCH NEXT FROM toc_cursor INTO @product, @greenlimit, @yellowlimit, @redlimit, @periodNo, @redremnant, @stock, @buffer, @sales, @intake
  
  END 

  CLOSE toc_cursor;  
  DEALLOCATE toc_cursor;  

  SET NOCOUNT ON
END