﻿CREATE PROCEDURE SLS_LST_SALESBYCATEGORYNAME_SP @Category VARCHAR(100), @StoreId INT = -1, @EndDate DATETIME, @ProductId INT = -1 AS  
BEGIN  
 IF OBJECT_ID('tempdb..#stores') IS NOT NULL DROP TABLE #stores
 SELECT STOREID INTO #stores FROM dbo.STR_GETUSERSTORES_FN()
 
 DECLARE @currentDate DATE = dbo.STR_GETUSERCURRENTDATE_FN(); -- CAST(GETDATE() AS DATE)

 IF @EndDate IS NULL OR @EndDate > @currentDate SET @EndDate = @currentDate

 DECLARE @startday DATE = @EndDate - 30  
 DECLARE @endday DATE = @EndDate - 1 
 SELECT CAST(DATE_DT AS DATE) TRANSACTION_DT, SUM(ISNULL(PRICE,0)) SALE  
   FROM RPT_DATE DT
   JOIN PRD_PRODUCT_VW P ON (@ProductId = -1 OR P.PRODUCTID = @ProductId) AND (@Category = 'All' OR CATEGORY_NM = @Category)
   JOIN #stores ST ON (@StoreId = -1 OR ST.STOREID = @StoreId)  
   LEFT JOIN SLS_STOREDAILYPRODUCT_SYN S ON DT.DATE_DT = S.TRANSACTION_DT AND P.PRODUCTID = S.PRODUCT AND ST.STOREID = S.STORE AND TRANSACTION_DT BETWEEN @startday and @endday  
  WHERE DATE_DT BETWEEN @startday and @endday  
  GROUP BY DT.DATE_DT
  ORDER BY 1  
END;