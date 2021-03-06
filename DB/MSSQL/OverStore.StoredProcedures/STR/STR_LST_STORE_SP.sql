﻿CREATE PROCEDURE STR_LST_STORE_SP AS  
BEGIN  
    DECLARE @Branch INT;
	SELECT @Branch = dbo.SYS_GETCURRENTBRANCH_FN();

	DECLARE @BranchType VARCHAR(100);
	SELECT @BranchType = BT.BRANCHTYPE_NM
      FROM ORG_BRANCH B 
      JOIN ORG_BRANCHTYPE BT ON B.BRANCHTYPE = BT.BRANCHTYPEID
     WHERE B.BRANCHID = dbo.SYS_GETCURRENTBRANCH_FN();

    SELECT S.STOREID,  
           S.ORGANIZATION,  
           S.DELETED_FL,  
           S.CREATE_DT,  
           S.UPDATE_DT,  
           S.CREATEUSER,  
           S.UPDATEUSER,  
           S.STORE_NM,  
           S.BRANCH,  
           S.IPADDRESS_TXT,  
           S.ADVANCE_AMT,  
           S.OPENING_DT,  
           S.CLOSING_DT,  
           S.ACTIVE_FL,  
           S.PRODUCTION_FL,  
           S.CITY,  
		   C.CITY_NM,
           S.TOWN,  
		   T.TOWN_NM,
           S.ADDRESS_TXT,  
           S.REGIONMANAGER,  
		   RM.MANAGER_NM,
           S.INCONSTRUCTION_FL,
		   LASTSIP.VALUE_TXT LASTORDERENTRY_TXT,
		   @BranchType USERBRANCHTYPE_NM
      FROM STR_STORE S (NOLOCK)
	  LEFT JOIN STR_CITY C (NOLOCK) ON S.CITY = C.CITYID
	  LEFT JOIN STR_TOWN T (NOLOCK) ON S.TOWN = T.TOWNID
	  LEFT JOIN STR_REGIONMANAGERS RM (NOLOCK) ON S.REGIONMANAGER = RM.REGIONMANAGERSID
	  LEFT JOIN (SELECT STORE, VALUE_TXT FROM STR_PROPERTY WHERE PROPERTYTYPE = 1) LASTSIP ON S.STOREID = LASTSIP.STORE
     WHERE S.DELETED_FL = 'N'  
     ORDER BY STORE_NM;  

END;  