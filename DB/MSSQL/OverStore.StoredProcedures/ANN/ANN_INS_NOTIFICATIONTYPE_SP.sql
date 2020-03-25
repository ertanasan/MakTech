-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_INS_NOTIFICATIONTYPE_SP
    @NotificationTypeId   INT,
    @NotificationTypeName VARCHAR(100),
    @Description          VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ANN_NOTIFICATIONTYPE
    (
        NOTIFICATIONTYPEID,
        NOTIFICATIONTYPE_NM,
        DESCRIPTION_DSC
    )
    VALUES
    (
        @NotificationTypeId,
        @NotificationTypeName,
        @Description
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

    /*Section="Log"*/
    -- Create log record
    INSERT INTO ANN_NOTIFICATIONTYPELOG
    (
        NOTIFICATIONTYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        NOTIFICATIONTYPE_NM,
        DESCRIPTION_DSC
    )    
    VALUES
    (
        @NotificationTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @NotificationTypeName,
        @Description);
/*Section="End"*/
END;
