-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_DAYSOFF_SP
    @DaysOffId INT OUT,
    @Store     INT,
    @OffDay    DATETIME
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_DAYSOFF
    (
        STORE,
        OFFDAY_DT
    )
    VALUES
    (
        @Store,
        @OffDay
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
    SELECT @DaysOffId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @DaysOffId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Store,
        @OffDay);
/*Section="End"*/
END;
