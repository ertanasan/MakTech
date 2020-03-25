﻿CREATE PROCEDURE PRC_UPD_ACTIVATEPACKAGEVERSION_SP AS
BEGIN

	IF OBJECT_ID('tempdb..#UPDATE') IS NOT NULL DROP TABLE #UPDATE

	SELECT *
	  INTO #UPDATE
	  FROM (
	SELECT *, ROW_NUMBER() OVER (PARTITION BY PACKAGE ORDER BY PACKAGEVERSIONID DESC) ROWNO
	  FROM PRC_PACKAGEVERSION) A
	 WHERE ACTIVATION_TM > CREATE_DT
	   AND ROWNO = 1
	   AND ACTIVE_FL = 'N'
	   AND ACTIVATION_TM < GETDATE()

	UPDATE PV
	   SET ACTIVE_FL = 'N'
	  FROM PRC_PACKAGEVERSION PV
	  JOIN #UPDATE U ON PV.PACKAGE = U.PACKAGE
	 WHERE PV.ACTIVE_FL = 'Y'

	UPDATE PV
	   SET ACTIVE_FL = 'Y'
	  FROM PRC_PACKAGEVERSION PV
	  JOIN #UPDATE U ON PV.PACKAGE = U.PACKAGE AND PV.PACKAGEVERSIONID = U.PACKAGEVERSIONID

END
