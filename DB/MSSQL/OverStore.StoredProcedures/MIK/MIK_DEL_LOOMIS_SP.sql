﻿CREATE PROCEDURE MIK_DEL_LOOMIS_SP @TransferDate DATE AS
BEGIN

  IF OBJECT_ID('tempdb.dbo.#DELLIST', 'U') IS NOT NULL  DROP TABLE #DELLIST;
  
  SELECT DISTINCT cast(replace(PT.MIKROTRANCODE_TXT,'MML - ','') as int) REFNO
    INTO #DELLIST
    FROM ACC_LOOMIS PT 
   WHERE PT.SALE_DT = @TransferDate

  DELETE T
    FROM MIK_CURRENTTRANSACTION20_SYN T
	JOIN #DELLIST PT ON T.cha_evrakno_seri = 'MML' AND T.cha_evrakno_sira = PT.REFNO

  DELETE A
    FROM MIK_ACCOUNTING20_SYN A
	JOIN #DELLIST PT ON A.fis_tic_evrak_seri = 'MML' AND A.fis_tic_evrak_sira = PT.REFNO

  DELETE AD
    FROM MIK_ACCOUNTINGDETAIL20_SYN AD
	JOIN #DELLIST PT ON AD.mfd_evrak_seri = 'MML' AND AD.mfd_evrak_sira = PT.REFNO

  UPDATE ACC_LOOMIS SET MIKROSTATUS_CD = 0, MIKROTRANCODE_TXT = NULL, MIKRO_TM = NULL WHERE SALE_DT = @TransferDate

END