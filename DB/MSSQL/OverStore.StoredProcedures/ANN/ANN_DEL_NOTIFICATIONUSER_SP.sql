-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_DEL_NOTIFICATIONUSER_SP
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

    /*Section="Delete"*/
    SET NOCOUNT OFF;
    -- Perform deletion
    DELETE ANN_NOTIFICATIONUSER
      FROM ANN_NOTIFICATIONUSER (NOLOCK)
      JOIN ANN_NOTIFICATION NOTIFICATION (NOLOCK) ON ANN_NOTIFICATIONUSER.NOTIFICATION = NOTIFICATION.NOTIFICATIONID AND (@Organization IS NULL OR NOTIFICATION.ORGANIZATION = @Organization)
      JOIN SEC_USER [USER] (NOLOCK) ON ANN_NOTIFICATIONUSER.[USER] = [USER].USERID AND (@Organization IS NULL OR [USER].ORGANIZATION = @Organization)
     WHERE ANN_NOTIFICATIONUSER.NOTIFICATION = @Notification
       AND ANN_NOTIFICATIONUSER.[USER] = @User;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
END;
