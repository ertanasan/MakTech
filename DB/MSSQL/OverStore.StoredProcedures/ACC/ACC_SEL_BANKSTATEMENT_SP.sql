﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_BANKSTATEMENT_SP
    @BankStatementId BIGINT
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
           B.BANKSTATEMENTID,
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
           B.DATE_DT,
           B.DESCRIPTION_DSC,
           B.TRANSACTION_AMT,
           B.BALANCE_AMT,
           B.CHANNEL_DSC,
           B.INFO1_DSC,
           B.INFO2_DSC,
           B.INFO3_DSC
      FROM ACC_BANKSTATEMENT B (NOLOCK)
     WHERE B.BANKSTATEMENTID = @BankStatementId
       AND (@Organization IS NULL OR B.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
