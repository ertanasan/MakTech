-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_INS_PLAY_SP
    @GamePlayId    BIGINT OUT,
    @Organization  INT,
    @Game          INT,
    @Player        INT,
    @StartTime     DATETIME,
    @EndTime       DATETIME,
    @LastLevel     INT,
    @QuestionCount INT,
    @Score         INT,
    @DeviceInfo    VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO GAM_PLAY
    (
        ORGANIZATION,
        CREATE_DT,
        CREATEUSER,
        GAME,
        PLAYER,
        START_TM,
        END_TM,
        LASTLEVEL_CD,
        QUESTION_CNT,
        SCORE_NO,
        DEVICEINFO_TXT
    )
    VALUES
    (
        @Organization,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Game,
        @Player,
        @StartTime,
        @EndTime,
        @LastLevel,
        @QuestionCount,
        @Score,
        @DeviceInfo
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
    SELECT @GamePlayId = SCOPE_IDENTITY();
/*Section="End"*/
END;
