﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_SEL_CURRENTPRICE_SP
    @CurrentPricesId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CURRENTPRICEID,
           C.STORE,
           C.PRODUCTCODE_NM,
           C.PRODUCT_NM,
           C.BARCODE_TXT,
           C.PRODUCTUNIT_NO,
           C.SALEPRICE_AMT,
           C.SALEVAT_RT,
           C.VERSION_TM,
           C.GROUP_CD,
		   ST.STORE_NM,  
		   U.UNIT_NM,  
		   CASE C.GROUP_CD WHEN 1 THEN 'KASA' WHEN 2 THEN 'TERAZİ' ELSE 'DİĞER'  END GROUPCODE_NM,
		   C.PACKAGE,
		   PP.PACKAGE_NM
      FROM PRC_CURRENTPRICE C (NOLOCK)
	  JOIN STR_STORE_VW ST (NOLOCK) ON C.STORE = ST.STOREID    
	  LEFT JOIN PRD_UNIT U (NOLOCK) ON C.PRODUCTUNIT_NO = U.UNITID  
	  LEFT JOIN PRC_PACKAGE PP ON C.PACKAGE = PP.PACKAGEID
     WHERE C.CURRENTPRICEID = @CurrentPricesId;

    /*Section="End"*/
END;
