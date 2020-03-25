-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_INTAKESTATUS_SP
    @IntakeStatusId BIGINT
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
           I.INTAKESTATUSID,
           I.EVENT,
           I.ORGANIZATION,
           I.DELETED_FL,
           I.CREATE_DT,
           I.UPDATE_DT,
           I.CREATEUSER,
           I.UPDATEUSER,
           I.CREATECHANNEL,
           I.CREATEBRANCH,
           I.CREATESCREEN,
           I.STOREORDERDETAIL,
           I.INTAKESTATUSTYPE,
           I.DESCRIPTION_DSC,
           I.MIKROTRANSFER_FL,
           I.MIKROTRANSFER_TM,
           I.QUANTITYDIF_QTY
      FROM WHS_INTAKESTATUS I (NOLOCK)
     WHERE I.INTAKESTATUSID = @IntakeStatusId
       AND (@Organization IS NULL OR I.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
