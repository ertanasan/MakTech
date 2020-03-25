﻿CREATE PROCEDURE [dbo].[SLS_INS_WINCORSALESDATE_SP] @Date DATE, @StoreId INT = -1 AS      
BEGIN                
                
  IF OBJECT_ID('tempdb..#WNCHEADERS') IS NOT NULL DROP TABLE #WNCHEADERS               
  IF OBJECT_ID('tempdb..#WNCREFUNDHEADERS') IS NOT NULL DROP TABLE #WNCREFUNDHEADERS            
              
  IF OBJECT_ID('tempdb..#WNCLINES') IS NOT NULL DROP TABLE #WNCLINES                  
  IF OBJECT_ID('tempdb..#WNCREFUNDLINES') IS NOT NULL DROP TABLE #WNCREFUNDLINES                 
              
  IF OBJECT_ID('tempdb..#WNCREFUNDPAYMENTS') IS NOT NULL DROP TABLE #WNCREFUNDPAYMENTS               
  IF OBJECT_ID('tempdb..#WNCPAYMENTS') IS NOT NULL DROP TABLE #WNCPAYMENTS                  
              
  -- SALES                
  SELECT CAST(BRANCH_CODE AS VARCHAR(10))+'-'+CAST(POS_ID AS VARCHAR(10))+'-'+CONVERT(CHAR(8),TRANSACTION_DATE,112)+REPLACE(ORJ_TRANSACTION_TIME,':','')+'-'+CAST(ID AS VARCHAR(10)) COLLATE Turkish_100_CI_AS TRANSACTION_TXT,                
         BRANCH_CODE, '00000000' CASHIER_NM, POS_ID, TRANSACTION_DATE, CONVERT(DATETIME,REPLACE(CONVERT(VARCHAR(20), TRANSACTION_DATE, 120),'00:00:00',ORJ_TRANSACTION_TIME),120) TRANSACTION_TM,                
		 TOT_NET_VALUE TOTALVAT_AMT, TOT_GROSS_VALUE_VAT TOTAL_AMT, LINE_DISCOUNTS_VAT, DOC_DISCOUNT_VAT, NOF_LINES, 0 DURATION_CNT, 'N' DELETED_FL,                 
		 CASE WHEN LEFT(USER_DOC_NUMBER,2) = '**' THEN 1 ELSE 2 END TRANSACTIONTYPE                
    INTO #WNCHEADERS                
    FROM WNC_POSTRANHEADERS                
   WHERE TRANSACTION_DATE = @Date             
     AND (@StoreId = -1 OR BRANCH_CODE = @StoreId)        
                  
  INSERT INTO SLS_SALE                
  (EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN,                 
  TRANSACTION_TXT, STORE, CASHIER_NM, CASHREGISTER, TRANSACTION_DT, TRANSACTION_TM, TOTALVAT_AMT, TOTAL_AMT,                
  PRODUCTDISCOUNT_AMT, SALEDISCOUNT_AMT, PRODUCT_CNT, DURATION_CNT, CANCELLED_FL, TRANSACTIONTYPE)                
  SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, H.*                
    FROM #WNCHEADERS H                
    LEFT JOIN SLS_SALE S ON H.TRANSACTION_TXT = S.TRANSACTION_TXT                
   WHERE S.TRANSACTION_TXT IS NULL                
                  
  SELECT CAST(A.BRANCH_CODE AS VARCHAR(10))+'-'+CAST(A.POS_ID AS VARCHAR(10))+'-'+CONVERT(CHAR(8),A.TRANSACTION_DATE,112)+REPLACE(A.ORJ_TRANSACTION_TIME,':','')+'-'+CAST(A.ID AS VARCHAR(10)) COLLATE Turkish_100_CI_AS TRANSACTION_TXT,                
		 A.TRANSACTION_DATE TRANSACTION_DT, SUBST_CODE COLLATE Turkish_100_CI_AS  BARCODE_TXT, A.BRANCH_CODE STORE, TRANSACTION_VALUE PRICE, VAT_PERCENT VAT_RT, QUANTITY QUANTITY_QTY                 
    INTO #WNCLINES                
    FROM WNC_POSTRANHEADERS A                
    JOIN WNC_POSTRANLINES B ON A.POS_ID = B.POS_ID AND A.TRANSACTION_DATE = B.TRANSACTION_DATE AND A.DOC_PTR = B.DOC_PTR                
   WHERE A.TRANSACTION_DATE = @Date        
     AND (@StoreId = -1 OR A.BRANCH_CODE = @StoreId);        
                  
  WITH HEADER AS (            
  SELECT H.*, S.SALEID, S.TRANSACTION_DT, S.STORE            
    FROM #WNCHEADERS H            
    JOIN SLS_SALE S ON H.TRANSACTION_TXT = S.TRANSACTION_TXT            
    LEFT JOIN SLS_SALEDETAIL SD ON S.SALEID = SD.SALE                
   WHERE SD.SALE IS NULL)            
  INSERT INTO SLS_SALEDETAIL            
  (EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, SALE,                
  TRANSACTION_TXT, TRANSACTION_DT, BARCODE_TXT, PRODUCT, PRODUCTCODE_NM, STORE, PRICE, VAT_RT, QUANTITY_QTY,                
  UNIT, CANCEL_FL, UNITPRICE_AMT)                
  SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, H.SALEID, H.TRANSACTION_TXT, H.TRANSACTION_DT, L.BARCODE_TXT, P.PRODUCTID, P.CODE_NM,                 
         H.STORE, L.PRICE, L.VAT_RT, CASE WHEN P.UNIT = 1 THEN L.QUANTITY_QTY*1000 ELSE L.QUANTITY_QTY END,             
		 P.UNIT, 'N', ROUND(L.PRICE/(L.QUANTITY_QTY*1.0),CASE WHEN P.UNIT=1 THEN 1 ELSE 2 END)                 
    FROM HEADER H            
    JOIN #WNCLINES L ON H.TRANSACTION_TXT = L.TRANSACTION_TXT              
    LEFT JOIN PRD_BARCODE B ON L.BARCODE_TXT = B.BARCODE_TXT                
    JOIN PRD_PRODUCT P ON COALESCE(B.PRODUCT,326) = P.PRODUCTID             
                  
  SELECT CAST(A.BRANCH_CODE AS VARCHAR(10))+'-'+CAST(A.POS_ID AS VARCHAR(10))+'-'+CONVERT(CHAR(8),A.TRANSACTION_DATE,112)+REPLACE(A.ORJ_TRANSACTION_TIME,':','')+'-'+CAST(A.ID AS VARCHAR(10)) COLLATE Turkish_100_CI_AS TRANSACTION_TXT,                
		 SUM(CASE WHEN B.PAY_TYPE = 0 THEN PAY_AMOUNT ELSE 0 END) PAID_AMT,                
		 SUM(CASE WHEN B.PAY_TYPE != 0 THEN PAY_AMOUNT ELSE 0 END) CARD_AMT                
    INTO #WNCPAYMENTS                 
    FROM WNC_POSTRANHEADERS A                
    JOIN WNC_POSTRANPAYMENTS B ON A.POS_ID = B.POS_ID AND A.TRANSACTION_DATE = B.TRANSACTION_DATE AND A.DOC_PTR = B.DOC_PTR                
   WHERE A.TRANSACTION_DATE = @Date      
     AND (@StoreId = -1 OR A.BRANCH_CODE = @StoreId)        
   GROUP BY CAST(A.BRANCH_CODE AS VARCHAR(10))+'-'+CAST(A.POS_ID AS VARCHAR(10))+'-'+CONVERT(CHAR(8),A.TRANSACTION_DATE,112)+REPLACE(A.ORJ_TRANSACTION_TIME,':','')+'-'+CAST(A.ID AS VARCHAR(10)) COLLATE Turkish_100_CI_AS                 
                  
  INSERT INTO SLS_SALEPAYMENT                
  (EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN,                 
   SALE, TRANSACTION_TXT, TRANSACTION_DT, STORE, PAYMENTTYPE_TXT, PAID_AMT, REFUND_AMT, CARD_AMT)                
  SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, S.SALEID, S.TRANSACTION_TXT, S.TRANSACTION_DT, S.STORE,                 
		 CASE WHEN P.PAID_AMT > 0 THEN '00' ELSE '01' END, P.PAID_AMT, 0, P.CARD_AMT                
    FROM #WNCPAYMENTS P                
    JOIN SLS_SALE S ON P.TRANSACTION_TXT = S.TRANSACTION_TXT                
    LEFT JOIN SLS_SALEPAYMENT SP ON S.SALEID = SP.SALE                
   WHERE SP.SALE IS NULL                
                 
  -- ZET            
  INSERT INTO SLS_SALEZET
  (EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, UPDATE_DT, CREATEUSER, UPDATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, 
   STORE, TRANSACTION_DT, TRANSACTION_TM, ZET_NO, 
   RECEIPT_CNT, RECEIPTTOTAL_AMT, REFUND_CNT, REFUND_AMT, CASH_AMT, CARD_AMT, CASHREGISTER, SLPTOTAL_AMT, SLP_CNT)
  SELECT 1045, 1, 'N', GETDATE(), NULL, 1, NULL, 1, 1, 1, BRANCH_CODE, Z1.ZETDATE, TRANSACTION_DATE, zno, salereccount,
		 dailytotal, gpcount, gptotal, totalcash, totalcc, Z1.POS_ID, invtotal, invcount
    FROM (SELECT convert(date, xdate, 103) ZETDATE, BRANCH_CODE, POS_ID, zno, salereccount, dailytotal, gpcount, gptotal,
				 totalcash, totalcc, invtotal, invcount, TRANSACTION_DATE,
				 row_number() over (partition by convert(date, xdate, 103), POS_Id, zno ORDER BY TRANSACTION_DATE DESC) rowno
			FROM WNC_POSZET
		   WHERE (@StoreId = -1 OR BRANCH_CODE = @StoreId) ) Z1
    JOIN STR_STORE_VW ST ON Z1.BRANCH_CODE = ST.STOREID AND ST.TERMINAL = 'Wincor'
    LEFT JOIN SLS_SALEZET Z2 ON Z1.BRANCH_CODE = Z2.STORE AND Z1.ZETDATE = Z2.TRANSACTION_DT  AND Z1.POS_ID = Z2.CASHREGISTER AND Z1.ZNO = Z2.ZET_NO -- AND Z2.DELETED_FL = 'N'
   WHERE Z1.rowno = 1
     AND Z2.STORE IS NULL
              
  -- REFUNDS            
  SELECT CAST(BRANCH_CODE AS VARCHAR(10))+'-'+CAST(POS_ID AS VARCHAR(10))+'-'+CONVERT(CHAR(8),TRANSACTION_DATE,112)+REPLACE(ORJ_TRANSACTION_TIME,':','')+'-'+CAST(ID AS VARCHAR(10)) COLLATE Turkish_100_CI_AS TRANSACTION_TXT,                
		 BRANCH_CODE, '00000000' CASHIER_NM, POS_ID, TRANSACTION_DATE, CONVERT(DATETIME,REPLACE(CONVERT(VARCHAR(20), TRANSACTION_DATE, 120),'00:00:00',ORJ_TRANSACTION_TIME),120) TRANSACTION_TM,                
		 -1*NET_VALUE TOTALVAT_AMT, -1*TOTAL_GROSS_VALUE TOTAL_AMT, LINE_DISCOUNT_TOTAL, DOCUMENT_DISCOUNT, NOF_LINES, 0 DURATION_CNT, 'N' DELETED_FL, 5 TRANSACTIONTYPE                
    INTO #WNCREFUNDHEADERS                
    FROM WNC_STOCKTRANHEADERS                
   WHERE TRANSACTION_TYPE = 12            
     AND TRANSACTION_DATE = @Date             
     AND (@StoreId = -1 OR BRANCH_CODE = @StoreId)        
             
              
  INSERT INTO SLS_SALE                
  (EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN,                 
  TRANSACTION_TXT, STORE, CASHIER_NM, CASHREGISTER, TRANSACTION_DT, TRANSACTION_TM, TOTALVAT_AMT, TOTAL_AMT,                
  PRODUCTDISCOUNT_AMT, SALEDISCOUNT_AMT, PRODUCT_CNT, DURATION_CNT, CANCELLED_FL, TRANSACTIONTYPE)                
  SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, H.*       
    FROM #WNCREFUNDHEADERS H                
    LEFT JOIN SLS_SALE S ON H.TRANSACTION_TXT = S.TRANSACTION_TXT                
   WHERE S.TRANSACTION_TXT IS NULL               
              
  SELECT CAST(A.BRANCH_CODE AS VARCHAR(10))+'-'+CAST(A.POS_ID AS VARCHAR(10))+'-'+CONVERT(CHAR(8),A.TRANSACTION_DATE,112)+REPLACE(A.ORJ_TRANSACTION_TIME,':','')+'-'+CAST(A.ID AS VARCHAR(10)) COLLATE Turkish_100_CI_AS TRANSACTION_TXT,                
         A.TRANSACTION_DATE TRANSACTION_DT, B.EXTRA2 COLLATE Turkish_100_CI_AS  BARCODE_TXT, A.BRANCH_CODE STORE, -1*TRANSACTION_VALUE PRICE, VAT_PERCENT VAT_RT, QUANTITY QUANTITY_QTY                 
    INTO #WNCREFUNDLINES                
    FROM WNC_STOCKTRANHEADERS A                
    JOIN WNC_STOCKTRANLINES B ON A.ID = B.HEADER_ID            
   WHERE A.TRANSACTION_TYPE = 12            
     AND A.TRANSACTION_DATE = @Date             
     AND (@StoreId = -1 OR A.BRANCH_CODE = @StoreId)        
             
              
  INSERT INTO SLS_SALEDETAIL                
  (EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN, SALE,                
   TRANSACTION_TXT, TRANSACTION_DT, BARCODE_TXT, PRODUCT, PRODUCTCODE_NM, STORE, PRICE, VAT_RT, QUANTITY_QTY,                
   UNIT, CANCEL_FL, UNITPRICE_AMT)                
  SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, S.SALEID, S.TRANSACTION_TXT, S.TRANSACTION_DT, L.BARCODE_TXT, P.PRODUCTID, P.CODE_NM,                 
         S.STORE, L.PRICE, L.VAT_RT, CASE WHEN P.UNIT = 1 THEN L.QUANTITY_QTY*1000 ELSE L.QUANTITY_QTY END,             
		 P.UNIT, 'N', ROUND(L.PRICE/(L.QUANTITY_QTY*1.0),CASE WHEN P.UNIT=1 THEN 1 ELSE 2 END)               
    FROM #WNCREFUNDLINES L                
    JOIN SLS_SALE S ON L.TRANSACTION_TXT = S.TRANSACTION_TXT                 
    LEFT JOIN PRD_BARCODE B ON L.BARCODE_TXT = B.BARCODE_TXT                
    JOIN PRD_PRODUCT P ON COALESCE(B.PRODUCT,326) = P.PRODUCTID                
    LEFT JOIN SLS_SALEDETAIL SD ON S.SALEID = SD.SALE                
   WHERE SD.SALE IS NULL            
              
  SELECT CAST(A.BRANCH_CODE AS VARCHAR(10))+'-'+CAST(A.POS_ID AS VARCHAR(10))+'-'+CONVERT(CHAR(8),A.TRANSACTION_DATE,112)+REPLACE(A.ORJ_TRANSACTION_TIME,':','')+'-'+CAST(A.ID AS VARCHAR(10)) COLLATE Turkish_100_CI_AS TRANSACTION_TXT,                
		 SUM(CASE WHEN B.PAY_TYPE = 0 THEN PAY_AMOUNT ELSE 0 END) PAID_AMT,                
		 SUM(CASE WHEN B.PAY_TYPE != 0 THEN PAY_AMOUNT ELSE 0 END) CARD_AMT                
    INTO #WNCREFUNDPAYMENTS                 
    FROM WNC_STOCKTRANHEADERS A                
    JOIN WNC_STOCKTRANPAYMENTS B ON A.POS_ID = B.POS_ID AND A.TRANSACTION_DATE = B.TRANSACTION_DATE AND A.DAILY_COUNTER = B.DOC_PTR                
   WHERE A.TRANSACTION_TYPE = 12            
     AND A.TRANSACTION_DATE = @Date              
     AND (@StoreId = -1 OR A.BRANCH_CODE = @StoreId)        
   GROUP BY CAST(A.BRANCH_CODE AS VARCHAR(10))+'-'+CAST(A.POS_ID AS VARCHAR(10))+'-'+CONVERT(CHAR(8),A.TRANSACTION_DATE,112)+REPLACE(A.ORJ_TRANSACTION_TIME,':','')+'-'+CAST(A.ID AS VARCHAR(10)) COLLATE Turkish_100_CI_AS                 
              
  INSERT INTO SLS_SALEPAYMENT                
  (EVENT, ORGANIZATION, DELETED_FL, CREATE_DT, CREATEUSER, CREATECHANNEL, CREATEBRANCH, CREATESCREEN,                 
   SALE, TRANSACTION_TXT, TRANSACTION_DT, STORE, PAYMENTTYPE_TXT, PAID_AMT, REFUND_AMT, CARD_AMT)                
  SELECT 1045, 1, 'N', GETDATE(), 1, 1, 1, 1, S.SALEID, S.TRANSACTION_TXT, S.TRANSACTION_DT, S.STORE,                 
		 CASE WHEN P.PAID_AMT > 0 THEN '00' ELSE '01' END, -1*P.PAID_AMT, 0, -1*P.CARD_AMT                
    FROM #WNCREFUNDPAYMENTS P                
    JOIN SLS_SALE S ON P.TRANSACTION_TXT = S.TRANSACTION_TXT                
    LEFT JOIN SLS_SALEPAYMENT SP ON S.SALEID = SP.SALE                
   WHERE SP.SALE IS NULL                
            
END; 