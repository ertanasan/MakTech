-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_DEL_LANDLORD_SP
    @LandlordId INT
AS
BEGIN
    /*Section="Log"*/
    -- Create log
    INSERT INTO FIN_LANDLORDLOG
    (
        LANDLORDID,
        LOG_DT,
        LOGUSER,
        LOGOPERATION_CD,
        LOGCHANNEL,
        LOGBRANCH,
        LOGSCREEN,
        LANDLOARD_NM,
        LANDLORDTYPE_CD,
        LANDLORD_ADR,
        CONTACT_TXT,
        NATIONALID_TXT,
        TAXPAYERID_TXT,
        TAXOFFICE_TXT,
        LEGALREPRESENTATIVE,
        ACCOUNTINGCODE_TXT    )    
    SELECT
        LANDLORDID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'DEL',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        LANDLOARD_NM,
        LANDLORDTYPE_CD,
        LANDLORD_ADR,
        CONTACT_TXT,
        NATIONALID_TXT,
        TAXPAYERID_TXT,
        TAXOFFICE_TXT,
        LEGALREPRESENTATIVE,
        ACCOUNTINGCODE_TXT
      FROM
        FIN_LANDLORD L (NOLOCK)
     WHERE
        L.LANDLORDID = @LandlordId;
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
    UPDATE FIN_LANDLORD
       SET DELETED_FL = 'Y',
           UPDATE_DT = GETDATE(),
           LANDLOARD_NM = LEFT(LANDLOARD_NM, 99 - LEN(CONVERT(VARCHAR(20), LANDLORDID))) + '#' + CONVERT(VARCHAR(20), LANDLORDID)
     WHERE LANDLORDID = @LandlordId
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
