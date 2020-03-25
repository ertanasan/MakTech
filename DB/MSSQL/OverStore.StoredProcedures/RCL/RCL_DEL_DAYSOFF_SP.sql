-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_DEL_DAYSOFF_SP
    @DaysOffId INT
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
        OFFDAY_DT    )    
    SELECT
        DAYSOFFID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        STORE,
        OFFDAY_DT
      FROM
        RCL_DAYSOFF D (NOLOCK)
     WHERE
        D.DAYSOFFID = @DaysOffId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM RCL_DAYSOFF
     WHERE DAYSOFFID = @DaysOffId;

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
