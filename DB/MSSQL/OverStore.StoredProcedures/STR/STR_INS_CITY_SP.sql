-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_CITY_SP
    @CityId    INT OUT,
    @CityName  VARCHAR(100),
    @PlateCode VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_CITY
    (
        CITY_NM,
        PLATECODE_TXT
    )
    VALUES
    (
        @CityName,
        @PlateCode
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
    SELECT @CityId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @CityId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @CityName,
        @PlateCode);
/*Section="End"*/
END;
