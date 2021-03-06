﻿CREATE PROCEDURE [dbo].[HDK_LST_TASKDASHBOARD_SP] WITH RECOMPILE AS
BEGIN
	
	DECLARE @CurrentUser INT = dbo.SYS_GETCURRENTUSER_FN();

	-- overtech_gm'in bilgi sistemleri grubuna girmeden it müdürü gibi davranması için 
	IF @CurrentUser = 233 SET @CurrentUser = 382 -- murat.altintas

	DECLARE @AdminFlag VARCHAR(1) = 'N', @SeeAllFlag VARCHAR(1) = 'N' 
	SELECT @AdminFlag = ISNULL(MAX(ADMIN_FL),'N') 
		 , @SeeAllFlag = ISNULL(MAX(SEEALL_FL),'N') 
	  FROM HDK_ASSIGNUSER 
	 WHERE RESPONSIBLEUSER = @CurrentUser 

	IF OBJECT_ID('tempdb..#RESULT') IS NOT NULL DROP TABLE #RESULT
	IF OBJECT_ID('tempdb..#RESULT2') IS NOT NULL DROP TABLE #RESULT2;
	
	WITH CLOSURES AS (
	SELECT PROCESSINSTANCE, CHOICE_TXT, PERFORMER, USERFULL_NM, FINISH_TM, CLOSEBYGROUP_FL
	  FROM (
	SELECT PROCESSINSTANCE, CHOICE_TXT, PERFORMER, U.USERFULL_NM, FINISH_TM, 
		   CASE WHEN ISNULL(AU.GROUP_NM, '1') = ISNULL(AUP.GROUP_NM, '2') THEN 'Y' ELSE 'N' END CLOSEBYGROUP_FL, 
		   ROW_NUMBER() OVER (PARTITION BY PROCESSINSTANCE ORDER BY FINISH_TM DESC) ROWNO
	  FROM BPA_ACTION A
	  JOIN BPM_PROCESSINSTANCE PIN ON PIN.PROCESSINSTANCEID = A.PROCESSINSTANCE
	  JOIN SEC_USER U ON A.PERFORMER = U.USERID
	  LEFT JOIN HDK_ASSIGNUSER AU ON AU.RESPONSIBLEUSER = @CurrentUser
	  LEFT JOIN HDK_ASSIGNUSER AUP ON AUP.RESPONSIBLEUSER = PERFORMER
	 WHERE PIN.PROCESSDEFINITION = 2018
	   AND CHOICE_TXT = 'Çözüldü') A
	 WHERE A.ROWNO = 1)
	SELECT R.REQUESTID, RD.REQUESTDEFID, RD.REQUESTDEF_NM, R.REQUEST_DSC, RQ.STATUS_NM, ST.STORE_NM, 
		   R.RESPONSIBLEUSER, RU.USERFULL_NM RESPONSIBLEUSER_NM,
		   CASE WHEN R.STATUS_CD NOT IN (11, 99) THEN 'Y' ELSE 'N' END OPEN_FL, R.PROCESSINSTANCE_LNO,
		   RD.REQUESTGROUP, BPIS.STATUS_CD PROCESSINSTANCESTATUS_CD, BPIS.STATUS_NM PROCESSINSTANCESTATUS_NM, 
		   AI.ACTIVITY_NM + '-' + RQ.STATUS_NM ACTIVITY_NM,
		   R.CREATE_DT, R.UPDATE_DT, DATEDIFF(MINUTE, R.CREATE_DT, GETDATE()) MINUTEPASSED,
		   DATEDIFF(MINUTE, R.UPDATE_DT, GETDATE()) MINUTEPASSEDLASTUPDATE, 
		   CASE WHEN BPIS.STATUS_CD = 4 THEN C.PERFORMER WHEN R.STATUS_CD = 99 THEN R.UPDATEUSER END PERFORMER, 
		   CASE WHEN BPIS.STATUS_CD = 4 THEN C.USERFULL_NM WHEN R.STATUS_CD = 99 THEN U2.USERFULL_NM END PERFORMER_NM, 
		   CASE WHEN BPIS.STATUS_CD = 4 THEN C.FINISH_TM WHEN R.STATUS_CD = 99 THEN R.UPDATE_DT END FINISH_TM, 
		   DATEDIFF(MINUTE, R.CREATE_DT, CASE WHEN BPIS.STATUS_CD = 4 THEN C.FINISH_TM WHEN R.STATUS_CD = 99 THEN R.UPDATE_DT END) CLOSEDURATION,
		   CLOSEBYGROUP_FL, @AdminFlag ADMIN_FL,
		   CASE WHEN R.CREATE_DT < CAST(GETDATE() - 30 AS DATE) THEN '> 1 AY'
				WHEN R.CREATE_DT < CAST(GETDATE() - 7 AS DATE) THEN 'SON AY'
				WHEN R.CREATE_DT < CAST(GETDATE() - 1 AS DATE) THEN 'SON HAFTA'
				WHEN R.CREATE_DT < CAST(GETDATE() AS DATE) THEN 'DÜN'
				ELSE 'BUGÜN'
		   END DAYGROUP
	  INTO #RESULT
	  FROM HDK_REQUEST R (NOLOCK)
	  JOIN HDK_REQUESTDEF RD (NOLOCK) ON R.REQUESTDEFINITION = RD.REQUESTDEFID
	  JOIN STR_STORE ST (NOLOCK) ON R.STORE = ST.STOREID
	  LEFT JOIN HDK_REQUESTSTATUS RQ (NOLOCK) ON R.STATUS_CD = RQ.REQUESTSTATUSID
	  LEFT JOIN BPM_PROCESSINSTANCE PIN (NOLOCK) ON R.PROCESSINSTANCE_LNO = PIN.PROCESSINSTANCEID
	  LEFT JOIN BPA_ACTION A (NOLOCK) ON R.PROCESSINSTANCE_LNO = A.PROCESSINSTANCE AND A.STATUS_CD = 1
	  LEFT JOIN BPM_ACTIVITYINSTANCE AI (NOLOCK) ON A.ACTIVITYINSTANCE = AI.ACTIVITYINSTANCEID
	  LEFT JOIN [dbo].[BPM_PROCESSINSTANCESTATUS_FN]() BPIS ON PIN.STATUS_CD = BPIS.STATUS_CD
	  LEFT JOIN CLOSURES C ON R.PROCESSINSTANCE_LNO = C.PROCESSINSTANCE
	  LEFT JOIN SEC_USER U2 ON R.UPDATEUSER = U2.USERID
	  LEFT JOIN SEC_USER RU ON R.RESPONSIBLEUSER = RU.USERID
	 WHERE R.DELETED_FL = 'N'
	   AND RD.REQUESTGROUP = 1
	   -- AND (BPIS.STATUS_CD NOT IN (2,3) OR ACTIVITY_NM IS NOT NULL) -- geçici olarak kondu, hatayı gizlemek için

	SELECT R.*, CASE WHEN AV.PROCESSINSTANCE IS NOT NULL THEN 'Y' ELSE 'N' END USERTASK_FL
	  INTO #RESULT2
	  FROM #RESULT R
	  LEFT JOIN BPM_ACTION_VW AV (NOLOCK) ON R.PROCESSINSTANCE_LNO = AV.PROCESSINSTANCE AND AV.USERID = @CurrentUser

	SELECT ACTIVITY_NM, REQUESTDEF_NM, DAYGROUP
		 , RESPONSIBLEUSER, RESPONSIBLEUSER_NM
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) THEN 1 ELSE 0 END) OPENTASK_CNT
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) AND USERTASK_FL = 'Y' THEN 1 ELSE 0 END) OPENGROUPTASK_CNT
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) AND USERTASK_FL = 'Y' AND RESPONSIBLEUSER = @CurrentUser THEN 1 ELSE 0 END) OPENUSERTASK_CNT
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) THEN MINUTEPASSED ELSE 0 END) OPENTASKDURATION
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) AND USERTASK_FL = 'Y' THEN MINUTEPASSED ELSE 0 END) OPENGROUPTASKDURATION
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) AND USERTASK_FL = 'Y' AND RESPONSIBLEUSER = @CurrentUser THEN MINUTEPASSED ELSE 0 END) OPENUSERTASKDURATION
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) THEN MINUTEPASSEDLASTUPDATE ELSE 0 END) OPENTASKDURATIONLASTUPDATE
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) AND USERTASK_FL = 'Y' THEN MINUTEPASSEDLASTUPDATE ELSE 0 END) OPENGROUPTASKDURATIONLASTUPDATE
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) AND USERTASK_FL = 'Y' AND RESPONSIBLEUSER = @CurrentUser THEN MINUTEPASSEDLASTUPDATE ELSE 0 END) OPENUSERTASKDURATIONLASTUPDATE
	  FROM #RESULT2
	 WHERE (@SeeAllFlag = 'Y' OR USERTASK_FL = 'Y')
	 GROUP BY ACTIVITY_NM, REQUESTDEF_NM, RESPONSIBLEUSER, RESPONSIBLEUSER_NM, DAYGROUP
	HAVING SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) THEN 1 ELSE 0 END)  > 0; 
 
	SELECT REQUESTDEF_NM, PERFORMER_NM
		 , CASE WHEN FINISH_TM < CAST(GETDATE() - 30 AS DATE) THEN '> 1 AY'
				WHEN FINISH_TM < CAST(GETDATE() - 7 AS DATE) THEN 'SON AY'
				WHEN FINISH_TM < CAST(GETDATE() - 1 AS DATE) THEN 'SON HAFTA'
				WHEN FINISH_TM < CAST(GETDATE() AS DATE) THEN 'DÜN'
				ELSE 'BUGÜN'
		   END DAYGROUP
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD = 4 THEN 1 ELSE 0 END) CLOSETASK_CNT
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD = 4 AND CLOSEBYGROUP_FL = 'Y' THEN 1 ELSE 0 END) CLOSEGROUPTASK_CNT
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD = 4 AND CLOSEBYGROUP_FL = 'Y' AND PERFORMER = @CurrentUser THEN 1 ELSE 0 END) CLOSEUSERTASK_CNT
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD = 4 THEN CLOSEDURATION ELSE 0 END) CLOSEDURATION 
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD = 4 AND CLOSEBYGROUP_FL = 'Y' THEN CLOSEDURATION ELSE 0 END) CLOSEGROUPDURATION
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD = 4 AND CLOSEBYGROUP_FL = 'Y' AND PERFORMER = @CurrentUser THEN CLOSEDURATION ELSE 0 END) CLOSEUSERDURATION
		 , SUM(CASE WHEN PROCESSINSTANCESTATUS_CD = 6 THEN 1 ELSE 0 END) REFUSETASK_CNT
	  FROM #RESULT2
	 WHERE (@SeeAllFlag = 'Y' OR USERTASK_FL = 'Y')
	 GROUP BY REQUESTDEF_NM, PERFORMER_NM,
		   CASE WHEN FINISH_TM < CAST(GETDATE() - 30 AS DATE) THEN '> 1 AY'
				WHEN FINISH_TM < CAST(GETDATE() - 7 AS DATE) THEN 'SON AY'
				WHEN FINISH_TM < CAST(GETDATE() - 1 AS DATE) THEN 'SON HAFTA'
				WHEN FINISH_TM < CAST(GETDATE() AS DATE) THEN 'DÜN'
				ELSE 'BUGÜN'
		   END 
	HAVING SUM(CASE WHEN PROCESSINSTANCESTATUS_CD IN (2,3) THEN 1 ELSE 0 END) = 0 

	SELECT * FROM #RESULT2 WHERE PROCESSINSTANCESTATUS_CD IN (2,3) AND (@SeeAllFlag = 'Y' OR USERTASK_FL = 'Y')

	SELECT U.USERID, U.USERFULL_NM
	  FROM HDK_ASSIGNUSER U1
	  JOIN HDK_ASSIGNUSER U2 ON U1.GROUP_NM = U2.GROUP_NM
	  JOIN SEC_USER U ON U2.RESPONSIBLEUSER = U.USERID
	 WHERE U1.RESPONSIBLEUSER = @CurrentUser 
	   AND U1.ADMIN_FL = 'Y'
END