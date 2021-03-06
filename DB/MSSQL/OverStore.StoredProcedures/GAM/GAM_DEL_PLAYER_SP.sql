﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_DEL_PLAYER_SP
    @GamePlayerId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
        BRANCH    )    
    SELECT
        PLAYERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PLAYER_NM,
        BRANCH
      FROM
        GAM_PLAYER P (NOLOCK)
     WHERE
        P.PLAYERID = @GamePlayerId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM GAM_PLAYER
     WHERE PLAYERID = @GamePlayerId;

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
