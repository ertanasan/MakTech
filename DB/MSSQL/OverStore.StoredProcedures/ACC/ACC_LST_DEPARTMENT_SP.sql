-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_LST_DEPARTMENT_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           D.DEPARTMENTID,
           D.DEPARTMENT_NM,
           D.STORE,
           D.EXPENSECENTER_TXT
      FROM ACC_DEPARTMENT D (NOLOCK)
     ORDER BY DEPARTMENT_NM;

/*Section="End"*/
END;
