-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_UPD_NOTIFICATION_SP
    @NotificationId     BIGINT,
    @Event              INT,
    @Organization       INT,
    @NotificationText   VARCHAR(MAX),
    @NotificationType   INT,
    @NotificationStatus INT,
    @Folder             BIGINT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ANN_NOTIFICATION
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           NOTIFICATION_TXT = @NotificationText,
           NOTIFICATIONTYPE = @NotificationType,
           NOTIFICATIONSTATUS = @NotificationStatus,
           FOLDER = @Folder
     WHERE NOTIFICATIONID = @NotificationId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
