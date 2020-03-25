-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_UPD_NOTIFICATIONTYPE_SP
    @NotificationTypeId   INT,
    @NotificationTypeName VARCHAR(100),
    @Description          VARCHAR(1000)
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        NOTIFICATIONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        NOTIFICATIONTYPE_NM,
        DESCRIPTION_DSC
      FROM
        ANN_NOTIFICATIONTYPE N (NOLOCK)
     WHERE
        N.NOTIFICATIONTYPEID = @NotificationTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ANN_NOTIFICATIONTYPE
       SET
           NOTIFICATIONTYPE_NM = @NotificationTypeName,
           DESCRIPTION_DSC = @Description
     WHERE NOTIFICATIONTYPEID = @NotificationTypeId;

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
