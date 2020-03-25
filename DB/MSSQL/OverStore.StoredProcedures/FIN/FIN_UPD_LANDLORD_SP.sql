-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_UPD_LANDLORD_SP
    @LandlordId          INT,
    @LandlordName        VARCHAR(100),
    @LandlordType        INT,
    @LandlordAddress     VARCHAR(1000),
    @ContactInfo         VARCHAR(1000),
    @NationalId          VARCHAR(20),
    @TaxpayerId          VARCHAR(20),
    @TaxOffice           VARCHAR(100),
    @LegalRepresentative INT,
    @AccountingCode      VARCHAR(50)
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
        ACCOUNTINGCODE_TXT
    )    
    SELECT
        LANDLORDID,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'UPD',
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE FIN_LANDLORD
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           LANDLOARD_NM = @LandlordName,
           LANDLORDTYPE_CD = @LandlordType,
           LANDLORD_ADR = @LandlordAddress,
           CONTACT_TXT = @ContactInfo,
           NATIONALID_TXT = @NationalId,
           TAXPAYERID_TXT = @TaxpayerId,
           TAXOFFICE_TXT = @TaxOffice,
           LEGALREPRESENTATIVE = @LegalRepresentative,
           ACCOUNTINGCODE_TXT = @AccountingCode
     WHERE LANDLORDID = @LandlordId     
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
