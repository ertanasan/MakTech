﻿CREATE PROCEDURE RCL_LST_OPENEXPENSES_SP @StoreId INT, @Date DATE AS
BEGIN
  SELECT DISTINCT E.*
    FROM RCL_EXPENSE E
	JOIN SEC_USER U ON E.CREATEUSER = U.USERID
	JOIN STR_STORE ST ON U.BRANCH = ST.BRANCH
   WHERE STORE = @StoreId 
     AND CAST(E.CREATE_DT AS DATE) = @Date
	 AND ST.DELETED_FL = 'N'
	 -- AND (OPEN_FL = 'Y' OR PAYOFF_DT > @Date)
END
