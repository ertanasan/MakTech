-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_DEL_GAMELEVEL_SP
    @GameLevelId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO GAM_GAMELEVELLOG
    (
        GAMELEVELID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        GAME,
        LEVEL_NM,
        QUESTION_CNT,
        MINDIFFLEVEL_CD,
        MAXDIFFLEVEL_CD,
        DURATION_CNT,
        ERRTOLERANCE_CNT,
        POINTOFRIGHTANSWER_NO,
        LEVEL_CD    )    
    SELECT
        GAMELEVELID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        GAME,
        LEVEL_NM,
        QUESTION_CNT,
        MINDIFFLEVEL_CD,
        MAXDIFFLEVEL_CD,
        DURATION_CNT,
        ERRTOLERANCE_CNT,
        POINTOFRIGHTANSWER_NO,
        LEVEL_CD
      FROM
        GAM_GAMELEVEL G (NOLOCK)
     WHERE
        G.GAMELEVELID = @GameLevelId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM GAM_GAMELEVEL
     WHERE GAMELEVELID = @GameLevelId;

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
