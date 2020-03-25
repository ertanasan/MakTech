-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_CITY_SP
    @CityId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO STR_CITYLOG
    (
        CITYID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CITY_NM,
        PLATECODE_TXT    )    
    SELECT
        CITYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CITY_NM,
        PLATECODE_TXT
      FROM
        STR_CITY C (NOLOCK)
     WHERE
        C.CITYID = @CityId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM STR_CITY
     WHERE CITYID = @CityId;

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
