-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_UPD_FIRMCONTACT_SP
    @Firm        INT,
    @Contact     INT,
    @IsDefault   VARCHAR(1),
    @IsActive    VARCHAR(1),
    @IsPreferred VARCHAR(1)
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
    UPDATE ACC_FIRMCONTACT
       SET
           ACC_FIRMCONTACT.ISDEFAULT_FL = @IsDefault,
           ACC_FIRMCONTACT.ISACTIVE_FL = @IsActive,
           ACC_FIRMCONTACT.ISPREFERRED_FL = @IsPreferred
      FROM ACC_FIRMCONTACT (NOLOCK)
      JOIN ACC_FIRM FIRM (NOLOCK) ON ACC_FIRMCONTACT.FIRM = FIRM.FIRMID AND (@Organization IS NULL OR FIRM.ORGANIZATION = @Organization)
      JOIN CNT_CONTACT CONTACT (NOLOCK) ON ACC_FIRMCONTACT.CONTACT = CONTACT.CONTACTID AND (@Organization IS NULL OR CONTACT.ORGANIZATION = @Organization)
     WHERE ACC_FIRMCONTACT.FIRM = @Firm
       AND ACC_FIRMCONTACT.CONTACT = @Contact;

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
