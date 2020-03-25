-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_UPD_ESTATELANDLORD_SP
    @EstateRent    INT,
    @Landlord      INT,
    @OwnershipRate NUMERIC(5,2),
    @PaymentRate   NUMERIC(5,2),
    @IBAN          VARCHAR(50)
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
    UPDATE FIN_ESTATELANDLORD
       SET
           FIN_ESTATELANDLORD.OWNERSHIP_RT = @OwnershipRate,
           FIN_ESTATELANDLORD.PAYMENT_RT = @PaymentRate,
           FIN_ESTATELANDLORD.IBAN_TXT = @IBAN
      FROM FIN_ESTATELANDLORD (NOLOCK)
      JOIN FIN_ESTATERENT ESTATERENT (NOLOCK) ON FIN_ESTATELANDLORD.ESTATERENT = ESTATERENT.ESTATERENTID AND (@Organization IS NULL OR ESTATERENT.ORGANIZATION = @Organization)
      JOIN FIN_LANDLORD LANDLORD (NOLOCK) ON FIN_ESTATELANDLORD.LANDLORD = LANDLORD.LANDLORDID AND (@Organization IS NULL OR LANDLORD.ORGANIZATION = @Organization)
     WHERE FIN_ESTATELANDLORD.ESTATERENT = @EstateRent
       AND FIN_ESTATELANDLORD.LANDLORD = @Landlord;

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
