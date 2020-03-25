-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_EINVOICECLIENT_SP
    @EInvoiceClientId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           E.EINVOICECLIENTID,
           E.IDENTIFIER_NO,
           E.ALIAS_DSC,
           E.TITLE_DSC,
           E.TYPE_NM,
           E.FIRSTCREATE_TM,
           E.ALIASCREATE_TM,
           E.EMAIL_TXT
      FROM ACC_EINVOICECLIENT E (NOLOCK)
     WHERE E.EINVOICECLIENTID = @EInvoiceClientId;

    /*Section="End"*/
END;
