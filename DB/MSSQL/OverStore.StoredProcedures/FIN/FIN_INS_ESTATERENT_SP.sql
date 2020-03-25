-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_INS_ESTATERENT_SP
    @EstateRentId              INT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO FIN_ESTATERENT
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
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
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @ContractDraftVersion,
        @ContractFolder,
        @EstateAddress,
        @RentPurpose,
        @ContractStartDate,
        @ContractEndDate,
        @EstateName,
        @Comment,
        @Branch,
        @Deposit,
        @DepositCurrency,
        @DepositDetails,
        @AdditionalDeposit,
        @AdditionalDepositCurrency,
        @AgentFee,
        @AgentFeeCurrency,
        @AgentFeeDetail,
        @KeyMoney,
        @KeyMoneyCurrency,
        @KeyMoneyDetail,
        @NonrefundableCost,
        @NonrefundableCurrency,
        @NonrefundableCostDetail
    );

    /*Section="Check"*/
    -- Check the inserted row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing inserted. Transaction failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
    SELECT @EstateRentId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @EstateRentId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @ContractDraftVersion,
        @ContractFolder,
        @EstateAddress,
        @RentPurpose,
        @ContractStartDate,
        @ContractEndDate,
        @EstateName,
        @Comment,
        @Branch,
        @Deposit,
        @DepositCurrency,
        @DepositDetails,
        @AdditionalDeposit,
        @AdditionalDepositCurrency,
        @AgentFee,
        @AgentFeeCurrency,
        @AgentFeeDetail,
        @KeyMoney,
        @KeyMoneyCurrency,
        @KeyMoneyDetail,
        @NonrefundableCost,
        @NonrefundableCurrency,
        @NonrefundableCostDetail);
/*Section="End"*/
END;
