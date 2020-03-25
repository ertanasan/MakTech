-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_PROHIBITEDHOURS_SP
    @ProhibitedHoursId INT,
    @Action            INT,
    @StoreCode         INT,
    @StartHour         INT,
    @EndHour           INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        PROHIBITEDHOURSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        ACTION,
        STORE_CD,
        STARTHOUR_NO,
        ENDHOUR_NO
      FROM
        STR_PROHIBITEDHOURS P (NOLOCK)
     WHERE
        P.PROHIBITEDHOURSID = @ProhibitedHoursId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_PROHIBITEDHOURS
       SET
           ACTION = @Action,
           STORE_CD = @StoreCode,
           STARTHOUR_NO = @StartHour,
           ENDHOUR_NO = @EndHour
     WHERE PROHIBITEDHOURSID = @ProhibitedHoursId;

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
