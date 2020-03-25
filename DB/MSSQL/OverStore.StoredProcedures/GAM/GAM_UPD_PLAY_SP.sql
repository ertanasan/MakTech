-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_UPD_PLAY_SP
    @GamePlayId    BIGINT,
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
    /*Section="Organization"*/
    -- Get the caller organization from session context
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE GAM_PLAY
       SET
           GAME = @Game,
           PLAYER = @Player,
           START_TM = @StartTime,
           END_TM = @EndTime,
           LASTLEVEL_CD = @LastLevel,
           QUESTION_CNT = @QuestionCount,
           SCORE_NO = @Score,
           DEVICEINFO_TXT = @DeviceInfo
     WHERE PLAYID = @GamePlayId     
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
