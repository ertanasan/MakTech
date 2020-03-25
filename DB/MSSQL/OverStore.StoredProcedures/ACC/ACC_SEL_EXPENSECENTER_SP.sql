-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_EXPENSECENTER_SP
    @ExpenseCenterId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           E.EXPENSECENTERID,
           E.EXPENSECENTER_NM,
           E.EXPENSECENTERCODE_TXT,
           E.CENTERGROUP_NO,
           E.REGIONMANAGER,
           E.STORE,
           E.ACTIVE_FL      
      FROM ACC_EXPENSECENTER E (NOLOCK)
     WHERE E.EXPENSECENTERID = @ExpenseCenterId;

    /*Section="End"*/
END;
