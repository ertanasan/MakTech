-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_LST_PACKAGEVERSION_SP
    @Package INT = NULL
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
    -- Select all
    SELECT
           P.PACKAGEVERSIONID,
           P.ORGANIZATION,
           P.DELETED_FL,
           P.CREATE_DT,
           P.UPDATE_DT,
           P.CREATEUSER,
           P.UPDATEUSER,
           P.PACKAGE,
           P.VERSION_DT,
           P.ACTIVE_FL,
           P.COMMENT_DSC,
           P.ACTIVATION_TM
      FROM PRC_PACKAGEVERSION P (NOLOCK)
     WHERE (@Package IS NULL OR P.PACKAGE = @Package)
       AND (@Organization IS NULL OR P.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY VERSION_DT DESC;

/*Section="End"*/
END;
