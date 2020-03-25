-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_DEL_ESTATERENT_SP
    @EstateRentId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO FIN_ESTATERENTLOG
    (
        ESTATERENTID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        CONTRACTDRAFTVERSION,
        CONTRACTFOLDER,
        ESTATE_ADR,
        RENTPURPOSE_TXT,
        START_DT,
        END_DT,
        ESTATE_NM,
        COMMENT_DSC,
        BRANCH,
        DEPOSIT_AMT,
        DEPOSITCURRENCY_TXT,
        DEPOSITDETAIL_TXT,
        ADDDEPOSIT_AMT,
        ADDDEPOSITCURRENCY_TXT,
        AGENTFEE_AMT,
        AGENTFEECURRENCY_TXT,
        AGENTFEEDETAIL_TXT,
        KEYMONEY_AMT,
        KEYMONEYCURRENCY_TXT,
        KEYMONEYDETAIL_TXT,
        NONREFUNDABLECOST_AMT,
        NONREFUNDABLECOSTCURRENCY_TXT,
        NONREFUNDABLECOSTDETAIL_TXT    )
    SELECT
        ESTATERENTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        CONTRACTDRAFTVERSION,
        CONTRACTFOLDER,
        ESTATE_ADR,
        RENTPURPOSE_TXT,
        START_DT,
        END_DT,
        ESTATE_NM,
        COMMENT_DSC,
        BRANCH,
        DEPOSIT_AMT,
        DEPOSITCURRENCY_TXT,
        DEPOSITDETAIL_TXT,
        ADDDEPOSIT_AMT,
        ADDDEPOSITCURRENCY_TXT,
        AGENTFEE_AMT,
        AGENTFEECURRENCY_TXT,
        AGENTFEEDETAIL_TXT,
        KEYMONEY_AMT,
        KEYMONEYCURRENCY_TXT,
        KEYMONEYDETAIL_TXT,
        NONREFUNDABLECOST_AMT,
        NONREFUNDABLECOSTCURRENCY_TXT,
        NONREFUNDABLECOSTDETAIL_TXT
      FROM
        FIN_ESTATERENT E (NOLOCK)
     WHERE
        E.ESTATERENTID = @EstateRentId;
    /*Section="Organization"*/
    -- Get the caller organization from session context
    DECLARE @Organization INT;
    SELECT @Organization = dbo.SYS_GETCURRENTORGANIZATION_FN();
    IF dbo.SYS_ISSYSTEMORGANIZATION_FN() = 1
    BEGIN
      -- Current organization is system. This is a batch or system process.
      SET @Organization = null;
    END

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE FIN_ESTATERENT
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE ESTATERENTID = @EstateRentId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
