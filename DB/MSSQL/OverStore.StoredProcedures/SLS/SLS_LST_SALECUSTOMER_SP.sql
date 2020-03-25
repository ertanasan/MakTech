-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_LST_SALECUSTOMER_SP
    @Sale BIGINT = NULL
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
           S.SALECUSTOMERID,
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
           S.EINVOICE_FL,
           S.CUSTOMER_NM,
           S.ADDRESS_TXT,
           S.TAXCENTER_NM,
           S.IDENTITYNO_TXT,
           S.EMAIL_TXT,
           S.PHONENUMBER_TXT,
           S.FISCALSERIAL_TXT,
           S.EINVOICEZET_NO,
           S.EINVOICERECEIPT_NO
      FROM SLS_SALECUSTOMER S (NOLOCK)
     WHERE (@Sale IS NULL OR S.SALE = @Sale)
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N';

/*Section="End"*/
END;
