-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_LST_ESTATELANDLORD_SP
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

    /*Section="Parameter Check"*/
    -- Check the parameter values
    IF @EstateRent IS NULL AND @Landlord IS NULL
    BEGIN
        DECLARE @ErrorMessage VARCHAR(250);
        SET @ErrorMessage='At least one parameter should not be null.';
        THROW 100002, @ErrorMessage, 1;
        RETURN;
    END

    /*Section="Query"*/
    -- Select all
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
     WHERE (@EstateRent IS NULL OR E.ESTATERENT = @EstateRent)
       AND (@Landlord IS NULL OR E.LANDLORD = @Landlord);

/*Section="End"*/
END;
