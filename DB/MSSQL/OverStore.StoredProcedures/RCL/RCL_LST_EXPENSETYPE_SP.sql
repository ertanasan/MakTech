-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_LST_EXPENSETYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           E.EXPENSETYPEID,
           E.EXPENSETYPE_NM,
           E.ACCOUNTCODE_TXT
      FROM RCL_EXPENSETYPE E (NOLOCK)
     ORDER BY EXPENSETYPE_NM;

/*Section="End"*/
END;
