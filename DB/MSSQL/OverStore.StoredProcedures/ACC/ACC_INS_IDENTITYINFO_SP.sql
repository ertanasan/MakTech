-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_INS_IDENTITYINFO_SP
    @IdentityInfoId INT OUT,
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
    /*Section="Insert"*/
    SET NOCOUNT OFF
    -- Insert record
    INSERT INTO ACC_IDENTITYINFO
    (
        ORGANIZATION,
        DELETED_FL,
        CREATE_DT,
        CREATEUSER,
        IDENTITYNO_TXT,
        IDENTITY_NM,
        TAXCENTERCODE_TXT,
        TAXCENTER_NM,
        ACTIVESTATUS_TXT,
        COMPANYTYPE_TXT,
        FATHER_NM,
        IDENTITYTYPE_TXT,
        PROFESSIONCODE_TXT,
        PROFESSION_DSC,
        ADDRESS_TXT
    )
    VALUES
    (
        dbo.SYS_GETCURRENTORGANIZATION_FN(),
        'N',
        GETDATE(),
        dbo.SYS_GETCURRENTUSER_FN(),
        @IdentityNo,
        @IdentityName,
        @TaxCenterCode,
        @TaxCenterName,
        @ActiveStatus,
        @CompanyType,
        @FatherName,
        @IdentityType,
        @ProfessionCode,
        @Profession,
        @Address
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
    SELECT @IdentityInfoId = SCOPE_IDENTITY();
/*Section="End"*/
END;
