﻿CREATE PROCEDURE [dbo].[STR_LST_OUTDATEDCODESTORE_SP]
AS
BEGIN
	IF OBJECT_ID('tempdb.dbo.#STORES', 'U') IS NOT NULL DROP TABLE #STORES;     
	SELECT * INTO #STORES FROM dbo.STR_GETUSERSTORES_FN();

	WITH CURRENTHASH AS (
	SELECT TOP 1 CURRENTHASH_TXT, COUNT(*) ADET
	  FROM STR_DEPLOYSTATUS_VW 
	 GROUP BY CURRENTHASH_TXT
	 ORDER BY 2 DESC ) 
	SELECT A.*, B.CURRENTHASH_TXT ORJHASH
	  FROM STR_DEPLOYSTATUS_VW A
	  JOIN CURRENTHASH B ON ISNULL(A.CURRENTHASH_TXT,'') != B.CURRENTHASH_TXT
	  JOIN STR_TERMINAL T ON A.TERMINALID = T.TERMINAL_NO
	  JOIN #STORES  ST ON T.STORE = ST.STOREID
	 ORDER BY HASH_TM
END;