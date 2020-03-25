-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_UPD_GAME_SP
    @GameId         INT,
    @GameName       VARCHAR(100),
    @ErrorTolerance INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
    SELECT
        GAMEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GAME_NM,
        ERRTOLERANCE_CNT
      FROM
        GAM_GAME G (NOLOCK)
     WHERE
        G.GAMEID = @GameId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE GAM_GAME
       SET
           GAME_NM = @GameName,
           ERRTOLERANCE_CNT = @ErrorTolerance
     WHERE GAMEID = @GameId;

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
