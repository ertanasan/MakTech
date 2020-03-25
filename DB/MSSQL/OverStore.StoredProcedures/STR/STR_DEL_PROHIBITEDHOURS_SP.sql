-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_PROHIBITEDHOURS_SP
    @ProhibitedHoursId INT
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
        ENDHOUR_NO    )    
    SELECT
        PROHIBITEDHOURSID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_PROHIBITEDHOURS
     WHERE PROHIBITEDHOURSID = @ProhibitedHoursId;

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
