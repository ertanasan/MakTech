﻿CREATE VIEW INV_STORETRANSACTIONS_VW AS  
SELECT WAREHOUSE STORE, COALESCE(PP.PRODUCTID, P.PRODUCTID) PRODUCT, TRANSACTION_DT, TRANSACTIONTYPE_NM, QUANTITY_QTY  
  FROM INV_STOCKTRANSACTIONS_SYN ST  
  JOIN INV_WAREHOUSE_SYN W ON ST.WAREHOUSE = W.WAREHOUSEID  
  JOIN INV_TRANSACTIONTYPE_SYN TT ON ST.TRANSACTIONTYPE = TT.TRANSACTIONTYPEID  
  JOIN PRD_PRODUCT P ON ST.PRODUCT = P.PRODUCTID
  LEFT JOIN PRD_PRODUCT PP ON P.PARENT = PP.PRODUCTID
 WHERE W.WAREHOUSETYPE = 1  
   AND TRANSACTION_DT <= CAST(GETDATE() AS date)  
 UNION ALL  
SELECT STORE, PRODUCT, TRANSACTION_DT, 'Satış', -1*QUANTITY  
  FROM SLS_STOREDAILYPRODUCT_SYN  
 WHERE TRANSACTION_DT < CAST(GETDATE() AS date)  
 UNION ALL  
SELECT SD.STORE, PRODUCT, SD.TRANSACTION_DT, 'Satış', -1*SUM(QUANTITY_QTY/CASE WHEN P.UNIT = 1 THEN 1000.0 ELSE 1 END) QUANTITY_QTY  
  FROM SLS_SALEDETAIL SD  
  JOIN SLS_SALE S ON SD.SALE = S.SALEID  
  JOIN PRD_PRODUCT P ON SD.PRODUCT = P.PRODUCTID  
 WHERE SD.TRANSACTION_DT = CAST(GETDATE() AS date)  
   AND SD.CANCEL_FL = 'N'  
   AND S.CANCELLED_FL = 'N'  
 GROUP BY SD.STORE, PRODUCT, SD.TRANSACTION_DT