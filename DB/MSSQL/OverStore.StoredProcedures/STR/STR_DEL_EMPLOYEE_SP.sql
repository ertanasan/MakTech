-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_DEL_EMPLOYEE_SP
    @EmployeeId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
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
        WORKINGTYPE_DSC    )
    SELECT
        EMPLOYEEID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        EMPLOYEE_NM,
        DEPARTMENT_CD,
        DEPARTMENT_NM,
        INCENTIVEACT_CD,
        START_DT,
        QUIT_DT,
        WORKINGTYPE_DSC
      FROM
        STR_EMPLOYEE E (NOLOCK)
     WHERE
        E.EMPLOYEEID = @EmployeeId;
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE STR_EMPLOYEE
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE EMPLOYEEID = @EmployeeId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

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
