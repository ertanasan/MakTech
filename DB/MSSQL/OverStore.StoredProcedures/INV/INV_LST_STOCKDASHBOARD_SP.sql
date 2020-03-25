﻿CREATE PROCEDURE [dbo].[INV_LST_STOCKDASHBOARD_SP] AS
BEGIN

	DECLARE @Date DATE
	SELECT @Date = MAX(DATE_DT) FROM INV_STOCKDASHBOARD

	SELECT @Date TODAY,
		   SUM(CASE WHEN STORE != 1001 THEN STOCK_AMT ELSE 0 END) STORESTOCK_AMT,
		   SUM(CASE WHEN STORE != 1001 THEN SALE_AMT ELSE 0 END) STORESALEAVG_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN STOCK_AMT ELSE 0 END) WAREHOUSESTOCK_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN SALE_AMT ELSE 0 END) WAREHOUSESALEAVG_AMT
	  FROM INV_STOCKDASHBOARD
	 WHERE DATE_DT = @Date

	-- CATEGORY BAZLI 30 GÜNLÜK DEĞİŞİM GRAFİĞİ
	SELECT *
	  FROM (
	SELECT C.CATEGORYID, C.CATEGORY_NM, DATE_DT, 
		   SUM(CASE WHEN STORE != 1001 THEN STOCK_AMT ELSE 0 END) STORESTOCK_AMT,
		   SUM(CASE WHEN STORE != 1001 THEN SALE_AMT ELSE 0 END) STORESALEAVG_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN STOCK_AMT ELSE 0 END) WAREHOUSESTOCK_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN SALE_AMT ELSE 0 END) WAREHOUSESALEAVG_AMT
	  FROM INV_STOCKDASHBOARD SD
	  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_SUBGROUP SG ON P.SUBGROUP = SG.SUBGROUPID
	  LEFT JOIN PRD_CATEGORY C ON SG.CATEGORY = C.CATEGORYID
	 WHERE P.SUPERGROUP1 != 9
	 GROUP BY C.CATEGORYID, C.CATEGORY_NM, DATE_DT
	 UNION ALL
	SELECT -1 CATEGORYORDER, 'HEPSİ' CATEGORY_NM, DATE_DT, 
		   SUM(CASE WHEN STORE != 1001 THEN STOCK_AMT ELSE 0 END) STORESTOCK_AMT,
		   SUM(CASE WHEN STORE != 1001 THEN SALE_AMT ELSE 0 END) STORESALEAVG_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN STOCK_AMT ELSE 0 END) WAREHOUSESTOCK_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN SALE_AMT ELSE 0 END) WAREHOUSESALEAVG_AMT
	  FROM INV_STOCKDASHBOARD SD
	  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID
	 WHERE P.SUPERGROUP1 != 9
	 GROUP BY DATE_DT) A
	 ORDER BY CATEGORYID

	-- ÜRÜN BAZLI SON GÜN DEĞERLER
	SELECT C.CATEGORY_NM, P.NAME_NM, 
		   SUM(CASE WHEN STORE != 1001 THEN STOCK_AMT ELSE 0 END) STORESTOCK_AMT,
		   SUM(CASE WHEN STORE != 1001 THEN STOCK_QTY ELSE 0 END) STORESTOCK_QTY,
		   SUM(CASE WHEN STORE != 1001 THEN SALE_AMT ELSE 0 END) STORESALEAVG_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN STOCK_AMT ELSE 0 END) WAREHOUSESTOCK_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN STOCK_QTY ELSE 0 END) WAREHOUSESTOCK_QTY,
		   SUM(CASE WHEN STORE = 1001 THEN SALE_AMT ELSE 0 END) WAREHOUSESALEAVG_AMT
	  FROM INV_STOCKDASHBOARD SP
	  JOIN PRD_PRODUCT P ON SP.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_SUBGROUP SG ON P.SUBGROUP = SG.SUBGROUPID
	  LEFT JOIN PRD_CATEGORY C ON SG.CATEGORY = C.CATEGORYID
	 WHERE DATE_DT = @Date
	 GROUP BY C.CATEGORY_NM, P.NAME_NM
	 UNION ALL
	SELECT 'HEPSİ', P.NAME_NM, 
		   SUM(CASE WHEN STORE != 1001 THEN STOCK_AMT ELSE 0 END) STORESTOCK_AMT,
		   SUM(CASE WHEN STORE != 1001 THEN STOCK_QTY ELSE 0 END) STORESTOCK_QTY,
		   SUM(CASE WHEN STORE != 1001 THEN SALE_AMT ELSE 0 END) STORESALEAVG_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN STOCK_AMT ELSE 0 END) WAREHOUSESTOCK_AMT,
		   SUM(CASE WHEN STORE = 1001 THEN STOCK_QTY ELSE 0 END) WAREHOUSESTOCK_QTY,
		   SUM(CASE WHEN STORE = 1001 THEN SALE_AMT ELSE 0 END) WAREHOUSESALEAVG_AMT
	  FROM INV_STOCKDASHBOARD SP
	  JOIN PRD_PRODUCT P ON SP.PRODUCT = P.PRODUCTID
	 WHERE DATE_DT = @Date
	 GROUP BY P.NAME_NM

	-- MAĞAZA BAZLI SON GÜN DEĞERLER
	SELECT C.CATEGORY_NM, ST.STORE_NM,
		   SUM(STOCK_AMT) STORESTOCK_AMT,
		   SUM(STOCK_QTY) STORESTOCK_QTY,
		   SUM(SALE_AMT) STORESALEAVG_AMT
	  FROM INV_STOCKDASHBOARD SP
	  JOIN STR_STORE ST ON SP.STORE = ST.STOREID
	  JOIN PRD_PRODUCT P ON SP.PRODUCT = P.PRODUCTID
	  LEFT JOIN PRD_SUBGROUP SG ON P.SUBGROUP = SG.SUBGROUPID
	  LEFT JOIN PRD_CATEGORY C ON SG.CATEGORY = C.CATEGORYID
	 WHERE DATE_DT = @Date
	   AND STORE != 1001 
	 GROUP BY C.CATEGORY_NM, ST.STORE_NM
	 UNION ALL
	SELECT 'HEPSİ', ST.STORE_NM,
		   SUM(STOCK_AMT) STORESTOCK_AMT,
		   SUM(STOCK_QTY) STORESTOCK_QTY,
		   SUM(SALE_AMT) STORESALEAVG_AMT
	  FROM INV_STOCKDASHBOARD SP
	  JOIN STR_STORE ST ON SP.STORE = ST.STOREID
	 WHERE DATE_DT = @Date
	   AND STORE != 1001 
	 GROUP BY ST.STORE_NM
END