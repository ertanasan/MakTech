﻿CREATE PROCEDURE [dbo].[STR_LST_STOREFILTERWHINC_SP]
AS
BEGIN
	SELECT -1 AS STOREID, '*TÜM MAĞAZALAR*' AS STORE_NM
	 UNION ALL
	SELECT STOREID, STORE_NM
	  FROM dbo.STR_GETUSERSTORES_FN()
	 WHERE ACTIVE_FL = 'Y'   AND DELETED_FL = 'N'
	 UNION ALL
	SELECT 999 AS STOREID, 'MERKEZ DEPO' AS STORE_NM
	 ORDER BY STORE_NM
END