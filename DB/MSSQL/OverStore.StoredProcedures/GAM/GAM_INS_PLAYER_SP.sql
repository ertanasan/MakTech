-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_INS_PLAYER_SP
    @GamePlayerId INT OUT,
    @PlayerName   VARCHAR(100),
    @Branch       INT
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO GAM_PLAYER
    (
        PLAYER_NM,
        BRANCH
    )
    VALUES
    (
        @PlayerName,
        @Branch
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
    SELECT @GamePlayerId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO GAM_PLAYERLOG
    (
        PLAYERID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        PLAYER_NM,
        BRANCH
    )    
    VALUES
    (
        @GamePlayerId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @PlayerName,
        @Branch);
/*Section="End"*/
END;
