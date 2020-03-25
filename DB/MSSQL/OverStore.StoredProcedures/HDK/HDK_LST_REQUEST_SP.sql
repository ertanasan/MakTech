﻿CREATE PROCEDURE HDK_LST_REQUEST_SP 
    @OpenFlag VARCHAR(1) = 'Y',
    @StartDate DATE = NULL,
    @EndDate DATE = NULL AS
BEGIN
    
    DECLARE @CurrentUser INT = dbo.SYS_GETCURRENTUSER_FN();

    SET @StartDate = ISNULL(@StartDate, CONVERT(DATE, '20190101', 112));
    SET @EndDate = ISNULL(@EndDate, CONVERT(DATE, '20501231', 112));

    IF OBJECT_ID('tempdb..#stores') IS NOT NULL DROP TABLE #stores
    SELECT * into #stores from dbo.STR_GETUSERSTORES_FN();

    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END
    SELECT R.REQUESTID,
           R.EVENT,
           R.ORGANIZATION,
           R.DELETED_FL,
           R.CREATE_DT,
           R.UPDATE_DT,
           R.CREATEUSER,
           R.UPDATEUSER,
           R.CREATECHANNEL,
           R.CREATEBRANCH,
           R.CREATESCREEN,
           R.REQUESTDEFINITION,
           R.REQUEST_DSC,
           R.STATUS_CD,
           R.PROCESSINSTANCE_LNO,
           R.STORE,
           R.REDIRECTIONGROUP,
           RD.REQUESTGROUP,
           R.PHONENUMBER_TXT,
           ST.STORE_NM,
		   PIN.STATUS_CD PROCESSINSTANCESTATUS_CD,
		   AI.ACTIVITY_NM,
           R.RESPONSIBLEUSER,
           CASE WHEN AV.PROCESSINSTANCE IS NOT NULL THEN 'Y' ELSE 'N' END USERTASK_FL
      FROM HDK_REQUEST R (NOLOCK)
	  JOIN HDK_REQUESTDEF RD (NOLOCK) ON R.REQUESTDEFINITION = RD.REQUESTDEFID
      JOIN #stores ST (NOLOCK) ON R.STORE = ST.STOREID
	  LEFT JOIN BPM_PROCESSINSTANCE PIN (NOLOCK) ON R.PROCESSINSTANCE_LNO = PIN.PROCESSINSTANCEID
	  LEFT JOIN BPA_ACTION A (NOLOCK) ON R.PROCESSINSTANCE_LNO = A.PROCESSINSTANCE AND A.STATUS_CD = 1
	  LEFT JOIN BPM_ACTIVITYINSTANCE AI (NOLOCK) ON A.ACTIVITYINSTANCE = AI.ACTIVITYINSTANCEID
      LEFT JOIN BPM_ACTION_VW AV (NOLOCK) ON R.PROCESSINSTANCE_LNO = AV.PROCESSINSTANCE AND AV.USERID = @CurrentUser
     WHERE (@Organization IS NULL OR R.ORGANIZATION = @Organization)
       AND R.DELETED_FL = 'N'
       AND (@OpenFlag = 'N' OR R.STATUS_CD NOT IN (11, 99))
       AND CAST(R.CREATE_DT AS DATE) BETWEEN @StartDate AND @EndDate
     ORDER BY REQUESTDEFINITION;
END;
