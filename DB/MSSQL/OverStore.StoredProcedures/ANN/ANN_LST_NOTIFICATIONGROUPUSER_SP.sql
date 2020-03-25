-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_LST_NOTIFICATIONGROUPUSER_SP
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

    /*Section="Parameter Check"*/
    -- Check the parameter values
    IF @NotificationGroup IS NULL AND @User IS NULL
    BEGIN
        DECLARE @ErrorMessage VARCHAR(250);
        SET @ErrorMessage='At least one parameter should not be null.';
        THROW 100002, @ErrorMessage, 1;
        RETURN;
    END

    /*Section="Query"*/
    -- Select all
    SELECT
           N.NOTIFICATIONGROUP,
           N.[USER],
           N.CREATE_DT,
           N.CREATEUSER,
           N.CREATECHANNEL,
           N.CREATEBRANCH,
           N.CREATESCREEN,
           NOTIFICATIONGROUP.GROUP_NM "NOTIFICATIONGROUP.GROUP_NM",
           [USER].USER_NM "USER.USER_NM"
      FROM ANN_NOTIFICATIONGROUPUSER N (NOLOCK)
      JOIN ANN_NOTIFICATIONGROUP NOTIFICATIONGROUP (NOLOCK) ON N.NOTIFICATIONGROUP = NOTIFICATIONGROUP.NOTIFICATIONGROUPID AND (@Organization IS NULL OR NOTIFICATIONGROUP.ORGANIZATION = @Organization)
      JOIN SEC_USER [USER] (NOLOCK) ON N.[USER] = [USER].USERID AND (@Organization IS NULL OR [USER].ORGANIZATION = @Organization)
     WHERE (@NotificationGroup IS NULL OR N.NOTIFICATIONGROUP = @NotificationGroup)
       AND (@User IS NULL OR N.[USER] = @User);

/*Section="End"*/
END;
