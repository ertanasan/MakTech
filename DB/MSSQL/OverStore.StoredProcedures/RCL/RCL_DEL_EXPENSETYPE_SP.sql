-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_DEL_EXPENSETYPE_SP
    @ExpenseTypeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
        ACCOUNTCODE_TXT    )    
    SELECT
        EXPENSETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EXPENSETYPE_NM,
        ACCOUNTCODE_TXT
      FROM
        RCL_EXPENSETYPE E (NOLOCK)
     WHERE
        E.EXPENSETYPEID = @ExpenseTypeId;

    /*Section="Delete"*/
    SET NOCOUNT OFF

    -- Perform deletion
    DELETE FROM RCL_EXPENSETYPE
     WHERE EXPENSETYPEID = @ExpenseTypeId;

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
