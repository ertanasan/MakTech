-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_SEL_FINDNOTIFICATION_SP
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
    END
    /*Section="Query"*/
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
           N.FOLDER
      FROM ANN_NOTIFICATION N (NOLOCK)
     WHERE N.NOTIFICATIONID = @NotificationId
       AND (@Organization IS NULL OR N.ORGANIZATION = @Organization);

/*Section="End"*/
END;
