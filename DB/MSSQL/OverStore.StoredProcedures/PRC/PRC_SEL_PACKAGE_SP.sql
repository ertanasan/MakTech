-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_SEL_PACKAGE_SP
    @PackageId INT
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
           P.PACKAGEID,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.PACKAGE_NM,
           P.TYPE,
           P.COMMENT_DSC,
           P.IMAGE
      FROM PRC_PACKAGE P (NOLOCK)
     WHERE P.PACKAGEID = @PackageId
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
