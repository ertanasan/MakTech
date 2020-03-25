-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_FINDEXPENSETYPE_SP
    @ExpenseTypeName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           E.EXPENSETYPEID,
           E.EXPENSETYPE_NM,
           E.ACCOUNTCODE_TXT      
      FROM RCL_EXPENSETYPE E (NOLOCK)
     WHERE E.EXPENSETYPE_NM = @ExpenseTypeName;

/*Section="End"*/
END;
