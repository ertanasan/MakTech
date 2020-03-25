-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_DEL_GAME_SP
    @GameId INT
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
        ERRTOLERANCE_CNT    )    
    SELECT
        GAMEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GAME_NM,
        ERRTOLERANCE_CNT
      FROM
        GAM_GAME G (NOLOCK)
     WHERE
        G.GAMEID = @GameId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM GAM_GAME
     WHERE GAMEID = @GameId;

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
