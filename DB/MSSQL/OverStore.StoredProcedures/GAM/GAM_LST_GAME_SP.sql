-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_LST_GAME_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           G.GAMEID,
           G.GAME_NM,
           G.ERRTOLERANCE_CNT
      FROM GAM_GAME G (NOLOCK)
     ORDER BY GAME_NM;

/*Section="End"*/
END;
