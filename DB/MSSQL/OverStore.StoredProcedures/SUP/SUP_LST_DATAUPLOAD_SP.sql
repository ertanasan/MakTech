-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SUP_LST_DATAUPLOAD_SP
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
           D.DATAUPLOADID,
           D.ORGANIZATION,
           D.EVENT,
           D.DELETED_FL,
           D.CREATE_DT,
           D.UPDATE_DT,
           D.CREATEUSER,
           D.UPDATEUSER,
           D.CREATECHANNEL,
           D.CREATEBRANCH,
           D.CREATESCREEN,
           D.TYPE,
           D.STATUS,
           D.DOCUMENT,
           D.UPLOAD_DT,
           D.PROCESS_DT,
           D.SOURCE_REF
      FROM SUP_DATAUPLOAD D (NOLOCK)
     WHERE (@Organization IS NULL OR D.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N';

/*Section="End"*/
END;
