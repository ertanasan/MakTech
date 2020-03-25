-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_NOTIFICATIONUSER_SP
    @Notification BIGINT,
    @User INT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Query"*/
    -- Select
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
		   CASE WHEN PN.STATUS_CD = 4 THEN 'Y' ELSE 'N' END READ_FL
      FROM ANN_NOTIFICATIONUSER N (NOLOCK)
      JOIN ANN_NOTIFICATION NOTIFICATION (NOLOCK) ON N.NOTIFICATION = NOTIFICATION.NOTIFICATIONID AND (@Organization IS NULL OR NOTIFICATION.ORGANIZATION = @Organization)
      JOIN SEC_USER [USER] (NOLOCK) ON N.[USER] = [USER].USERID AND (@Organization IS NULL OR [USER].ORGANIZATION = @Organization)
	  LEFT JOIN BPM_PROCESSINSTANCE PN (NOLOCK) ON N.PROCESSINSTANCE_LNO = PN.PROCESSINSTANCEID
     WHERE N.NOTIFICATION = @Notification
       AND N.[USER] = @User;

/*Section="End"*/
END;
