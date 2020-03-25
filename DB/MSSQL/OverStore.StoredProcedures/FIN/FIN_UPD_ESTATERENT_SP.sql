-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_UPD_ESTATERENT_SP
    @EstateRentId              INT,
    @ContractDraftVersion      INT,
    @ContractFolder            BIGINT,
    @EstateAddress             VARCHAR(1000),
    @RentPurpose               VARCHAR(1000),
    @ContractStartDate         DATETIME,
    @ContractEndDate           DATETIME,
    @EstateName                VARCHAR(100),
    @Comment                   VARCHAR(1000),
    @Branch                    INT,
    @Deposit                   NUMERIC(22,6),
    @DepositCurrency           VARCHAR(3),
    @DepositDetails            VARCHAR(1000),
    @AdditionalDeposit         NUMERIC(22,6),
    @AdditionalDepositCurrency VARCHAR(3),
    @AgentFee                  NUMERIC(22,6),
    @AgentFeeCurrency          VARCHAR(3),
    @AgentFeeDetail            VARCHAR(1000),
    @KeyMoney                  NUMERIC(22,6),
    @KeyMoneyCurrency          VARCHAR(3),
    @KeyMoneyDetail            VARCHAR(1000),
    @NonrefundableCost         NUMERIC(22,6),
    @NonrefundableCurrency     VARCHAR(3),
    @NonrefundableCostDetail   VARCHAR(1000)
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
        NONREFUNDABLECOSTDETAIL_TXT
    )
    SELECT
        ESTATERENTID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE FIN_ESTATERENT
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           CONTRACTDRAFTVERSION = @ContractDraftVersion,
           CONTRACTFOLDER = @ContractFolder,
           ESTATE_ADR = @EstateAddress,
           RENTPURPOSE_TXT = @RentPurpose,
           START_DT = @ContractStartDate,
           END_DT = @ContractEndDate,
           ESTATE_NM = @EstateName,
           COMMENT_DSC = @Comment,
           BRANCH = @Branch,
           DEPOSIT_AMT = @Deposit,
           DEPOSITCURRENCY_TXT = @DepositCurrency,
           DEPOSITDETAIL_TXT = @DepositDetails,
           ADDDEPOSIT_AMT = @AdditionalDeposit,
           ADDDEPOSITCURRENCY_TXT = @AdditionalDepositCurrency,
           AGENTFEE_AMT = @AgentFee,
           AGENTFEECURRENCY_TXT = @AgentFeeCurrency,
           AGENTFEEDETAIL_TXT = @AgentFeeDetail,
           KEYMONEY_AMT = @KeyMoney,
           KEYMONEYCURRENCY_TXT = @KeyMoneyCurrency,
           KEYMONEYDETAIL_TXT = @KeyMoneyDetail,
           NONREFUNDABLECOST_AMT = @NonrefundableCost,
           NONREFUNDABLECOSTCURRENCY_TXT = @NonrefundableCurrency,
           NONREFUNDABLECOSTDETAIL_TXT = @NonrefundableCostDetail
     WHERE ESTATERENTID = @EstateRentId
       AND (@Organization IS NULL OR ORGANIZATION = @Organization);

    /*Section="Check"*/
    -- Check the updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing to update. Update failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;

/*Section="End"*/
END;
