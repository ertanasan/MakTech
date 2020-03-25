-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_INS_ESTATERENTPERIOD_SP
    @EstateRentPeriodId     INT OUT,
    @EstateRent             INT,
    @PeriodOrder            INT,
    @PeriodStartDate        DATETIME,
    @PeriodEndDate          DATETIME,
    @ContractRentAmount     NUMERIC(22,6),
    @ContractRentCurrency   VARCHAR(3),
    @AdditionalRentAmount   NUMERIC(22,6),
    @AdditionalRentCurrency VARCHAR(3),
    @PlannedRentRaise       VARCHAR(1000),
    @NegotiationDate        DATETIME,
    @Comment                VARCHAR(1000)
AS
BEGIN
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO FIN_ESTATERENTPERIOD
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        ESTATERENT,
        PERIODORDER_NO,
        START_DT,
        END_DT,
        CONTRACTRENT_AMT,
        CONTRACTRENTCURRENCY_TXT,
        ADDITIONALRENT_AMT,
        ADDRENTCURRENCY_TXT,
        PLANNEDRENTRAISE_TXT,
        NEGOTIATION_DT,
        COMMENT_DSC
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @EstateRent,
        @PeriodOrder,
        @PeriodStartDate,
        @PeriodEndDate,
        @ContractRentAmount,
        @ContractRentCurrency,
        @AdditionalRentAmount,
        @AdditionalRentCurrency,
        @PlannedRentRaise,
        @NegotiationDate,
        @Comment
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
    SELECT @EstateRentPeriodId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
    INSERT INTO FIN_ESTATERENTPERIODLOG
    (
        ESTATERENTPERIODID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        ESTATERENT,
        PERIODORDER_NO,
        START_DT,
        END_DT,
        CONTRACTRENT_AMT,
        CONTRACTRENTCURRENCY_TXT,
        ADDITIONALRENT_AMT,
        ADDRENTCURRENCY_TXT,
        PLANNEDRENTRAISE_TXT,
        NEGOTIATION_DT,
        COMMENT_DSC
    )
    VALUES
    (
        @EstateRentPeriodId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @EstateRent,
        @PeriodOrder,
        @PeriodStartDate,
        @PeriodEndDate,
        @ContractRentAmount,
        @ContractRentCurrency,
        @AdditionalRentAmount,
        @AdditionalRentCurrency,
        @PlannedRentRaise,
        @NegotiationDate,
        @Comment);
/*Section="End"*/
END;
