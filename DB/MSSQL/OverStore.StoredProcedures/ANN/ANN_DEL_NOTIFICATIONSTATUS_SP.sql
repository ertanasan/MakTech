-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_DEL_NOTIFICATIONSTATUS_SP
    @NotificationStatusId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO ANN_NOTIFICATIONSTATUSLOG
    (
        NOTIFICATIONSTATUSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        NOTIFICATIONSTATUS_NM,
        DESCRIPTION_DSC    )    
    SELECT
        NOTIFICATIONSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        NOTIFICATIONSTATUS_NM,
        DESCRIPTION_DSC
      FROM
        ANN_NOTIFICATIONSTATUS N (NOLOCK)
     WHERE
        N.NOTIFICATIONSTATUSID = @NotificationStatusId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM ANN_NOTIFICATIONSTATUS
     WHERE NOTIFICATIONSTATUSID = @NotificationStatusId;

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
