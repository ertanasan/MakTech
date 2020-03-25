-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_LST_PLAYER_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PLAYERID,
           P.PLAYER_NM,
           P.BRANCH
      FROM GAM_PLAYER P (NOLOCK)
     ORDER BY PLAYER_NM;

/*Section="End"*/
END;
