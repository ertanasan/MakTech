﻿CREATE PROCEDURE ANN_LST_NOTIFICATIONUSER_SP @Notification BIGINT, @User INT AS
BEGIN	
	IF OBJECT_ID('tempdb.dbo.#USERS', 'U') IS NOT NULL DROP TABLE #USERS;

	SELECT U.USERID INTO #USERS
	  FROM dbo.STR_GETUSERSTORES_FN() A
	  JOIN SEC_USER U ON A.BRANCH = U.BRANCH

	DECLARE @bs INT = 0;
	SELECT @bs = COUNT(*) FROM STR_REGIONMANAGERS WHERE USERID = dbo.sys_getcurrentuser_fn();

    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END

    IF @Notification IS NULL AND @User IS NULL
    BEGIN
        DECLARE @ErrorMessage VARCHAR(250);
        SET @ErrorMessage='At least one parameter should not be null.';
        THROW 100002, @ErrorMessage, 1;
        RETURN;
    END

    SELECT
           N.NOTIFICATION,
           N.[USER],
           N.CREATE_DT,
           N.CREATEUSER,
           N.CREATECHANNEL,
           N.CREATEBRANCH,
           N.CREATESCREEN,
           N.PROCESSINSTANCE_LNO,
           NOTIFICATION.NOTIFICATIONID "NOTIFICATION.NOTIFICATIONID",
           [USER].USER_NM "USER.USER_NM",
		   [USER].USERFULL_NM "USER.USERFULL_NM",
		   CASE WHEN PN.STATUS_CD = 4 THEN 'Y' ELSE 'N' END READ_FL,
		   B.BRANCH_NM
      FROM ANN_NOTIFICATIONUSER N (NOLOCK)
      JOIN ANN_NOTIFICATION NOTIFICATION (NOLOCK) ON N.NOTIFICATION = NOTIFICATION.NOTIFICATIONID AND (@Organization IS NULL OR NOTIFICATION.ORGANIZATION = @Organization)
      JOIN SEC_USER [USER] (NOLOCK) ON N.[USER] = [USER].USERID AND (@Organization IS NULL OR [USER].ORGANIZATION = @Organization)
	  JOIN ORG_BRANCH (NOLOCK) B ON [USER].BRANCH = B.BRANCHID AND (@Organization IS NULL OR B.ORGANIZATION = @Organization)
	  LEFT JOIN BPM_PROCESSINSTANCE PN (NOLOCK) ON N.PROCESSINSTANCE_LNO = PN.PROCESSINSTANCEID
     WHERE (@Notification IS NULL OR N.NOTIFICATION = @Notification)
       AND (@User IS NULL OR N.[USER] = @User)
	   AND (@bs = 0 OR N.[USER] IN (SELECT USERID FROM #USERS));

END;
