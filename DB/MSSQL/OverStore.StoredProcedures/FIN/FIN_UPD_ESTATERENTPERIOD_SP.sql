-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_UPD_ESTATERENTPERIOD_SP
    @EstateRentPeriodId     INT,
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
    /*Section="Log"*/
    -- Create log
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
    SELECT
        ESTATERENTPERIODID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
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
      FROM
        FIN_ESTATERENTPERIOD E (NOLOCK)
     WHERE
        E.ESTATERENTPERIODID = @EstateRentPeriodId;
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
    UPDATE FIN_ESTATERENTPERIOD
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           ESTATERENT = @EstateRent,
           PERIODORDER_NO = @PeriodOrder,
           START_DT = @PeriodStartDate,
           END_DT = @PeriodEndDate,
           CONTRACTRENT_AMT = @ContractRentAmount,
           CONTRACTRENTCURRENCY_TXT = @ContractRentCurrency,
           ADDITIONALRENT_AMT = @AdditionalRentAmount,
           ADDRENTCURRENCY_TXT = @AdditionalRentCurrency,
           PLANNEDRENTRAISE_TXT = @PlannedRentRaise,
           NEGOTIATION_DT = @NegotiationDate,
           COMMENT_DSC = @Comment
     WHERE ESTATERENTPERIODID = @EstateRentPeriodId
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
