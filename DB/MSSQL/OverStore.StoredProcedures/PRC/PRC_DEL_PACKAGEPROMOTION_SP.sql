-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_DEL_PACKAGEPROMOTION_SP
    @Package INT,
    @PromotionType INT
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
    DELETE PRC_PACKAGEPROMOTION
      FROM PRC_PACKAGEPROMOTION (NOLOCK)
      JOIN PRC_PACKAGE PACKAGE (NOLOCK) ON PRC_PACKAGEPROMOTION.PACKAGE = PACKAGE.PACKAGEID AND (@Organization IS NULL OR PACKAGE.ORGANIZATION = @Organization)
      JOIN PRC_PROMOTIONTYPE PROMOTIONTYPE (NOLOCK) ON PRC_PACKAGEPROMOTION.PROMOTIONTYPE = PROMOTIONTYPE.PROMOTIONTYPEID
     WHERE PRC_PACKAGEPROMOTION.PACKAGE = @Package
       AND PRC_PACKAGEPROMOTION.PROMOTIONTYPE = @PromotionType;

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
