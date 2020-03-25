-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_LST_SALEPAYMENT_SP
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
    -- Select all
    SELECT
           S.SALEPAYMENTID,
           S.EVENT,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.CREATECHANNEL,
           S.CREATEBRANCH,
           S.CREATESCREEN,
           S.SALE,
           S.TRANSACTION_TXT,
           S.TRANSACTION_DT,
           S.STORE,
           S.PAYMENTTYPE_TXT,
           S.PAID_AMT,
           S.REFUND_AMT,
           S.POSBANKTYPE,
           S.POSTRXTYPE,
           S.ACCNO_TXT,
           S.DEBITCARD_FL,
           S.CARD_AMT
      FROM SLS_SALEPAYMENT S (NOLOCK)
     WHERE (@Organization IS NULL OR S.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N';

/*Section="End"*/
END;
