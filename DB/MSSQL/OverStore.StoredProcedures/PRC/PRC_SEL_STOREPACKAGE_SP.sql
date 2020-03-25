-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_SEL_STOREPACKAGE_SP
    @StorePackageId INT
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
           S.STOREPACKAGEID,
           S.ORGANIZATION,
           S.DELETED_FL,
           S.CREATE_DT,
           S.UPDATE_DT,
           S.CREATEUSER,
           S.UPDATEUSER,
           S.STORE,
           S.PACKAGE,
           S.PRIORITY_NO,
           S.ISCURRENT_FL,
           S.CURRENTVERSION,
           S.START_TM,
           S.END_TM      
      FROM PRC_STOREPACKAGE S (NOLOCK)
     WHERE S.STOREPACKAGEID = @StorePackageId     
       AND (@Organization IS NULL OR S.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
