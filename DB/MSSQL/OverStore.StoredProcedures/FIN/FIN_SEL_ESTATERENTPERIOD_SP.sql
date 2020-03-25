-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_SEL_ESTATERENTPERIOD_SP
    @EstateRentPeriodId INT
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
           E.ESTATERENTPERIODID,
           E.ORGANIZATION,
           E.DELETED_FL,
           E.CREATE_DT,
           E.UPDATE_DT,
           E.CREATEUSER,
           E.UPDATEUSER,
           E.ESTATERENT,
           E.PERIODORDER_NO,
           E.START_DT,
           E.END_DT,
           E.CONTRACTRENT_AMT,
           E.CONTRACTRENTCURRENCY_TXT,
           E.ADDITIONALRENT_AMT,
           E.ADDRENTCURRENCY_TXT,
           E.PLANNEDRENTRAISE_TXT,
           E.NEGOTIATION_DT,
           E.COMMENT_DSC
      FROM FIN_ESTATERENTPERIOD E (NOLOCK)
     WHERE E.ESTATERENTPERIODID = @EstateRentPeriodId
       AND (@Organization IS NULL OR E.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
