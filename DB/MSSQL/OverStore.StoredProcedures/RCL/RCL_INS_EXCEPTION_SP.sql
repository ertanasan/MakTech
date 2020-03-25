-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_EXCEPTION_SP
    @ExceptionLogId   BIGINT OUT,
    @Event            INT,
    @Organization     INT,
    @ExceptionMessage VARCHAR(4000),
    @Parameters       VARCHAR(4000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_EXCEPTION
    (
        EVENT,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        CREATECHANNEL,
        CREATEBRANCH,
        CREATESCREEN,
        MESSAGE_TXT,
        PARAMETERS_TXT
    )
    VALUES
    (
        @Event,
        @Organization,
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ExceptionMessage,
        @Parameters
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
    SELECT @ExceptionLogId = SCOPE_IDENTITY();
/*Section="End"*/
END;
