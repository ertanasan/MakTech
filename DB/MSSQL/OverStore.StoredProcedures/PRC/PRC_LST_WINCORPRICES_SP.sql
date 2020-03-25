﻿CREATE PROCEDURE PRC_LST_WINCORPRICES_SP 

	@VERSIONCONTROL INT = 1 AS        
        
BEGIN        
        
-- IF OBJECT_ID('tempdb..#PLU') IS NOT NULL DROP TABLE #PLU             
IF OBJECT_ID('tempdb..#STOREPACKAGES') IS NOT NULL DROP TABLE #STOREPACKAGES            
IF OBJECT_ID('tempdb..#ACTIVEPACKAGEPRICES') IS NOT NULL DROP TABLE #ACTIVEPACKAGEPRICES             
        
-- wincor mağazalara ait paketleri ve en son versiyonlarını bul.        
DECLARE @now DATETIME = getdate();        
-- select @now;        
SELECT *         
  INTO #STOREPACKAGES        
  FROM (        
SELECT SP.STORE, ST.STORE_NM, SP.PACKAGE, PP.PACKAGE_NM, PV2.VERSIONID, CR.PRICEFILEPATH_TXT        
     , CASE WHEN SP.PACKAGE = 1 THEN CR.CURRENTPRICEVERSION ELSE CR.PRIVATEPRICEVERSION END STOREVERSION        
  , CR.CURRENTPRICEVERSION STORECURRENTPRICEVERSION, PVCURRENT.VERSIONID CURRENTPRICEVERSION    
     , ROW_NUMBER() OVER (PARTITION BY SP.STORE ORDER BY SP.PRIORITY_NO DESC) PRIORITY_NO        
  FROM PRC_STOREPACKAGE SP        
  JOIN STR_STORE ST ON SP.STORE = ST.STOREID        
  JOIN PRC_PACKAGE PP ON SP.PACKAGE = PP.PACKAGEID        
  JOIN STR_CASHREGISTER CR ON SP.STORE = CR.STORE        
  JOIN STR_CASHREGISTERMODEL M ON CR.CASHREGISTERMODEL = M.CASHREGISTERMODELID        
  JOIN STR_CASHREGISTERBRAND B ON M.BRAND = B.CASHREGISTERBRANDID        
  JOIN (SELECT MAX(PV.PACKAGEVERSIONID) VERSIONID FROM PRC_PACKAGEVERSION PV WHERE PV.ACTIVE_FL = 'Y' AND PV.PACKAGE = 1) PVCURRENT ON 1=1    
  LEFT JOIN (SELECT PACKAGE, MAX(PV.PACKAGEVERSIONID) VERSIONID FROM PRC_PACKAGEVERSION PV WHERE PV.ACTIVE_FL = 'Y' GROUP BY PACKAGE) PV2 ON SP.PACKAGE = PV2.PACKAGE        
 WHERE B.BRAND_NM = 'Wincor'        
   AND SP.DELETED_FL = 'N'  
   AND PP.DELETED_FL = 'N'  
   AND @now BETWEEN SP.START_TM AND SP.END_TM) A        
 WHERE ((@VERSIONCONTROL = 1 AND (COALESCE(VERSIONID, -1) != COALESCE(STOREVERSION, -1) OR COALESCE(STORECURRENTPRICEVERSION, -1) != COALESCE(CURRENTPRICEVERSION, -1)))
		OR
		(@VERSIONCONTROL = 0))
   AND PRIORITY_NO = 1        
        
 -- güncel genel fiyatları al.        
 SELECT *        
   INTO #ACTIVEPACKAGEPRICES        
   FROM (        
 SELECT *        
   FROM PRC_ACTIVEPACKAGEPRICES_V P1        
  WHERE PACKAGE = 1        
  UNION ALL        
 SELECT COALESCE(P2.PRICEID, P1.PRICEID), SP.PACKAGE,  SP.VERSIONID, P1.PRODUCT, COALESCE(P2.PRICE_AMT, P1.PRICE_AMT)        
      , COALESCE(P2.TOPPRICE_AMT, P1.TOPPRICE_AMT), COALESCE(P2.PRINTTOPPRICE_FL, P1.PRINTTOPPRICE_FL)        
   FROM PRC_ACTIVEPACKAGEPRICES_V P1        
   JOIN (SELECT DISTINCT PACKAGE, VERSIONID FROM #STOREPACKAGES WHERE PACKAGE != 1) SP ON 1 = 1        
   LEFT JOIN PRC_ACTIVEPACKAGEPRICES_V P2 ON P1.PRODUCT = P2.PRODUCT AND P2.PACKAGE = SP.PACKAGE        
  WHERE P1.PACKAGE = 1) A        
        
-- mağazaya fiyat çıkışı yapacak verileri oluştur.         
SELECT PP.PRODUCTID, PP.ORGANIZATION, PP.DELETED_FL, PP.CREATE_DT, PP.UPDATE_DT, PP.CREATEUSER, PP.UPDATEUSER        
     , AP.PRICE_AMT, AP.PRODUCT, AP.PACKAGE, AP.TOPPRICE_AMT, AP.PRINTTOPPRICE_FL, SP.VERSIONID PACKAGEVERSION, SP.CURRENTPRICEVERSION       
     , PR.NAME_NM PRODUCT_NM                
     , PR.CODE_NM PRODUCTCODE_NM                
     , PR.SALEVAT_RT                 
     , PR.UNIT                
     , BR.BARCODE_TXT PLU1      
     , PF.CATEGORY_NM, PT.SUBGROUP_NM        
  , SP.STORE, SP.PRICEFILEPATH_TXT        
  FROM #STOREPACKAGES SP        
  JOIN #ACTIVEPACKAGEPRICES AP ON SP.PACKAGE = AP.PACKAGE        
  JOIN PRC_PRODUCT PP ON AP.PRICEID = PP.PRODUCTID        
  JOIN PRD_PRODUCT PR (NOLOCK) ON AP.PRODUCT=PR.PRODUCTID                
  JOIN PRD_BARCODE BR ON PR.PRODUCTID = BR.PRODUCT      
  LEFT JOIN PRD_SUBGROUP PT ON PR.SUBGROUP = PT.SUBGROUPID                
  LEFT JOIN PRD_CATEGORY PF ON PT.CATEGORY = PF.CATEGORYID        
 WHERE PP.DELETED_FL = 'N'  
   AND BR.DELETED_FL = 'N'  
        
END; 