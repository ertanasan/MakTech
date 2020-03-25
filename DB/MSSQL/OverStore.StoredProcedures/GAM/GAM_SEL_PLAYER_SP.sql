-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_SEL_PLAYER_SP
    @GamePlayerId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PLAYERID,
           P.PLAYER_NM,
           P.BRANCH      
      FROM GAM_PLAYER P (NOLOCK)
     WHERE P.PLAYERID = @GamePlayerId;

    /*Section="End"*/
END;
