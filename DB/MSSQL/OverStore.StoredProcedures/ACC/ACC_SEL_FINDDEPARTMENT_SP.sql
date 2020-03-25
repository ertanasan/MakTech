-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_FINDDEPARTMENT_SP
    @DepartmentName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           D.DEPARTMENTID,
           D.DEPARTMENT_NM,
           D.STORE,
           D.EXPENSECENTER_TXT      
      FROM ACC_DEPARTMENT D (NOLOCK)
     WHERE D.DEPARTMENT_NM = @DepartmentName;

/*Section="End"*/
END;
