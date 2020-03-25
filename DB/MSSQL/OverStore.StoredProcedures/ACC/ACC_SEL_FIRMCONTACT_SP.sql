-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_SEL_FIRMCONTACT_SP
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

    /*Section="Query"*/
    -- Select
    SELECT
           F.FIRM,
           F.CONTACT,
           F.CREATE_DT,
           F.CREATEUSER,
           F.CREATECHANNEL,
           F.CREATEBRANCH,
           F.CREATESCREEN,
           F.ISDEFAULT_FL,
           F.ISACTIVE_FL,
           F.ISPREFERRED_FL,
           FIRM.FIRM_NM "FIRM.FIRM_NM",
           CONTACT.CONTACTID "CONTACT.CONTACTID"
      FROM ACC_FIRMCONTACT F (NOLOCK)
      JOIN ACC_FIRM FIRM (NOLOCK) ON F.FIRM = FIRM.FIRMID AND (@Organization IS NULL OR FIRM.ORGANIZATION = @Organization)
      JOIN CNT_CONTACT CONTACT (NOLOCK) ON F.CONTACT = CONTACT.CONTACTID AND (@Organization IS NULL OR CONTACT.ORGANIZATION = @Organization)
     WHERE F.FIRM = @Firm
       AND F.CONTACT = @Contact;

/*Section="End"*/
END;
