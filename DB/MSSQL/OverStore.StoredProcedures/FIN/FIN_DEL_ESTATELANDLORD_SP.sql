-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_DEL_ESTATELANDLORD_SP
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

    /*Section="Delete"*/
    SET NOCOUNT OFF;
    -- Perform deletion
    DELETE FIN_ESTATELANDLORD
      FROM FIN_ESTATELANDLORD (NOLOCK)
      JOIN FIN_ESTATERENT ESTATERENT (NOLOCK) ON FIN_ESTATELANDLORD.ESTATERENT = ESTATERENT.ESTATERENTID AND (@Organization IS NULL OR ESTATERENT.ORGANIZATION = @Organization)
      JOIN FIN_LANDLORD LANDLORD (NOLOCK) ON FIN_ESTATELANDLORD.LANDLORD = LANDLORD.LANDLORDID AND (@Organization IS NULL OR LANDLORD.ORGANIZATION = @Organization)
     WHERE FIN_ESTATELANDLORD.ESTATERENT = @EstateRent
       AND FIN_ESTATELANDLORD.LANDLORD = @Landlord;

    /*Section="Check"*/
    -- Check the deleted/updated row count
    IF @@ROWCOUNT = 0
    BEGIN
        SET NOCOUNT ON;
        THROW 100001, 'Nothing deleted. Delete failed.', 1;
        RETURN;
    END;
    SET NOCOUNT ON;
END;
