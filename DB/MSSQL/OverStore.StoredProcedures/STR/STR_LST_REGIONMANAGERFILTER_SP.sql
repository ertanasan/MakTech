﻿CREATE PROCEDURE STR_LST_REGIONMANAGERFILTER_SP AS
BEGIN
	SELECT -1 REGIONMANAGERID, 'TÜM YÖNETİCİLER' MANAGER_NM
	 UNION ALL
	SELECT REGIONMANAGERSID, MANAGER_NM FROM STR_REGIONMANAGERS WHERE USERID IS NOT NULL 
END