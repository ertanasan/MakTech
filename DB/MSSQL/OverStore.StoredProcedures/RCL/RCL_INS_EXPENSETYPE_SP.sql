-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_INS_EXPENSETYPE_SP
    @ExpenseTypeId   INT OUT,
    @ExpenseTypeName VARCHAR(100),
    @AccountCode     VARCHAR(50)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO RCL_EXPENSETYPE
    (
        EXPENSETYPE_NM,
        ACCOUNTCODE_TXT
    )
    VALUES
    (
        @ExpenseTypeName,
        @AccountCode
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
    SELECT @ExpenseTypeId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO RCL_EXPENSETYPELOG
    (
        EXPENSETYPEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        EXPENSETYPE_NM,
        ACCOUNTCODE_TXT
    )    
    VALUES
    (
        @ExpenseTypeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ExpenseTypeName,
        @AccountCode);
/*Section="End"*/
END;
