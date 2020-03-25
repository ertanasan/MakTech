-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_UPD_NOTIFICATIONSTORE_SP
    @Notification    BIGINT,
    @Store           INT,
    @ProcessInstance BIGINT
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ANN_NOTIFICATIONSTORE
       SET
           ANN_NOTIFICATIONSTORE.PROCESSINSTANCE_LNO = @ProcessInstance
      FROM ANN_NOTIFICATIONSTORE (NOLOCK)
      JOIN ANN_NOTIFICATION NOTIFICATION (NOLOCK) ON ANN_NOTIFICATIONSTORE.NOTIFICATION = NOTIFICATION.NOTIFICATIONID AND (@Organization IS NULL OR NOTIFICATION.ORGANIZATION = @Organization)
      JOIN STR_STORE STORE (NOLOCK) ON ANN_NOTIFICATIONSTORE.STORE = STORE.STOREID AND (@Organization IS NULL OR STORE.ORGANIZATION = @Organization)
     WHERE ANN_NOTIFICATIONSTORE.NOTIFICATION = @Notification
       AND ANN_NOTIFICATIONSTORE.STORE = @Store;

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
