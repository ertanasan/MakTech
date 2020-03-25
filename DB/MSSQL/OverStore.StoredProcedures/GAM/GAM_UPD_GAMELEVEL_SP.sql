-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_UPD_GAMELEVEL_SP
    @GameLevelId         INT,
    @Game                INT,
    @LevelName           VARCHAR(100),
    @QuestionCount       INT,
    @MinDifficultyLevel  INT,
    @MaxDifficultyLevel  INT,
    @Duration            INT,
    @LevelErrorTolerance INT,
    @PointofRightAnswer  INT,
    @LevelCode           INT
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
        LEVEL_CD
    )    
    SELECT
        GAMELEVELID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE GAM_GAMELEVEL
       SET
           GAME = @Game,
           LEVEL_NM = @LevelName,
           QUESTION_CNT = @QuestionCount,
           MINDIFFLEVEL_CD = @MinDifficultyLevel,
           MAXDIFFLEVEL_CD = @MaxDifficultyLevel,
           DURATION_CNT = @Duration,
           ERRTOLERANCE_CNT = @LevelErrorTolerance,
           POINTOFRIGHTANSWER_NO = @PointofRightAnswer,
           LEVEL_CD = @LevelCode
     WHERE GAMELEVELID = @GameLevelId;

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
