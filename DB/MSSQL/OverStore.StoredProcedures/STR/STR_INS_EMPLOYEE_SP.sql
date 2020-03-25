-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_INS_EMPLOYEE_SP
    @EmployeeId       INT,
    @EmployeeName     VARCHAR(100),
    @DepartmentCode   INT,
    @DepartmentName   VARCHAR(100),
    @IncentiveActCode INT,
    @StartDate        DATETIME,
    @QuitDate         DATETIME,
    @WorkingType      VARCHAR(100)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO STR_EMPLOYEE
    (
        EMPLOYEEID,
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        EMPLOYEE_NM,
        DEPARTMENT_CD,
        DEPARTMENT_NM,
        INCENTIVEACT_CD,
        START_DT,
        QUIT_DT,
        WORKINGTYPE_DSC
    )
    VALUES
    (
        @EmployeeId,
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @EmployeeName,
        @DepartmentCode,
        @DepartmentName,
        @IncentiveActCode,
        @StartDate,
        @QuitDate,
        @WorkingType
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

    /*Section="Log"*/
    -- Create log record
    INSERT INTO STR_EMPLOYEELOG
    (
        EMPLOYEEID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        EMPLOYEE_NM,
        DEPARTMENT_CD,
        DEPARTMENT_NM,
        INCENTIVEACT_CD,
        START_DT,
        QUIT_DT,
        WORKINGTYPE_DSC
    )
    VALUES
    (
        @EmployeeId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @EmployeeName,
        @DepartmentCode,
        @DepartmentName,
        @IncentiveActCode,
        @StartDate,
        @QuitDate,
        @WorkingType);
/*Section="End"*/
END;
