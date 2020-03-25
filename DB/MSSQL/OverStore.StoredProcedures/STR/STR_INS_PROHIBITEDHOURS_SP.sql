-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_PROHIBITEDHOURS_SP
    @ProhibitedHoursId INT OUT,
    @Action            INT,
    @StoreCode         INT,
    @StartHour         INT,
    @EndHour           INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_PROHIBITEDHOURS
    (
        ACTION,
        STORE_CD,
        STARTHOUR_NO,
        ENDHOUR_NO
    )
    VALUES
    (
        @Action,
        @StoreCode,
        @StartHour,
        @EndHour
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
    SELECT @ProhibitedHoursId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_PROHIBITEDHOURSLOG
    (
        PROHIBITEDHOURSID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ACTION,
        STORE_CD,
        STARTHOUR_NO,
        ENDHOUR_NO
    )    
    VALUES
    (
        @ProhibitedHoursId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Action,
        @StoreCode,
        @StartHour,
        @EndHour);
/*Section="End"*/
END;
