-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_BANK_SP
    @BankId INT
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
           B.BANKID,
           B.ORGANIZATION,
           B.DELETED_FL,
           B.CREATE_DT,
           B.UPDATE_DT,
           B.CREATEUSER,
           B.UPDATEUSER,
           B.BANK_NM,
           B.ACCOUNT_TXT      
      FROM STR_BANK B (NOLOCK)
     WHERE B.BANKID = @BankId     
       AND (@Organization IS NULL OR B.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
