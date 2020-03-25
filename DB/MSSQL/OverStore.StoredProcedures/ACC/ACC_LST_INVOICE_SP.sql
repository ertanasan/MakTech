CREATE PROCEDURE ACC_LST_INVOICE_SP AS
BEGIN
    
    IF OBJECT_ID('tempdb.dbo.#STORES', 'U') IS NOT NULL DROP TABLE #STORES;     
	SELECT * INTO #STORES FROM dbo.STR_GETUSERSTORES_FN();

    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      SET @Organization = null;
    END

    SELECT I.INVOICEID,
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
      JOIN #STORES ST ON S.STORE = ST.STOREID
     WHERE (@Organization IS NULL OR I.ORGANIZATION = @Organization)
       AND I.DELETED_FL = 'N'
     ORDER BY INVOICEID;

END;