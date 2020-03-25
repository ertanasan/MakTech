-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_SEL_PACKAGEPROMOTION_SP
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

    /*Section="Query"*/
    -- Select
    SELECT
           P.PACKAGE,
           P.PROMOTIONTYPE,
           P.CREATE_DT,
           P.CREATEUSER,
           P.CREATECHANNEL,
           P.CREATEBRANCH,
           P.CREATESCREEN,
           PACKAGE.PACKAGE_NM "PACKAGE.PACKAGE_NM",
           PROMOTIONTYPE.PROMOTIONTYPE_NM "PROMOTIONTYPE.PROMOTIONTYPE_NM"
      FROM PRC_PACKAGEPROMOTION P (NOLOCK)
      JOIN PRC_PACKAGE PACKAGE (NOLOCK) ON P.PACKAGE = PACKAGE.PACKAGEID AND (@Organization IS NULL OR PACKAGE.ORGANIZATION = @Organization)
      JOIN PRC_PROMOTIONTYPE PROMOTIONTYPE (NOLOCK) ON P.PROMOTIONTYPE = PROMOTIONTYPE.PROMOTIONTYPEID
     WHERE P.PACKAGE = @Package
       AND P.PROMOTIONTYPE = @PromotionType;

/*Section="End"*/
END;
