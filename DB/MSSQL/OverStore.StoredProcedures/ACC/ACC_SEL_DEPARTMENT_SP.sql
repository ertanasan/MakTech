-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_DEPARTMENT_SP
    @AccountingDepartmentId INT
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
     WHERE D.DEPARTMENTID = @AccountingDepartmentId;

    /*Section="End"*/
END;
