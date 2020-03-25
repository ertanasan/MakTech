-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_DEL_FIRMCONTACT_SP
    @Firm INT,
    @Contact INT
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
    DELETE ACC_FIRMCONTACT
      FROM ACC_FIRMCONTACT (NOLOCK)
      JOIN ACC_FIRM FIRM (NOLOCK) ON ACC_FIRMCONTACT.FIRM = FIRM.FIRMID AND (@Organization IS NULL OR FIRM.ORGANIZATION = @Organization)
      JOIN CNT_CONTACT CONTACT (NOLOCK) ON ACC_FIRMCONTACT.CONTACT = CONTACT.CONTACTID AND (@Organization IS NULL OR CONTACT.ORGANIZATION = @Organization)
     WHERE ACC_FIRMCONTACT.FIRM = @Firm
       AND ACC_FIRMCONTACT.CONTACT = @Contact;

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
