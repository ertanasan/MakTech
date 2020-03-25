-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_SEL_PLAY_SP
    @GamePlayId BIGINT
AS
BEGIN
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Query"*/
    -- Select
    SELECT
           P.PLAYID,
           P.ORGANIZATION,
           P.CREATE_DT,
           P.CREATEUSER,
           P.GAME,
           P.PLAYER,
           P.START_TM,
           P.END_TM,
           P.LASTLEVEL_CD,
           P.QUESTION_CNT,
           P.SCORE_NO,
           P.DEVICEINFO_TXT      
      FROM GAM_PLAY P (NOLOCK)
     WHERE P.PLAYID = @GamePlayId     
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
