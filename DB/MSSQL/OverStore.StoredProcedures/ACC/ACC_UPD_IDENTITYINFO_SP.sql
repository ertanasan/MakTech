-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_IDENTITYINFO_SP
    @IdentityInfoId INT,
    @IdentityNo     VARCHAR(30),
    @IdentityName   VARCHAR(100),
    @TaxCenterCode  VARCHAR(30),
    @TaxCenterName  VARCHAR(100),
    @ActiveStatus   VARCHAR(10),
    @CompanyType    VARCHAR(30),
    @FatherName     VARCHAR(30),
    @IdentityType   VARCHAR(15),
    @ProfessionCode VARCHAR(15),
    @Profession     VARCHAR(1000),
    @Address        VARCHAR(1000)
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

    /*Section="Update"*/
    SET NOCOUNT OFF;
    -- Update record
    UPDATE ACC_IDENTITYINFO
       SET
           UPDATE_DT = GETDATE(),
           UPDATEUSER = dbo.SYS_GETCURRENTUSER_FN(),
           IDENTITYNO_TXT = @IdentityNo,
           IDENTITY_NM = @IdentityName,
           TAXCENTERCODE_TXT = @TaxCenterCode,
           TAXCENTER_NM = @TaxCenterName,
           ACTIVESTATUS_TXT = @ActiveStatus,
           COMPANYTYPE_TXT = @CompanyType,
           FATHER_NM = @FatherName,
           IDENTITYTYPE_TXT = @IdentityType,
           PROFESSIONCODE_TXT = @ProfessionCode,
           PROFESSION_DSC = @Profession,
           ADDRESS_TXT = @Address
     WHERE IDENTITYINFOID = @IdentityInfoId     
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
