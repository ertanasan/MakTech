-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE GAM_INS_ANSWER_SP
    @GamePlayAnswerId BIGINT OUT,
    @Organization     INT,
    @Play             BIGINT,
    @Question         INT,
    @AnswerChoice     INT,
    @ResultFlag       VARCHAR(1)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO GAM_ANSWER
    (
        ORGANIZATION,
        CREATE_DT,
        CREATEUSER,
        PLAY,
        QUESTION,
        ANSWERCHOICE,
        RESULT_FL
    )
    VALUES
    (
        @Organization,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @Play,
        @Question,
        @AnswerChoice,
        @ResultFlag
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
    SELECT @GamePlayAnswerId = SCOPE_IDENTITY();
/*Section="End"*/
END;
