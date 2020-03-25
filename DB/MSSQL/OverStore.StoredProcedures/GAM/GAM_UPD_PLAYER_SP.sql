-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_UPD_PLAYER_SP
    @GamePlayerId INT,
    @PlayerName   VARCHAR(100),
    @Branch       INT
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
        BRANCH
    )    
    SELECT
        PLAYERID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        PLAYER_NM,
        BRANCH
      FROM
        GAM_PLAYER P (NOLOCK)
     WHERE
        P.PLAYERID = @GamePlayerId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE GAM_PLAYER
       SET
           PLAYER_NM = @PlayerName,
           BRANCH = @Branch
     WHERE PLAYERID = @GamePlayerId;

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
