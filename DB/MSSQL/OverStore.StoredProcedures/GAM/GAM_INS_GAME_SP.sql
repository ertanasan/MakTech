-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_INS_GAME_SP
    @GameId         INT OUT,
    @GameName       VARCHAR(100),
    @ErrorTolerance INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO GAM_GAME
    (
        GAME_NM,
        ERRTOLERANCE_CNT
    )
    VALUES
    (
        @GameName,
        @ErrorTolerance
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
    SELECT @GameId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO GAM_GAMELOG
    (
        GAMEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GAME_NM,
        ERRTOLERANCE_CNT
    )    
    VALUES
    (
        @GameId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @GameName,
        @ErrorTolerance);
/*Section="End"*/
END;
