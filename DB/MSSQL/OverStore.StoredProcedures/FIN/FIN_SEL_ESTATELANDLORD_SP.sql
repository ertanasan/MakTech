-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_SEL_ESTATELANDLORD_SP
    @EstateRent INT,
    @Landlord INT
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
           E.ESTATERENT,
           E.LANDLORD,
           E.CREATE_DT,
           E.CREATEUSER,
           E.CREATECHANNEL,
           E.CREATEBRANCH,
           E.CREATESCREEN,
           E.OWNERSHIP_RT,
           E.PAYMENT_RT,
           E.IBAN_TXT,
           ESTATERENT.ESTATERENTID "ESTATERENT.ESTATERENTID",
           LANDLORD.LANDLOARD_NM "LANDLORD.LANDLOARD_NM"
      FROM FIN_ESTATELANDLORD E (NOLOCK)
      JOIN FIN_ESTATERENT ESTATERENT (NOLOCK) ON E.ESTATERENT = ESTATERENT.ESTATERENTID AND (@Organization IS NULL OR ESTATERENT.ORGANIZATION = @Organization)
      JOIN FIN_LANDLORD LANDLORD (NOLOCK) ON E.LANDLORD = LANDLORD.LANDLORDID AND (@Organization IS NULL OR LANDLORD.ORGANIZATION = @Organization)
     WHERE E.ESTATERENT = @EstateRent
       AND E.LANDLORD = @Landlord;

/*Section="End"*/
END;
