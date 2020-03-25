-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_DEL_ESTATERENTPERIOD_SP
    @EstateRentPeriodId INT
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
        COMMENT_DSC    )
    SELECT
        ESTATERENTPERIODID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
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

    /*Section="Delete"*/
    SET NOCOUNT OFF
    -- Update the DELETED_FL to 'Y'
    UPDATE FIN_ESTATERENTPERIOD
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE()
     WHERE ESTATERENTPERIODID = @EstateRentPeriodId
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
