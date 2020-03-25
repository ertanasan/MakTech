-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_LST_WORKINGHOURS_SP
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
           W.WORKINGHOURSID,
           W.EVENT,
           W.ORGANIZATION,
           W.DELETED_FL,
           W.CREATE_DT,
           W.UPDATE_DT,
           W.CREATEUSER,
           W.UPDATEUSER,
           W.CREATECHANNEL,
           W.CREATEBRANCH,
           W.CREATESCREEN,
           W.STORECODE_TXT,
           W.STORE_NM,
           W.OPENING_TM,
           W.CLOSING_TM,
           W.OPENGUSER_NM,
           W.CLOSEUSER_NM,
           W.STORE,
           W.OPENUSER,
           W.CLOSEUSER,
           W.NOTE_DSC
      FROM STR_WORKINGHOURS W (NOLOCK)
     WHERE (@Organization IS NULL OR W.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY WORKINGHOURSID;

/*Section="End"*/
END;
