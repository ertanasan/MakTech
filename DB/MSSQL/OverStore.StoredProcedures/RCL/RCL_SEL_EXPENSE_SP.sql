-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_EXPENSE_SP
    @ExpenseId BIGINT
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
           E.EXPENSEID,
           E.EVENT,
           E.ORGANIZATION,
           E.DELETED_FL,
           E.CREATE_DT,
           E.UPDATE_DT,
           E.CREATEUSER,
           E.UPDATEUSER,
           E.CREATECHANNEL,
           E.CREATEBRANCH,
           E.CREATESCREEN,
           E.EXPENSETYPE,
           E.STORE,
           E.EXPENSE_DT,
           E.EXPENSE_AMT,
           E.RECEIPTNO_TXT,
           E.OPEN_FL,
           E.PAYOFF_DT,
           E.EXPENSE_DSC,
           E.VAT_RT,
           E.MIKRO_CD,
           E.MIKRO_TM,
           E.STATUS_CD,
           E.STATUS_TXT,
           E.MIKROUSER,
           E.HASRECEIPT_FL,
           E.REGIONMANAGER
      FROM RCL_EXPENSE E (NOLOCK)
     WHERE E.EXPENSEID = @ExpenseId
       AND (@Organization IS NULL OR E.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
