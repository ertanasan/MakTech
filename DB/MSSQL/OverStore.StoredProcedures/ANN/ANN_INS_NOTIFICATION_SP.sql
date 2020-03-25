-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_INS_NOTIFICATION_SP
    @NotificationId     BIGINT OUT,
    @Event              INT,
    @Organization       INT,
    @NotificationText   VARCHAR(MAX),
    @NotificationType   INT,
    @NotificationStatus INT,
    @Folder             BIGINT
AS
BEGIN
	IF @Event IS NULL BEGIN SET @Event = 1051 END
	IF @Organization IS NULL BEGIN SET @Organization = 1 END

    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ANN_NOTIFICATION
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        NOTIFICATION_TXT,
        NOTIFICATIONTYPE,
        NOTIFICATIONSTATUS,
        FOLDER
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @NotificationText,
        @NotificationType,
        @NotificationStatus,
        @Folder
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @NotificationId = SCOPE_IDENTITY();
/*Section="End"*/
END;
