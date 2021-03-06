﻿CREATE PROCEDURE [dbo].[WHS_LST_STOREORDERCOMPARISONREPORT_SP]           
 @StartDate DATE = NULL,        
 @EndDate DATE = NULL    
AS        
BEGIN        
        
        
   /* Section="Parameter Modification"*/        
   IF @StartDate IS NULL         
   BEGIN        
    Set @StartDate = GETDATE()        
    Set @EndDate = GETDATE()        
   END        
   ELSE IF @EndDate IS NULL        
    Set @EndDate = @StartDate        
        
 /* Section="Temp Table Control"*/    
 --IF OBJECT_ID('tempdb..#stores') IS NOT NULL DROP TABLE #stores                
 IF OBJECT_ID('tempdb..#products') IS NOT NULL DROP TABLE #products                
 IF OBJECT_ID('tempdb..#orderdetails') IS NOT NULL DROP TABLE #orderdetails     
      
      
  SELECT P.PRODUCTID, P.CODE_NM, B.SCALECODE_NM, P.NAME_NM, C.CATEGORY_NM,              
  CASE P.UNIT WHEN 1 THEN 'KG' ELSE 'AD' END UNIT_NM               
   INTO #products                
   FROM PRD_PRODUCT P     
   LEFT JOIN (SELECT PRODUCT, MAX(SUBSTRING(BARCODE_TXT,4,10)) SCALECODE_NM     
       FROM PRD_BARCODE WHERE BARCODE_TXT LIKE '290%' AND BARCODETYPE = 1     
       GROUP BY PRODUCT) B ON P.PRODUCTID = B.PRODUCT               
   LEFT JOIN PRD_SUBGROUP SG ON P.SUBGROUP = SG.SUBGROUPID              
   LEFT JOIN PRD_CATEGORY C ON SG.CATEGORY = C.CATEGORYID              
  WHERE P.SUPERGROUP3 NOT IN (1,3)                
    AND P.DELETED_FL = 'N'                
    AND P.ACTIVE_FL = 'Y'       
    
 SELECT OD.PRODUCT    
   , SUM(OD.ORDER_QTY) ORDERED_PACKAGE      
      , SUM(OD.SHIPPED_QTY) SHIPPED_PACKAGE    
   --, SUM(OD.SHIPPED_QTY - OD.REVISED_QTY)  DIFF_PACKAGE    
   , SUM(OD.ORDER_QTY * OD.ORDERUNIT_QTY) ORDERED_AMOUNT     
   , SUM(OD.SHIPPED_QTY * OD.ORDERUNIT_QTY) SHIPPED_AMOUNT     
   --, SUM(OD.SHIPPED_QTY - OD.REVISED_QTY)  DIFF_AMOUNT    
   , COUNT(DISTINCT OD.STOREORDER) STOREORDER_CN    
   , SUM(CASE WHEN OD.SHIPPED_QTY != OD.REVISED_QTY THEN 1 END)  DIFF_CN    
   , COUNT(DISTINCT CASE WHEN OD.SHIPPED_QTY != OD.REVISED_QTY THEN O.STORE END)  DIFFSTORE_CN    
 INTO #orderdetails    
 FROM WHS_STOREORDERDETAIL (NOLOCK) OD    
   JOIN WHS_STOREORDER (NOLOCK) O ON OD.STOREORDER = O.STOREORDERID    
 WHERE O.SHIPMENT_DT >= @StartDate    
   AND O.SHIPMENT_DT <= @EndDate    
   AND O.STATUS = 4    
   AND OD.ORDER_QTY > 0    
 GROUP BY OD.PRODUCT    
    
 SELECT OD.ORDERED_PACKAGE    
      , OD.SHIPPED_PACKAGE    
   , (OD.SHIPPED_PACKAGE - OD.ORDERED_PACKAGE) DIFF_PACKAGE    
   , FORMAT(((OD.SHIPPED_PACKAGE - OD.ORDERED_PACKAGE) / OD.ORDERED_PACKAGE), 'P2', 'tr-tr') DIFF_PACKAGE_PERCENTAGE    
   , OD.ORDERED_AMOUNT    
   , OD.SHIPPED_AMOUNT    
   , (OD.SHIPPED_AMOUNT - OD.ORDERED_AMOUNT) DIFF_AMOUNT    
   , ABS(OD.SHIPPED_AMOUNT - OD.ORDERED_AMOUNT) ABSDIFF_AMOUNT    
   , FORMAT(((OD.SHIPPED_AMOUNT - OD.ORDERED_AMOUNT) / OD.ORDERED_AMOUNT), 'P2', 'tr-tr') DIFF_AMOUNT_PERCENTAGE    
   , OD.STOREORDER_CN    
   , OD.DIFF_CN    
   , FORMAT((OD.DIFF_CN * 1.0 / OD.STOREORDER_CN), 'P2', 'tr-tr') DIFFCN_PERCENTAGE    
   , OD.DIFFSTORE_CN    
   , P.CODE_NM PRODUCTCODE_NM    
   , P.NAME_NM PRODUCT_NM    
   , P.CATEGORY_NM    
   , P.UNIT_NM    
  FROM #products P    
 LEFT JOIN #orderdetails OD ON P.PRODUCTID = OD.PRODUCT    
  ORDER BY ABSDIFF_AMOUNT DESC;    
    
END; 