-- Created by OverGenerator  
/*Section="Main"*/  
CREATE PROCEDURE [dbo].[PRC_LST_PRODUCT_SP]  
AS  
BEGIN  
    /*Section="Organization"*/  
    -- Get the caller organization from session context  
    DECLARE @Organization INT;  
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();  
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1  
    BEGIN  
      -- Current organization is system. This is a batch or system process.  
      SET @Organization = null;  
    END  
  
    IF OBJECT_ID('tempdb..#PLU') IS NOT NULL DROP TABLE #PLU        
        
    SELECT PRODUCT    
      , MAX(CASE WHEN ORDERNO = 1 THEN BARCODE ELSE '00000000000000000000' END) PLU1    
      , MAX(CASE WHEN ORDERNO = 2 THEN BARCODE ELSE '00000000000000000000' END) PLU2    
      , MAX(CASE WHEN ORDERNO = 3 THEN BARCODE ELSE '00000000000000000000' END) PLU3    
      INTO #PLU    
      FROM (    
    SELECT B.PRODUCT, B.BARCODE_TXT BARCODE, ROW_NUMBER() OVER (PARTITION BY PRODUCT ORDER BY B.BARCODEID) ORDERNO    
      FROM PRD_BARCODE B) A    
     GROUP BY PRODUCT    
  
    /*Section="Query"*/  
    -- Select all  
    SELECT P.PRODUCTID,    
           P.ORGANIZATION,    
           P.DELETED_FL,    
           P.CREATE_DT,    
           P.UPDATE_DT,    
           P.CREATEUSER,    
           P.UPDATEUSER,    
           P.PRICE_AMT,    
           P.PRODUCT,    
           P.PACKAGE,    
           P.TOPPRICE_AMT,    
           P.PRINTTOPPRICE_FL,    
		   P.PACKAGEVERSION,  
		   PR.NAME_NM PRODUCT_NM,    
		   PR.CODE_NM PRODUCTCODE_NM,    
		   PR.SALEVAT_RT,     
		   PR.UNIT,    
		   PLU.PLU1, PLU.PLU2, PLU.PLU3,    
		   PF.CATEGORY_NM, PT.SUBGROUP_NM    
      FROM PRC_PRODUCT P (NOLOCK)    
      JOIN PRD_PRODUCT PR (NOLOCK) ON P.PRODUCT=PR.PRODUCTID    
      JOIN #PLU PLU ON PR.PRODUCTID = PLU.PRODUCT    
      LEFT JOIN PRD_SUBGROUP PT ON PR.SUBGROUP = PT.SUBGROUPID    
      LEFT JOIN PRD_CATEGORY PF ON PT.CATEGORY = PF.CATEGORYID    
     WHERE (@Organization IS NULL OR P.ORGANIZATION = @Organization)    
       AND P.DELETED_FL = 'N'    
     ORDER BY P.UPDATE_DT DESC;    
  
/*Section="End"*/  
END;  