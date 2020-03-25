﻿CREATE PROCEDURE [dbo].[STR_LST_USERCASHREGISTER_SP] AS
BEGIN

	IF OBJECT_ID('tempdb.dbo.#STORES', 'U') IS NOT NULL DROP TABLE #STORES;
	SELECT * INTO #STORES FROM dbo.STR_GETUSERSTORES_FN();

	SELECT CR.*
	  FROM STR_CASHREGISTER CR
	  JOIN #STORES ST ON CR.STORE = ST.STOREID
	 WHERE CR.DELETED_FL = 'N'
END