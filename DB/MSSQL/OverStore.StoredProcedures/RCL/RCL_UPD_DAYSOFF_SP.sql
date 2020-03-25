-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_UPD_DAYSOFF_SP
    @DaysOffId INT,
    @Store     INT,
    @OffDay    DATETIME
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO RCL_DAYSOFFLOG
    (
        DAYSOFFID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        STORE,
        OFFDAY_DT
    )    
    SELECT
        DAYSOFFID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STORE,
        OFFDAY_DT
      FROM
        RCL_DAYSOFF D (NOLOCK)
     WHERE
        D.DAYSOFFID = @DaysOffId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE RCL_DAYSOFF
       SET
           STORE = @Store,
           OFFDAY_DT = @OffDay
     WHERE DAYSOFFID = @DaysOffId;

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
