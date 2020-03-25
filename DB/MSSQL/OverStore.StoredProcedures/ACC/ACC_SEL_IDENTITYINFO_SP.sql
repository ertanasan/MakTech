-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_IDENTITYINFO_SP
    @IdentityInfoId INT
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
           I.IDENTITYINFOID,
           I.ORGANIZATION,
           I.DELETED_FL,
           I.CREATE_DT,
           I.UPDATE_DT,
           I.CREATEUSER,
           I.UPDATEUSER,
           I.IDENTITYNO_TXT,
           I.IDENTITY_NM,
           I.TAXCENTERCODE_TXT,
           I.TAXCENTER_NM,
           I.ACTIVESTATUS_TXT,
           I.COMPANYTYPE_TXT,
           I.FATHER_NM,
           I.IDENTITYTYPE_TXT,
           I.PROFESSIONCODE_TXT,
           I.PROFESSION_DSC,
           I.ADDRESS_TXT      
      FROM ACC_IDENTITYINFO I (NOLOCK)
     WHERE I.IDENTITYINFOID = @IdentityInfoId     
       AND (@Organization IS NULL OR I.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
