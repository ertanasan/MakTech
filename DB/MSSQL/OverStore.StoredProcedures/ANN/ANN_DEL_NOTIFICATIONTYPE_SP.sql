-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_DEL_NOTIFICATIONTYPE_SP
    @NotificationTypeId INT
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
        DESCRIPTION_DSC    )    
    SELECT
        NOTIFICATIONTYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        NOTIFICATIONTYPE_NM,
        DESCRIPTION_DSC
      FROM
        ANN_NOTIFICATIONTYPE N (NOLOCK)
     WHERE
        N.NOTIFICATIONTYPEID = @NotificationTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ANN_NOTIFICATIONTYPE
     WHERE NOTIFICATIONTYPEID = @NotificationTypeId;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
