-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_EMPLOYEE_SP
    @EmployeeId INT
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
           E.EMPLOYEEID,
           E.ORGANIZATION,
           E.DELETED_FL,
           E.CREATE_DT,
           E.UPDATE_DT,
           E.CREATEUSER,
           E.UPDATEUSER,
           E.EMPLOYEE_NM,
           E.DEPARTMENT_CD,
           E.DEPARTMENT_NM,
           E.INCENTIVEACT_CD,
           E.START_DT,
           E.QUIT_DT,
           E.WORKINGTYPE_DSC
      FROM STR_EMPLOYEE E (NOLOCK)
     WHERE E.EMPLOYEEID = @EmployeeId
       AND (@Organization IS NULL OR E.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
