-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_LST_EINVOICECLIENT_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
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
     ORDER BY IDENTIFIER_NO;

/*Section="End"*/
END;
