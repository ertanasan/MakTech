-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_EXPENSETYPE_SP
    @ExpenseTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           E.EXPENSETYPEID,
           E.EXPENSETYPE_NM,
           E.ACCOUNTCODE_TXT      
      FROM RCL_EXPENSETYPE E (NOLOCK)
     WHERE E.EXPENSETYPEID = @ExpenseTypeId;

    /*Section="End"*/
END;
