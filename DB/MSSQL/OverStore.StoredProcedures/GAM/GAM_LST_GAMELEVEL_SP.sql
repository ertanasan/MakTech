-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_LST_GAMELEVEL_SP
    @Game INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           G.GAMELEVELID,
           G.GAME,
           G.LEVEL_NM,
           G.QUESTION_CNT,
           G.MINDIFFLEVEL_CD,
           G.MAXDIFFLEVEL_CD,
           G.DURATION_CNT,
           G.ERRTOLERANCE_CNT,
           G.POINTOFRIGHTANSWER_NO,
           G.LEVEL_CD
      FROM GAM_GAMELEVEL G (NOLOCK)
     WHERE (@Game IS NULL OR G.GAME = @Game)
     ORDER BY LEVEL_CD;

/*Section="End"*/
END;
