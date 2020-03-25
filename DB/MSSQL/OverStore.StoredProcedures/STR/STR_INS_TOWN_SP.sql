-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_TOWN_SP
    @TownId   INT OUT,
    @City     INT,
    @TownName VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_TOWN
    (
        CITY,
        TOWN_NM
    )
    VALUES
    (
        @City,
        @TownName
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
    SELECT @TownId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_TOWNLOG
    (
        TOWNID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CITY,
        TOWN_NM
    )    
    VALUES
    (
        @TownId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @City,
        @TownName);
/*Section="End"*/
END;
