-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_SEL_ESTATERENT_SP
    @EstateRentId INT
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
           E.ESTATERENTID,
           E.ORGANIZATION,
           E.DELETED_FL,
           E.CREATE_DT,
           E.UPDATE_DT,
           E.CREATEUSER,
           E.UPDATEUSER,
           E.CONTRACTDRAFTVERSION,
           E.CONTRACTFOLDER,
           E.ESTATE_ADR,
           E.RENTPURPOSE_TXT,
           E.START_DT,
           E.END_DT,
           E.ESTATE_NM,
           E.COMMENT_DSC,
           E.BRANCH,
           E.DEPOSIT_AMT,
           E.DEPOSITCURRENCY_TXT,
           E.DEPOSITDETAIL_TXT,
           E.ADDDEPOSIT_AMT,
           E.ADDDEPOSITCURRENCY_TXT,
           E.AGENTFEE_AMT,
           E.AGENTFEECURRENCY_TXT,
           E.AGENTFEEDETAIL_TXT,
           E.KEYMONEY_AMT,
           E.KEYMONEYCURRENCY_TXT,
           E.KEYMONEYDETAIL_TXT,
           E.NONREFUNDABLECOST_AMT,
           E.NONREFUNDABLECOSTCURRENCY_TXT,
           E.NONREFUNDABLECOSTDETAIL_TXT
      FROM FIN_ESTATERENT E (NOLOCK)
     WHERE E.ESTATERENTID = @EstateRentId
       AND (@Organization IS NULL OR E.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
