﻿CREATE PROCEDURE WHS_LST_STOREORDERID_SP AS
BEGIN
	SELECT STOREORDERID, ORDERCODE_NM
	  FROM WHS_STOREORDER
	 WHERE STATUS >= 2
	   AND DELETED_FL = 'N'
	 ORDER BY CREATE_DT DESC
END