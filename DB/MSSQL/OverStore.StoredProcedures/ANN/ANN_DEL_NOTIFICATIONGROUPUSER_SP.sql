-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_DEL_NOTIFICATIONGROUPUSER_SP
    @NotificationGroup INT,
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
    DELETE ANN_NOTIFICATIONGROUPUSER
      FROM ANN_NOTIFICATIONGROUPUSER (NOLOCK)
      JOIN ANN_NOTIFICATIONGROUP NOTIFICATIONGROUP (NOLOCK) ON ANN_NOTIFICATIONGROUPUSER.NOTIFICATIONGROUP = NOTIFICATIONGROUP.NOTIFICATIONGROUPID AND (@Organization IS NULL OR NOTIFICATIONGROUP.ORGANIZATION = @Organization)
      JOIN SEC_USER [USER] (NOLOCK) ON ANN_NOTIFICATIONGROUPUSER.[USER] = [USER].USERID AND (@Organization IS NULL OR [USER].ORGANIZATION = @Organization)
     WHERE ANN_NOTIFICATIONGROUPUSER.NOTIFICATIONGROUP = @NotificationGroup
       AND ANN_NOTIFICATIONGROUPUSER.[USER] = @User;

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
