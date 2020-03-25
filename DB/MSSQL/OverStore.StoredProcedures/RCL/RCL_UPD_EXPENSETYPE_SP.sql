-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_UPD_EXPENSETYPE_SP
    @ExpenseTypeId   INT,
    @ExpenseTypeName VARCHAR(100),
    @AccountCode     VARCHAR(50)
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
        ACCOUNTCODE_TXT
    )    
    SELECT
        EXPENSETYPEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EXPENSETYPE_NM,
        ACCOUNTCODE_TXT
      FROM
        RCL_EXPENSETYPE E (NOLOCK)
     WHERE
        E.EXPENSETYPEID = @ExpenseTypeId;

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE RCL_EXPENSETYPE
       SET
           EXPENSETYPE_NM = @ExpenseTypeName,
           ACCOUNTCODE_TXT = @AccountCode
     WHERE EXPENSETYPEID = @ExpenseTypeId;

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
