-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_DEPARTMENT_SP
    @AccountingDepartmentId INT OUT,
    @DepartmentName         VARCHAR(100),
    @Store                  INT,
    @ExpenseCenter          VARCHAR(50)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_DEPARTMENT
    (
        DEPARTMENT_NM,
        STORE,
        EXPENSECENTER_TXT
    )
    VALUES
    (
        @DepartmentName,
        @Store,
        @ExpenseCenter
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
    SELECT @AccountingDepartmentId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO ACC_DEPARTMENTLOG
    (
        DEPARTMENTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        DEPARTMENT_NM,
        STORE,
        EXPENSECENTER_TXT
    )    
    VALUES
    (
        @AccountingDepartmentId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @DepartmentName,
        @Store,
        @ExpenseCenter);
/*Section="End"*/
END;
