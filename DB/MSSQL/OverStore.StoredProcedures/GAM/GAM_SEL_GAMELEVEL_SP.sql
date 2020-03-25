-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_SEL_GAMELEVEL_SP
    @GameLevelId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
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
     WHERE G.GAMELEVELID = @GameLevelId;

    /*Section="End"*/
END;
