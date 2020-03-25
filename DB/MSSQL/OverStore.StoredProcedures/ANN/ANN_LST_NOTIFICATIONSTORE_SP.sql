-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_LST_NOTIFICATIONSTORE_SP
    @Notification BIGINT,
    @Store INT
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

    /*Section="Parameter Check"*/
    -- Check the parameter values
    IF @Notification IS NULL AND @Store IS NULL
    BEGIN
        DECLARE @ErrorMessage VARCHAR(250);
        SET @ErrorMessage='At least one parameter should not be null.';
        THROW 100002, @ErrorMessage, 1;
        RETURN;
    END

    /*Section="Query"*/
    -- Select all
    SELECT
           N.NOTIFICATION,
           N.STORE,
           N.CREATE_DT,
           N.CREATEUSER,
           N.CREATECHANNEL,
           N.CREATEBRANCH,
           N.CREATESCREEN,
           N.PROCESSINSTANCE_LNO,
           NOTIFICATION.NOTIFICATIONID "NOTIFICATION.NOTIFICATIONID",
           STORE.STORE_NM "STORE.STORE_NM"
      FROM ANN_NOTIFICATIONSTORE N (NOLOCK)
      JOIN ANN_NOTIFICATION NOTIFICATION (NOLOCK) ON N.NOTIFICATION = NOTIFICATION.NOTIFICATIONID AND (@Organization IS NULL OR NOTIFICATION.ORGANIZATION = @Organization)
      JOIN STR_STORE STORE (NOLOCK) ON N.STORE = STORE.STOREID AND (@Organization IS NULL OR STORE.ORGANIZATION = @Organization)
     WHERE (@Notification IS NULL OR N.NOTIFICATION = @Notification)
       AND (@Store IS NULL OR N.STORE = @Store);

/*Section="End"*/
END;
