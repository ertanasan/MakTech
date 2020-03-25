CREATE PROCEDURE WHS_LST_CONSTRAINTSTHEORY_SP 
	@StoreId INT, 
	@ProductId INT, 
	@StartDate DATE,
	@EndDate DATE,
	@StartBuffer NUMERIC(10,3), 
	@Unit NUMERIC(10,3),
	@GreenCycleLength INT,
	@BufferBandwith NUMERIC(4,2),
	@Ceiling INT = 1,
	@DeadLineLength INT = 3,
	@SeperateSum INT = 0
	AS
BEGIN

	DECLARE @rowno INT, @date DATE, @q NUMERIC(10,3), @lag1q NUMERIC(10,3)
	DECLARE @lag2q NUMERIC(10,3), @lag3q NUMERIC(10,3), @lag4q NUMERIC(10,3), @lag5q NUMERIC(10,3)
	DECLARE @coeff NUMERIC(4,2)
	DECLARE @prevorder1 NUMERIC(10,3) = 0
	DECLARE @prevorder2 NUMERIC(10,3) = 0
	DECLARE @prevorder3 NUMERIC(10,3) = 0
	DECLARE @prevorder4 NUMERIC(10,3) = 0
	DECLARE @prevorder5 NUMERIC(10,3) = 0

	DECLARE @greenBlueCycle INT = 0
	DECLARE @incAllowed INT = 1
	DECLARE @prevBufferChangeNumber INT = 0
	DECLARE @bufferChangeNumber INT = 0
	DECLARE @prevMaxStock NUMERIC(10,3) = @StartBuffer
	DECLARE @prev2MaxStock NUMERIC(10,3) = @StartBuffer
	DECLARE @calcMaxStock NUMERIC(10,3) = @StartBuffer
	DECLARE @calcRedDiff NUMERIC(10,3), @calcBuffer NUMERIC(10,3), @calcStock NUMERIC(10,3)
	DECLARE @calcIntake NUMERIC(10,3), @calcOrder NUMERIC(10,3), @totalRedDiff NUMERIC(10,3) 
	DECLARE @prevCalcStock NUMERIC(10,3) = @StartBuffer
	DECLARE @prevCalcBuffer NUMERIC(10,3) = @StartBuffer
	DECLARE @prevCalcRedDiff NUMERIC(10,3) = 0
	DECLARE @redZoneTop NUMERIC(10,3) = @StartBuffer - (((@StartBuffer * @BufferBandwith)/100.0) * 2)
	DECLARE @yellowZoneTop NUMERIC(10,3) = @StartBuffer - (((@StartBuffer * @BufferBandwith)/100.0))
	DECLARE @deadLineCounter INT = 0
	DECLARE @orderCalcSum NUMERIC(10,3)

	IF OBJECT_ID('tempdb.dbo.#tmp', 'U') IS NOT NULL  DROP TABLE #tmp; 
	create table #tmp (ROWNO INT, TRANSACTIONDATE DATE, TOPBUFFER NUMERIC(10,3), YELLOWZONETOP NUMERIC(10,3), REDZONETOP NUMERIC(10,3)
		, REDDIFF NUMERIC(10,3), CURRENTBUFFER NUMERIC(10,3), SALE NUMERIC(10,3), STOCK NUMERIC(10,3), INTAKE NUMERIC(10,3)
		, ORDERQTY NUMERIC(10,3), BUFFERCHANGENUMBER INT, DEADLINECOUNTER INT)

	DECLARE db_cursor CURSOR FOR 
	SELECT ROW_NUMBER() OVER (ORDER BY TRANSACTION_DT) ROWNO, TRANSACTION_DT, QUANTITY
		 , ISNULL(LAG(QUANTITY, 1) OVER (ORDER BY TRANSACTION_DT),0) LAG1_QUANTITY
		 , ISNULL(LAG(QUANTITY, 2) OVER (ORDER BY TRANSACTION_DT),0) LAG2_QUANTITY
		 , ISNULL(LAG(QUANTITY, 3) OVER (ORDER BY TRANSACTION_DT),0) LAG3_QUANTITY
		 , ISNULL(LAG(QUANTITY, 4) OVER (ORDER BY TRANSACTION_DT),0) LAG4_QUANTITY
		 , ISNULL(LAG(QUANTITY, 5) OVER (ORDER BY TRANSACTION_DT),0) LAG5_QUANTITY
		 , ISNULL(C.COEFFICIENT_RT, 1) COEFF
	  FROM SLS_STOREDAILYPRODUCT_SYN S
	  JOIN PRD_PRODUCT P ON S.PRODUCT = P.PRODUCTID
	  JOIN PRD_SUBGROUP SG ON P.SUBGROUP = SG.SUBGROUPID
	  LEFT JOIN WHS_CONSTRAINTEXCEPTION C 
		ON S.STORE = C.STORE 
	   AND S.TRANSACTION_DT BETWEEN C.STARTDATE_DT AND C.ENDDATE_DT 
	   AND (C.CATEGORY IS NULL OR C.CATEGORY = SG.CATEGORY)
	   AND (C.SUBGROUP IS NULL OR C.SUBGROUP = P.SUBGROUP)
	   AND (C.PRODUCT IS NULL OR P.PRODUCTID = C.PRODUCT)
	 WHERE S.STORE = @StoreId
	   AND S.PRODUCT = @ProductId
	   AND S.TRANSACTION_DT BETWEEN @StartDate AND @EndDate
	   AND S.TRANSACTION_DT NOT IN ('2018-12-29', '2018-12-30', '2018-12-31')
	 ORDER BY S.TRANSACTION_DT

	SET NOCOUNT ON
	OPEN db_cursor  
	FETCH NEXT FROM db_cursor INTO @rowno, @date, @q, @lag1q, @lag2q, @lag3q, @lag4q, @lag5q, @coeff

	WHILE @@FETCH_STATUS = 0  
	BEGIN  

	  SELECT @calcStock = CASE WHEN @prevCalcStock - @lag1q + @prevorder3 < 0 THEN 0 ELSE @prevCalcStock - @lag1q + @prevorder3 END
	  SET @calcBuffer = @calcStock + @prevorder1 + @prevorder2 - @prevorder4 - @prevorder5;

	  SET @calcRedDiff = 0
	  IF (@calcBuffer < @redZoneTop )
	  BEGIN
		SET @calcRedDiff = @redZoneTop - @calcBuffer
	  END

	  IF (@deadLineCounter > 0 and @deadLineCounter < @DeadLineLength)
	  BEGIN
	    SET @deadLineCounter = @deadLineCounter  + 1
	  END
	  ELSE
	  BEGIN
	    SET @deadLineCounter = 0
	  END

	  IF (@greenBlueCycle = @GreenCycleLength-1 and @calcBuffer >= @yellowZoneTop and @incAllowed = 1) -- max stock 
	  BEGIN
		SET @incAllowed = 0
		SET @bufferChangeNumber = @bufferChangeNumber + 1
		SET @calcMaxStock = @calcMaxStock - ((@calcMaxStock * @BufferBandwith)/100.0)
	  END ELSE IF (@calcBuffer >= 0 AND @calcBuffer < @redZoneTop )
	  BEGIN
		SELECT @totalRedDiff = SUM(REDDIFF) FROM #tmp WHERE BUFFERCHANGENUMBER = @bufferChangeNumber AND DEADLINECOUNTER = 0
		IF ((@totalRedDiff + @calcRedDiff) >= @redZoneTop)
		BEGIN
		  SET @bufferChangeNumber = @bufferChangeNumber + 1
		  SET @calcMaxStock = @calcMaxStock + ((@calcMaxStock * @BufferBandwith)/100.0)
		  SET @prevMaxStock = @calcMaxStock
		  SET @redZoneTop = @calcMaxStock - (((@calcMaxStock * @BufferBandwith)/100.0) * 2)
		  SET @yellowZoneTop = @calcMaxStock - (((@calcMaxStock * @BufferBandwith)/100.0))
		  SET @prevBufferChangeNumber = @bufferChangeNumber
		  SET @deadLineCounter = 1
		END
	  END ELSE IF (@calcBuffer < 0 AND @deadLineCounter = 0)
	  BEGIN
		SET @bufferChangeNumber = @bufferChangeNumber + 1
		SET @calcMaxStock = @calcMaxStock + ((@calcMaxStock * @BufferBandwith)/100.0)
		SET @prevMaxStock = @calcMaxStock
		SET @redZoneTop = @calcMaxStock - (((@calcMaxStock * @BufferBandwith)/100.0) * 2)
		SET @yellowZoneTop = @calcMaxStock - (((@calcMaxStock * @BufferBandwith)/100.0))
		SET @prevBufferChangeNumber = @bufferChangeNumber
		SET @deadLineCounter = 1
	  END

	  IF (@incAllowed = 0 and @calcBuffer < @yellowZoneTop) 
	  BEGIN
		SET @incAllowed = 1
	  END

	  IF (@calcBuffer >= @yellowZoneTop) 
	  BEGIN
		SET @greenBlueCycle = @greenBlueCycle + 1
	  END
	  ELSE
	  BEGIN
		SET @greenBlueCycle = 0
	  END

	  SET @prevorder5 = @prevorder4
	  SET @prevorder4 = @prevorder3
	  SET @prevorder3 = @prevorder2
	  SET @prevorder2 = @prevorder1

	  IF (@SeperateSum = 0)
	  BEGIN
		SELECT @orderCalcSum = CASE WHEN @calcBuffer <= @prevMaxStock THEN @q ELSE 0 END
							   +
							   CASE WHEN @prevMaxStock > @prev2MaxStock THEN @prevMaxStock - @prev2MaxStock ELSE 0 END
							   + 
							   @prevCalcRedDiff
	  END
	  IF (@Ceiling = 1) 
	  BEGIN
		  SELECT @prevorder1 = CASE WHEN @SeperateSum = 1 THEN
								   CASE WHEN @calcBuffer <= @prevMaxStock THEN CEILING(@q/@Unit)*@Unit ELSE 0 END
								   +
								   CASE WHEN @prevMaxStock > @prev2MaxStock THEN CEILING((@prevMaxStock - @prev2MaxStock)/@Unit)*@Unit ELSE 0 END
								   + 
								   CEILING(@prevCalcRedDiff/@Unit)*@Unit
							   ELSE 
							       CEILING(@orderCalcSum/@Unit)*@Unit
							   END
	  END
	  ELSE
	  BEGIN
		  SELECT @prevorder1 = CASE WHEN @SeperateSum = 1 THEN
								   CASE WHEN @calcBuffer <= @prevMaxStock THEN ROUND(@q/@Unit, 0)*@Unit ELSE 0 END
								   +
								   CASE WHEN @prevMaxStock > @prev2MaxStock THEN ROUND((@prevMaxStock - @prev2MaxStock)/@Unit, 0)*@Unit ELSE 0 END
								   + 
								   ROUND(@prevCalcRedDiff/@Unit, 0)*@Unit
							   ELSE
								   ROUND(@orderCalcSum/@Unit, 0)*@Unit
							   END
	  END
	  SET @prevorder1 = @prevorder1 * @coeff

	  INSERT INTO #tmp VALUES (@rowno, @date, @prevMaxStock, @yellowZoneTop, @redZoneTop, @calcRedDiff, @calcBuffer, @q, @calcStock, @prevorder4, @prevorder1, @prevBufferChangeNumber, @deadLineCounter)

	  SET @prev2MaxStock = @prevMaxStock 
	  SET @prevMaxStock = @calcMaxStock
	  SET @prevCalcStock = @calcStock
	  SET @prevCalcBuffer = @calcBuffer
	  SET @prevCalcRedDiff = @calcRedDiff 
	  SET @prevBufferChangeNumber = @bufferChangeNumber
	  SET @redZoneTop = @calcMaxStock - (((@calcMaxStock * @BufferBandwith)/100.0) * 2)
	  SET @yellowZoneTop = @calcMaxStock - (((@calcMaxStock * @BufferBandwith)/100.0))

	  FETCH NEXT FROM db_cursor INTO @rowno, @date, @q, @lag1q, @lag2q, @lag3q, @lag4q, @lag5q, @coeff

	END 

	CLOSE db_cursor  
	DEALLOCATE db_cursor 
	SET NOCOUNT OFF

	select *, stock-sale ENDOFDAYSTOCK  from #tmp 
	SELECT @rowno = COUNT(*) FROM #tmp 

	SELECT SUM(CASE WHEN stock-sale < 0 THEN sale-stock ELSE 0 END)*100.0/SUM(SALE) [Yok Satma Oranı]
		 , SUM(CASE WHEN stock-sale < 0 THEN sale-stock ELSE 0 END) [Yok Satma Miktarı], SUM(SALE) [Satış Miktarı]
		 , SUM(CASE WHEN stock-sale < 0 THEN 1 ELSE 0 END) [Yok Satan Gün Sayısı]
		 , COUNT(*) [Analiz Gün Sayısı]
		 , AVG(STOCK) [Ortalama Stok], AVG(CURRENTBUFFER) [Ortalama Tampon]
		 , MAX(BUFFERCHANGENUMBER) [Tampon Değişim Sayısı]
		 , SUM(CASE WHEN ROWNO = 1 THEN STOCK ELSE 0 END) [İlk Stok]
		 , SUM(CASE WHEN ROWNO = @rowno THEN STOCK ELSE 0 END) [Son Stok]
		 , SUM(SALE)/((SUM(CASE WHEN ROWNO = 1 THEN STOCK ELSE 0 END)+ SUM(CASE WHEN ROWNO = @rowno THEN STOCK ELSE 0 END)) / 2.0) [Stok Devir Hızı]
		 , @rowno / (SUM(SALE)/((SUM(CASE WHEN ROWNO = 1 THEN STOCK ELSE 0 END)+ SUM(CASE WHEN ROWNO = @rowno THEN STOCK ELSE 0 END)) / 2.0)) [Stok Tutma Süresi]
		 , AVG(SALE) [Ortalama Satış Miktarı]
		 , STDEV(SALE) [Satış Standart Sapma Değeri]
		 , MAX(MEDIANSALE) [Satış Medyan Değeri]
	  FROM (SELECT *, PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY SALE) OVER (PARTITION BY 1) AS MEDIANSALE FROM #tmp) A

END