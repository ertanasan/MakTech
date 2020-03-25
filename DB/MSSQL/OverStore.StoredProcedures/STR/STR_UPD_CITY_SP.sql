-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_UPD_CITY_SP
    @CityId    INT,
    @CityName  VARCHAR(100),
    @PlateCode VARCHAR(1000)
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
        PLATECODE_TXT
    )    
    SELECT
        CITYID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CITY_NM,
        PLATECODE_TXT
      FROM
        STR_CITY C (NOLOCK)
     WHERE
        C.CITYID = @CityId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE STR_CITY
       SET
           CITY_NM = @CityName,
           PLATECODE_TXT = @PlateCode
     WHERE CITYID = @CityId;

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
