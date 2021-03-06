﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_ACCOUNTS_SP
    @StoreAccountsId INT
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
           A.ACCOUNTSID,
           A.ORGANIZATION,
           A.DELETED_FL,
           A.CREATE_DT,
           A.UPDATE_DT,
           A.CREATEUSER,
           A.UPDATEUSER,
           A.STORE,
           A.ACCOUNTTYPE,
           A.BANK,
           A.ACCOUNT_TXT,
           A.ACCOUNT_DSC      
      FROM STR_ACCOUNTS A (NOLOCK)
     WHERE A.ACCOUNTSID = @StoreAccountsId     
       AND (@Organization IS NULL OR A.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
