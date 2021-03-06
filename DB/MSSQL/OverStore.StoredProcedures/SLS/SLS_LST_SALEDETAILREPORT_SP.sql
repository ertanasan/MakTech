﻿CREATE PROCEDURE [dbo].[SLS_LST_SALEDETAILREPORT_SP]
	@Store INT = -1,      
	@StartDate DATE = NULL,      
	@EndDate DATE = NULL,  
	@Product INT = -1  AS      
BEGIN      
  
	IF OBJECT_ID('tempdb.dbo.#stores', 'U') IS NOT NULL  DROP TABLE #stores;  
	SELECT * into #stores FROM dbo.STR_GETUSERSTORES_FN();      
  
	IF @StartDate IS NULL       
	BEGIN      
	  Set @StartDate = GETDATE()  
	  Set @EndDate = GETDATE()     
	END      
	ELSE IF @EndDate IS NULL  
	BEGIN  
	  Set @EndDate = @StartDate  
	END  
	    
	IF @Store IS NULL OR @Store = -1  
	BEGIN  
		IF @Product IS NULL OR @Product = -1  
		BEGIN  
  
			SELECT SD.TRANSACTION_DT [TRANSACTION_DATE],
				   S.TRANSACTION_TM, 
				   ST.STORE_NM,      
				   CAST(SD.SALEDETAILID AS VARCHAR) SALEDETAILID,
				   CAST(SD.SALE AS VARCHAR) SALE,
				   P.NAME_NM,     
				   P.CODE_NM,    
				   C.CATEGORY_NM,     
				   SD.PRICE,      
				   SD.VAT_RT,      
				   CASE WHEN SD.UNIT = 1 THEN SD.QUANTITY_QTY / 1000.0 ELSE SD.QUANTITY_QTY END [QUANTITY],       
				   CASE WHEN SD.UNIT = 1 THEN 'KG' ELSE 'ADET' END [ADET_KG],      
				   SD.UNITPRICE_AMT      
			  FROM SLS_SALEDETAIL SD (NOLOCK)      
			  JOIN SLS_SALE S (NOLOCK) ON SD.SALE = S.SALEID  
			  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID     
			  LEFT JOIN PRD_SUBGROUP SG (NOLOCK) ON P.SUBGROUP = SG.SUBGROUPID         
			  LEFT JOIN PRD_CATEGORY C (NOLOCK)  ON SG.CATEGORY = C.CATEGORYID     
			  JOIN #stores ST ON SD.STORE = ST.STOREID   
			 WHERE SD.TRANSACTION_DT >= @StartDate      
			   AND SD.TRANSACTION_DT <= @EndDate      
			   AND SD.DELETED_FL = 'N'      
			   AND SD.CANCEL_FL = 'N'      
			   AND S.CANCELLED_FL = 'N'  
			 ORDER BY SD.TRANSACTION_DT, SD.SALE, SD.PRODUCT;      
  
		END  
  
		ELSE  
		BEGIN  
  
			SELECT SD.TRANSACTION_DT [TRANSACTION_DATE],      
				   S.TRANSACTION_TM, 
				   ST.STORE_NM,      
				   CAST(SD.SALEDETAILID AS VARCHAR) SALEDETAILID,
				   CAST(SD.SALE AS VARCHAR) SALE,
				   P.NAME_NM,     
				   P.CODE_NM,    
				   C.CATEGORY_NM,     
				   SD.PRICE,      
				   SD.VAT_RT,      
				   CASE WHEN SD.UNIT = 1 THEN SD.QUANTITY_QTY / 1000.0 ELSE SD.QUANTITY_QTY END [QUANTITY],       
				   CASE WHEN SD.UNIT = 1 THEN 'KG' ELSE 'ADET' END [ADET_KG],      
				   SD.UNITPRICE_AMT      
			  FROM SLS_SALEDETAIL SD (NOLOCK)      
			  JOIN SLS_SALE S (NOLOCK) ON SD.SALE = S.SALEID  
			  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID     
			  LEFT JOIN PRD_SUBGROUP SG (NOLOCK) ON P.SUBGROUP = SG.SUBGROUPID         
			  LEFT JOIN PRD_CATEGORY C (NOLOCK)  ON SG.CATEGORY = C.CATEGORYID     
			  JOIN #stores ST ON SD.STORE = ST.STOREID      
			 WHERE SD.TRANSACTION_DT >= @StartDate      
			   AND SD.TRANSACTION_DT <= @EndDate      
			   AND SD.DELETED_FL = 'N'      
			   AND SD.CANCEL_FL = 'N'     
			   AND P.PRODUCTID = @Product   
			   AND S.CANCELLED_FL = 'N'  
			 ORDER BY SD.TRANSACTION_DT, SD.SALE, SD.PRODUCT;  
    
		END  
  
	END  
   
	ELSE  
	BEGIN  
    
	IF @Product IS NULL OR @Product = -1  
	BEGIN  
     
		SELECT SD.TRANSACTION_DT [TRANSACTION_DATE],
			   S.TRANSACTION_TM,
			   ST.STORE_NM,      
			   CAST(SD.SALEDETAILID AS VARCHAR) SALEDETAILID,
			   CAST(SD.SALE AS VARCHAR) SALE,
			   P.NAME_NM,     
			   P.CODE_NM,    
			   C.CATEGORY_NM,     
			   SD.PRICE,      
			   SD.VAT_RT,      
			   CASE WHEN SD.UNIT = 1 THEN SD.QUANTITY_QTY / 1000.0 ELSE SD.QUANTITY_QTY END [QUANTITY],       
			   CASE WHEN SD.UNIT = 1 THEN 'KG' ELSE 'ADET' END [ADET_KG],      
			   SD.UNITPRICE_AMT      
		  FROM SLS_SALEDETAIL SD (NOLOCK)      
		  JOIN SLS_SALE S (NOLOCK) ON SD.SALE = S.SALEID  
		  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID     
		  LEFT JOIN PRD_SUBGROUP SG (NOLOCK) ON P.SUBGROUP = SG.SUBGROUPID         
		  LEFT JOIN PRD_CATEGORY C (NOLOCK)  ON SG.CATEGORY = C.CATEGORYID     
		  JOIN #stores ST ON SD.STORE = ST.STOREID      
		 WHERE SD.STORE = @Store  
		   AND SD.TRANSACTION_DT >= @StartDate      
		   AND SD.TRANSACTION_DT <= @EndDate      
		   AND SD.DELETED_FL = 'N'      
		   AND SD.CANCEL_FL = 'N'      
		   AND S.CANCELLED_FL = 'N'  
		 ORDER BY SD.TRANSACTION_DT, SD.SALE, SD.PRODUCT;      
  
	END  
  
	ELSE  
	BEGIN  
  
		SELECT SD.TRANSACTION_DT [TRANSACTION_DATE],
			   S.TRANSACTION_TM,
			   ST.STORE_NM,      
			   CAST(SD.SALEDETAILID AS VARCHAR) SALEDETAILID,
			   CAST(SD.SALE AS VARCHAR) SALE,
			   P.NAME_NM,     
			   P.CODE_NM,    
			   C.CATEGORY_NM,     
			   SD.PRICE,      
			   SD.VAT_RT,      
			   CASE WHEN SD.UNIT = 1 THEN SD.QUANTITY_QTY / 1000.0 ELSE SD.QUANTITY_QTY END [QUANTITY],       
			   CASE WHEN SD.UNIT = 1 THEN 'KG' ELSE 'ADET' END [ADET_KG],      
			   SD.UNITPRICE_AMT      
		  FROM SLS_SALEDETAIL SD (NOLOCK)      
		  JOIN SLS_SALE S (NOLOCK) ON SD.SALE = S.SALEID  
		  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID     
		  LEFT JOIN PRD_SUBGROUP SG (NOLOCK) ON P.SUBGROUP = SG.SUBGROUPID         
		  LEFT JOIN PRD_CATEGORY C (NOLOCK)  ON SG.CATEGORY = C.CATEGORYID     
		  JOIN #stores ST ON SD.STORE = ST.STOREID     
		 WHERE SD.STORE = @Store  
		   AND SD.TRANSACTION_DT >= @StartDate      
		   AND SD.TRANSACTION_DT <= @EndDate      
		   AND SD.DELETED_FL = 'N'      
		   AND SD.CANCEL_FL = 'N'    
		   AND P.PRODUCTID = @Product    
		   AND S.CANCELLED_FL = 'N'  
		 ORDER BY SD.TRANSACTION_DT, SD.SALE, SD.PRODUCT;    
  
	END  
  
  END   
  
END; 