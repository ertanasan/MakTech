﻿CREATE PROCEDURE [dbo].[RCL_LST_LASTUNCOMPLETEID_SP] @StoreId INT AS
BEGIN

  SELECT STORERECID
    FROM (
  SELECT STORERECID, RECONCILIATION_DT, COMPLETE_FL, ROW_NUMBER() OVER (ORDER BY RECONCILIATION_DT) ROWNO
    FROM RCL_STORE
   WHERE STORE = @StoreId  
	 AND COMPLETE_FL = 'N'
     AND DELETED_FL = 'N') A
   WHERE ROWNO = 1
     
	 
END
