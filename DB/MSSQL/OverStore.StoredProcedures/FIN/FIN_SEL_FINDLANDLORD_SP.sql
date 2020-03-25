-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_SEL_FINDLANDLORD_SP
    @LandlordName VARCHAR(100)
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
           L.LANDLORDID,
           L.ORGANIZATION,
           L.DELETED_FL,
           L.CREATE_DT,
           L.UPDATE_DT,
           L.CREATEUSER,
           L.UPDATEUSER,
           L.LANDLOARD_NM,
           L.LANDLORDTYPE_CD,
           L.LANDLORD_ADR,
           L.CONTACT_TXT,
           L.NATIONALID_TXT,
           L.TAXPAYERID_TXT,
           L.TAXOFFICE_TXT,
           L.LEGALREPRESENTATIVE,
           L.ACCOUNTINGCODE_TXT      
      FROM FIN_LANDLORD L (NOLOCK)
     WHERE L.LANDLOARD_NM = @LandlordName
       AND (@Organization IS NULL OR L.ORGANIZATION = @Organization);

/*Section="End"*/
END;
