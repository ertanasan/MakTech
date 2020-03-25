-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_INS_LANDLORD_SP
    @LandlordId          INT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO FIN_LANDLORD
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
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
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @LandlordName,
        @LandlordType,
        @LandlordAddress,
        @ContactInfo,
        @NationalId,
        @TaxpayerId,
        @TaxOffice,
        @LegalRepresentative,
        @AccountingCode
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
    SELECT @LandlordId = SCOPE_IDENTITY();

    /*Section="Log"*/
    -- Create log record
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
    VALUES
    (
        @LandlordId,
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        'INS',
        dbo.SYS_GETCURRENTCHANNEL_FN(),
        dbo.SYS_GETCURRENTBRANCH_FN(),
        dbo.SYS_GETCURRENTSCREEN_FN(),
        @LandlordName,
        @LandlordType,
        @LandlordAddress,
        @ContactInfo,
        @NationalId,
        @TaxpayerId,
        @TaxOffice,
        @LegalRepresentative,
        @AccountingCode);
/*Section="End"*/
END;
