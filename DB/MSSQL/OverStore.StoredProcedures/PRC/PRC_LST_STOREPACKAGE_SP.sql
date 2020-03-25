CREATE PROCEDURE PRC_LST_STOREPACKAGE_SP  @Package INT = NULL  AS        
BEGIN        
  SELECT S.STOREPACKAGEID,        
         S.ORGANIZATION,        
         S.DELETED_FL,        
         S.CREATE_DT,        
         S.UPDATE_DT,        
         S.CREATEUSER,        
         S.UPDATEUSER,        
         S.STORE,        
         S.PACKAGE,        
		 P.PACKAGE_NM,      
         S.PRIORITY_NO,        
         S.ISCURRENT_FL,        
         S.CURRENTVERSION,        
         S.START_TM,        
         S.END_TM,    
		 ST.STORE_NM    
    FROM PRC_STOREPACKAGE S (NOLOCK)       
    JOIN STR_STORE ST (NOLOCK) ON S.STORE = ST.STOREID    
    LEFT JOIN PRC_PACKAGE P (NOLOCK) ON S.PACKAGE = P.PACKAGEID      
   WHERE S.DELETED_FL = 'N'        
     AND (@Package IS NULL OR @Package = P.PACKAGEID)  
   ORDER BY STOREPACKAGEID;        
END; 