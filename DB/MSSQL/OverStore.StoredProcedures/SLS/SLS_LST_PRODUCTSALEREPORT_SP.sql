﻿CREATE PROCEDURE [dbo].[SLS_LST_PRODUCTSALEREPORT_SP]
    @Store INT = -1,     
    @Product INT = -1,
    @StartDate DATE = NULL,
    @EndDate DATE = NULL,
	@selectDate INT, -- 0: tarih detaylı 1: tarih detaysız
	@selectStore INT -- 0: mağaza detaylı 1: mağaza detaysız
WITH RECOMPILE AS
BEGIN
	IF OBJECT_ID('tempdb.dbo.#STORES', 'U') IS NOT NULL DROP TABLE #STORES;   
	SELECT * INTO #STORES FROM dbo.STR_GETUSERSTORES_FN();    

	SELECT *, 
			SALE / SUM(SALE) OVER (PARTITION BY [TRANSACTION_DATE]) [SALE_PERCENTAGE],      
			SALE / SUM(SALE) OVER (PARTITION BY [TRANSACTION_DATE], CATEGORY_NM) [CATEGORY_SALE_PERCENTAGE]    
		FROM (
	 SELECT CASE WHEN @selectStore = 0 THEN ST.STORE_NM ELSE 'MAĞAZALAR TOPLAM' END STORE_NM,
			P.NAME_NM, P.CODE_NM, C.CATEGORY_NM, 
			CASE WHEN @selectDate = 0 THEN SD.TRANSACTION_DT ELSE CONVERT(DATE,'20991231',112) END [TRANSACTION_DATE],
			SUM(SALE_QTY) [QUANTITY_QTY], 
			MAX(CASE WHEN P.UNIT = 1 THEN 'KG' ELSE 'ADET' END) [UNIT],
			SUM(SALE_AMT) [SALE],
			SUM(REFUND_QTY) [REFUND_QTY],
			SUM(REFUND_AMT) [REFUND],
			SUM(SALE_CNT + REFUND_CNT) [CUSTOMER_QTY],
			COUNT(DISTINCT SD.STORE) [STORE_QTY]
		FROM SLS_PRODUCTSUMMARY_SYN SD (NOLOCK)
		JOIN PRD_PRODUCT P (NOLOCK) ON P.PRODUCTID = SD.PRODUCT
		JOIN #STORES ST ON SD.STORE = ST.STOREID
		LEFT JOIN PRD_SUBGROUP SG (NOLOCK) ON P.SUBGROUP = SG.SUBGROUPID 
		LEFT JOIN PRD_CATEGORY C (NOLOCK)  ON SG.CATEGORY = C.CATEGORYID 
		WHERE SD.TRANSACTION_DT BETWEEN @StartDate AND @EndDate   
		AND (@Product = -1 OR SD.PRODUCT = @Product)
		AND (@Store = -1 OR SD.STORE = @Store)
		GROUP BY P.NAME_NM, P.CODE_NM, C.CATEGORY_NM, 
		CASE WHEN @selectDate = 0 THEN SD.TRANSACTION_DT ELSE CONVERT(DATE,'20991231',112) END,
		CASE WHEN @selectStore = 0 THEN ST.STORE_NM ELSE 'MAĞAZALAR TOPLAM' END
		) A

END