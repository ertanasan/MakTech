﻿CREATE PROCEDURE MIK_DEL_POSTRANSFER_SP @TransferDate DATE AS
BEGIN

  IF OBJECT_ID('tempdb.dbo.#DELLIST', 'U') IS NOT NULL  DROP TABLE #DELLIST;
  
  SELECT DISTINCT cast(replace(PT.MIKROTRANCODE_TXT,'MPOS - ','') as int) REFNO
    INTO #DELLIST
    FROM ACC_BANKPOSTRAN PT 
   WHERE PT.BLOCKED_DT = @TransferDate

  DELETE T
    FROM MIK_CURRENTTRANSACTION20_SYN T
	JOIN #DELLIST PT ON T.cha_evrakno_seri = 'MPOS' AND T.cha_evrakno_sira = PT.REFNO

  DELETE A
    FROM MIK_ACCOUNTING20_SYN A
	JOIN #DELLIST PT ON A.fis_tic_evrak_seri = 'MPOS' AND A.fis_tic_evrak_sira = PT.REFNO

  DELETE AD
    FROM MIK_ACCOUNTINGDETAIL20_SYN AD
	JOIN #DELLIST PT ON AD.mfd_evrak_seri = 'MPOS' AND AD.mfd_evrak_sira = PT.REFNO

  UPDATE ACC_BANKPOSTRAN SET MIKROSTATUS_CD = 0, MIKROTRANCODE_TXT = NULL, MIKRO_TM = NULL WHERE BLOCKED_DT = @TransferDate

END