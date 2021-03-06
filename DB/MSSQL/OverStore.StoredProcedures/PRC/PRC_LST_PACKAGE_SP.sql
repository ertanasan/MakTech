﻿CREATE PROCEDURE PRC_LST_PACKAGE_SP AS    
BEGIN    

  WITH STORECOUNT AS (  
    SELECT PACKAGE   
		 , COUNT(STORE) [ALLSTORES_CN]  
		 , SUM(CASE WHEN GETDATE() BETWEEN START_TM AND END_TM THEN 1 ELSE 0 END) [ACTIVESTORES_CN]  
	  FROM PRC_STOREPACKAGE SP  
	  JOIN STR_STORE ST ON SP.STORE = ST.STOREID
	 WHERE SP.DELETED_FL = 'N'
	   AND ST.ACTIVE_FL = 'Y'
	 GROUP BY PACKAGE )  
  SELECT P.PACKAGEID,    
		 P.ORGANIZATION,    
		 P.DELETED_FL,    
		 P.CREATE_DT,    
		 P.UPDATE_DT,    
		 P.CREATEUSER,    
		 P.UPDATEUSER,    
		 P.PACKAGE_NM,    
		 P.TYPE,    
		 P.COMMENT_DSC, 
		 P.IMAGE,
		 SC.ALLSTORES_CN,  
		 SC.ACTIVESTORES_CN  
    FROM PRC_PACKAGE P (NOLOCK)    
    LEFT JOIN STORECOUNT SC ON P.PACKAGEID = SC.PACKAGE   
   WHERE P.DELETED_FL = 'N'    
 ORDER BY PACKAGEID;    
    
END; 
