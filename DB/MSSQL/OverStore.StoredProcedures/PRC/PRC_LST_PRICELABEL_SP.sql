﻿CREATE PROCEDURE [dbo].[PRC_LST_PRICELABEL_SP]   
 @StoreID int AS   
  
BEGIN    
    
  DECLARE @now DATETIME = GETDATE();                          
  SELECT SP.STORE, ST.STORE_NM, SP.PACKAGE, PP.PACKAGE_NM, PV2.VERSIONID, PVCURRENT.VERSIONID CURRENTPRICEVERSION, SP.PRIORITY_NO                 
    INTO #STOREPACKAGES                
    FROM PRC_STOREPACKAGE SP                          
    JOIN STR_STORE ST ON SP.STORE = ST.STOREID                          
    JOIN PRC_PACKAGE PP ON SP.PACKAGE = PP.PACKAGEID                   
    JOIN (SELECT MAX(PV.PACKAGEVERSIONID) VERSIONID FROM PRC_PACKAGEVERSION PV WHERE PV.ACTIVE_FL = 'Y' AND PV.PACKAGE = 1) PVCURRENT ON 1=1                      
    LEFT JOIN (SELECT PACKAGE, MAX(PV.PACKAGEVERSIONID) VERSIONID FROM PRC_PACKAGEVERSION PV WHERE PV.ACTIVE_FL = 'Y' GROUP BY PACKAGE) PV2 ON SP.PACKAGE = PV2.PACKAGE                          
   WHERE SP.DELETED_FL = 'N'                    
     AND PP.DELETED_FL = 'N'         
     AND ST.DELETED_FL = 'N'    
     AND SP.STORE = @StoreID    
     AND @now BETWEEN SP.START_TM AND SP.END_TM                
                
  SELECT *                
    INTO #ACTIVEPACKAGEPRICES                
    FROM (SELECT SP.STORE, P.PRODUCT, PR.CODE_NM, P.TOPPRICE_AMT, P.PRINTTOPPRICE_FL    
      , ROW_NUMBER() OVER (PARTITION BY SP.STORE, P.PRODUCT ORDER BY SP.PRIORITY_NO DESC) ROWNUMBER                
   FROM PRC_ACTIVEPACKAGEPRICES_V P                
      JOIN #STOREPACKAGES SP ON P.PACKAGE = SP.PACKAGE                
      JOIN PRD_PRODUCT PR (NOLOCK) ON P.PRODUCT=PR.PRODUCTID                                  
     WHERE PR.DELETED_FL = 'N') A                
   WHERE A.ROWNUMBER = 1         
    
   SELECT    
      P.PRODUCTID,    
      P.CODE_NM,    
      P.NAME_NM,    
      P.SALEVAT_RT,    
      U.UNIT_NM,    
      P.BARCODETYPE,    
      BC.BARCODE_TXT,    
      P.PRIVATELABEL_FL,    
      P.ETRADE_FL,    
      P.SHORTNAME_NM,    
      P.DOMESTIC_FL,    
      C.COUNTRY_NM,    
      P.CONTENT_TXT,    
      W.WARNING_TXT,    
      SC.CONDITION_TXT,    
      P.EXPIRESIN_CNT,    
      P.SHELFLIFE_CNT,    
      CP.SALEPRICE_AMT PRICE_AMT,    
      AP.TOPPRICE_AMT TOPPRICE_AMT,    
      AP.PRINTTOPPRICE_FL PRINT_FL,    
      CP.VERSION_TM PRICECHANGE_DT,    
	   ISNULL(P.CAMPAIGN, 0) CAMPAIGN,    
       
	   CASE P.SUPERGROUP2     
	   WHEN 1 /*DÖKME*/THEN cp.SALEPRICE_AMT    
	   WHEN 2 /*ADETLİ*/ THEN (1000 / P.WEIGHT_AMT) * cp.SALEPRICE_AMT END UNITPRICE_AMT,    
    
	   CASE P.SUPERGROUP2     
	   WHEN 1 /*DÖKME*/THEN U.UNIT_NM    
	   WHEN 2 /*ADETLİ*/ THEN (CASE WHEN P.WEIGHTUNIT IN (1, 4) THEN 'Kg' WHEN P.WEIGHTUNIT IN (3, 5) THEN 'Lt' END) END WEIGHTUNIT_NM,   
	  
	  CP.CURRENTPRICEID,
	  CP.PACKAGE
        
   FROM PRD_PRODUCT P (NOLOCK)  
   LEFT JOIN PRD_PRODUCT P2 (NOLOCK) ON P.PARENT = P2.PRODUCTID  
   JOIN (SELECT B1.*, ROW_NUMBER() OVER (PARTITION BY PRODUCT ORDER BY BARCODEID DESC) ROWNO 
		   FROM PRD_BARCODE B1
		  WHERE BARCODETYPE = 1
            AND DELETED_FL = 'N') BC ON COALESCE(P2.PRODUCTID, P.PRODUCTID) = BC.PRODUCT AND ROWNO = 1 
   JOIN PRC_CURRENTPRICE CP (NOLOCK) ON COALESCE(P2.CODE_NM, P.CODE_NM) = CP.PRODUCTCODE_NM  AND CP.BARCODE_TXT = BC.BARCODE_TXT
   JOIN #ACTIVEPACKAGEPRICES AP ON COALESCE(P2.CODE_NM, P.CODE_NM) = AP.CODE_NM    
   LEFT JOIN PRD_COUNTRY C (NOLOCK) ON P.COUNTRY = C.COUNTRYID     
   LEFT JOIN PRD_WARNING W (NOLOCK) ON P.WARNING = W.WARNINGID     
   LEFT JOIN PRD_STORAGECONDITION SC (NOLOCK) ON P.STORAGECONDITION = SC.STORAGECONDITIONID     
   LEFT JOIN PRD_UNIT U ON P.UNIT = U.UNITID    
   LEFT JOIN PRD_UNIT UU ON P.WEIGHTUNIT = UU.UNITID    
  WHERE CP.STORE = @StoreID     
    AND GROUP_CD = 1     
    AND P.DELETED_FL = 'N'    
    AND P.SUPERGROUP3 NOT IN (1, 3)    
  ORDER BY    
      PRICECHANGE_DT DESC,    
      PRODUCTCODE_NM;    
END;