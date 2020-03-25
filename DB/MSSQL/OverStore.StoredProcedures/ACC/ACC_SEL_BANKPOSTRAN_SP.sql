-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_BANKPOSTRAN_SP
    @BankPosTransactionsId BIGINT
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
           B.BANKPOSTRANID,
           B.EVENT,
           B.ORGANIZATION,
           B.DELETED_FL,
           B.CREATE_DT,
           B.UPDATE_DT,
           B.CREATEUSER,
           B.UPDATEUSER,
           B.CREATECHANNEL,
           B.CREATEBRANCH,
           B.CREATESCREEN,
           B.BANK,
           B.STOREREF_TXT,
           B.POSREF_TXT,
           B.BLOCKED_DT,
           B.VALUE_DT,
           B.QUANTITY_QTY,
           B.CREDIT_AMT,
           B.DEBIT_AMT,
           B.COMMISSION_AMT,
           B.MIKRO_TM,
           B.MIKROSTATUS_CD,
           B.MIKROTRANCODE_TXT
      FROM ACC_BANKPOSTRAN B (NOLOCK)
     WHERE B.BANKPOSTRANID = @BankPosTransactionsId
       AND (@Organization IS NULL OR B.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
