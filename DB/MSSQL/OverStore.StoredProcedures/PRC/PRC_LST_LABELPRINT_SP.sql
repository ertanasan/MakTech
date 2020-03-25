-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE PRC_LST_LABELPRINT_SP
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
           L.LABELPRINTID,
           L.EVENT,
           L.ORGANIZATION,
           L.DELETED_FL,
           L.CREATE_DT,
           L.UPDATE_DT,
           L.CREATEUSER,
           L.UPDATEUSER,
           L.CREATECHANNEL,
           L.CREATEBRANCH,
           L.CREATESCREEN,
           L.PRODUCT,
           L.CURRENTPRICE,
           L.LABELSIZE_TXT
      FROM PRC_LABELPRINT L (NOLOCK)
     WHERE (@Organization IS NULL OR L.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY LABELPRINTID;

/*Section="End"*/
END;
