-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ANN_UPD_NOTIFICATIONSTATUS_SP
    @NotificationStatusId   INT,
    @NotificationStatusName VARCHAR(100),
    @Description            VARCHAR(1000)
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
        DESCRIPTION_DSC
    )    
    SELECT
        NOTIFICATIONSTATUSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        NOTIFICATIONSTATUS_NM,
        DESCRIPTION_DSC
      FROM
        ANN_NOTIFICATIONSTATUS N (NOLOCK)
     WHERE
        N.NOTIFICATIONSTATUSID = @NotificationStatusId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ANN_NOTIFICATIONSTATUS
       SET
           NOTIFICATIONSTATUS_NM = @NotificationStatusName,
           DESCRIPTION_DSC = @Description
     WHERE NOTIFICATIONSTATUSID = @NotificationStatusId;

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
