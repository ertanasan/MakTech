-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_NOTIFICATION_SP
    @NotificationId BIGINT
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
    END;
    /*Section="Query"*/
	-- Calculate storeCount
	WITH UsersCount AS (
	SELECT N.NOTIFICATIONID, COUNT(NU.[USER]) USER_CNT
	     , SUM(CASE WHEN PN.STATUS_CD = 4 THEN 1 ELSE 0 END) READ_CNT
	  FROM ANN_NOTIFICATION N (NOLOCK)
	  LEFT JOIN ANN_NOTIFICATIONUSER NU (NOLOCK) ON N.NOTIFICATIONID = NU.[NOTIFICATION]
	  LEFT JOIN BPM_PROCESSINSTANCE PN (NOLOCK) ON NU.PROCESSINSTANCE_LNO = PN.PROCESSINSTANCEID 
	  WHERE N.NOTIFICATIONID = @NotificationId
	  GROUP BY N.NOTIFICATIONID)

    -- Select
    SELECT
           N.NOTIFICATIONID,
           N.EVENT,
           N.ORGANIZATION,
           N.DELETED_FL,
           N.CREATE_DT,
           N.UPDATE_DT,
           N.CREATEUSER,
           N.UPDATEUSER,
           N.CREATECHANNEL,
           N.CREATEBRANCH,
           N.CREATESCREEN,
           N.NOTIFICATION_TXT,
           N.NOTIFICATIONTYPE,
           N.NOTIFICATIONSTATUS,
		   UC.USER_CNT,
		   UC.READ_CNT,
           N.FOLDER
      FROM ANN_NOTIFICATION N (NOLOCK)
	  JOIN UsersCount UC ON N.NOTIFICATIONID = UC.NOTIFICATIONID
     WHERE N.NOTIFICATIONID = @NotificationId
       AND (@Organization IS NULL OR N.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
