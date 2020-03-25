-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_SEL_GAME_SP
    @GameId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           G.GAMEID,
           G.GAME_NM,
           G.ERRTOLERANCE_CNT      
      FROM GAM_GAME G (NOLOCK)
     WHERE G.GAMEID = @GameId;

    /*Section="End"*/
END;
