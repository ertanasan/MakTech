﻿CREATE PROCEDURE STR_LST_REGIONMANAGERS_SP AS
BEGIN
    SELECT R.REGIONMANAGERSID,
           R.MANAGER_NM,
           R.TELNO_TXT,
           R.EMAIL_TXT,
		   R.USERID,
		   R.EXPENSEACCCODE_TXT,
		   R.MIKROPROJECTCODE_TXT,
           U.ACTIVE_FL USERACTIVE_FL,
           B.BRANCH_NM REGION_NM
      FROM STR_REGIONMANAGERS R (NOLOCK)
      LEFT JOIN SEC_USER U ON R.USERID = U.USERID
      LEFT JOIN ORG_BRANCH B ON U.BRANCH = B.BRANCHID
     ORDER BY MANAGER_NM;
END;