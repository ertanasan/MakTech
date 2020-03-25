-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_INVOICE_SP
    @SaleInvoiceId BIGINT
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
           I.INVOICEID,
           I.EVENT,
           I.ORGANIZATION,
           I.DELETED_FL,
           I.CREATE_DT,
           I.UPDATE_DT,
           I.CREATEUSER,
           I.UPDATEUSER,
           I.CREATECHANNEL,
           I.CREATEBRANCH,
           I.CREATESCREEN,
           I.EINVOICE_FL,
           I.CUSTOMERID_LNO,
           I.TITLE_DSC,
           I.EMAIL_TXT,
           I.SALE,
           I.EINVOICECLIENT,
           I.ADDRESS_TXT,
           I.STATUS_CD,
           I.MIKRO_FL,
           I.MIKRO_TM,
           S.TRANSACTION_DT,
		   S.TRANSACTION_TXT,
		   S.TOTAL_AMT,
		   S.STORE,
           I.PROCESSINSTANCE_LNO,
           I.PHONENUMBER_TXT
      FROM ACC_INVOICE I (NOLOCK)
      JOIN SLS_SALE S (NOLOCK) ON I.SALE = S.SALEID
     WHERE I.INVOICEID = @SaleInvoiceId
       AND (@Organization IS NULL OR I.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
