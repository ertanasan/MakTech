﻿CREATE PROCEDURE RCL_LST_EXPENSETRANSFER_SP @RegionManagerId INT AS
BEGIN

	DECLARE @StartDate DATE = CONVERT(DATE, '20190715', 112);
	WITH STOREREGIONS AS (
		SELECT STOREID, STORE_NM, RU.USERID, RM.EXPENSEACCCODE_TXT RMACCOUNT_TXT 
		  FROM STR_STORE ST 
		  JOIN ORG_BRANCH B ON ST.BRANCH = B.BRANCHID
		  JOIN SEC_USER RU ON RU.BRANCH = B.PARENT
		  JOIN STR_REGIONMANAGERS RM ON RU.USERID = RM.USERID)
	SELECT E.*, ET.EXPENSETYPE_NM, ET.ACCOUNTCODE_TXT, COALESCE(SRM.EXPENSEACCCODE_TXT, RMACCOUNT_TXT) RMACCOUNT_TXT, 
		   COALESCE(SRM.MANAGER_NM, STORE_NM) STORE_NM, U.USERFULL_NM CREATEUSER_NM, U2.USERFULL_NM UPDATEUSER_NM
	  FROM RCL_EXPENSE E 
	  JOIN RCL_EXPENSETYPE ET ON E.EXPENSETYPE = ET.EXPENSETYPEID
	  JOIN SEC_USER U ON E.CREATEUSER = U.USERID
	  LEFT JOIN SEC_USER U2 ON E.UPDATEUSER = U2.USERID
	  LEFT JOIN STOREREGIONS SR ON E.STORE = SR.STOREID
	  LEFT JOIN STR_REGIONMANAGERS SRM ON E.REGIONMANAGER = SRM.REGIONMANAGERSID
	 WHERE E.OPEN_FL = 'N'
	   AND E.DELETED_FL = 'N'
	   AND COALESCE(SRM.USERID, SR.USERID) = @RegionManagerId
	   AND PAYOFF_DT >= @StartDate 
	   AND E.STATUS_CD IS NULL 

END