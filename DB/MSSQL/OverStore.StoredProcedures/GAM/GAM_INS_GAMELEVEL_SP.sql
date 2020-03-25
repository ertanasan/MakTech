-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_INS_GAMELEVEL_SP
    @GameLevelId         INT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO GAM_GAMELEVEL
    (
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
    VALUES
    (
        @Game,
        @LevelName,
        @QuestionCount,
        @MinDifficultyLevel,
        @MaxDifficultyLevel,
        @Duration,
        @LevelErrorTolerance,
        @PointofRightAnswer,
        @LevelCode
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @GameLevelId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @GameLevelId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @Game,
        @LevelName,
        @QuestionCount,
        @MinDifficultyLevel,
        @MaxDifficultyLevel,
        @Duration,
        @LevelErrorTolerance,
        @PointofRightAnswer,
        @LevelCode);
/*Section="End"*/
END;
