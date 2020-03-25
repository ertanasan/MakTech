-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE STR_SEL_WORKINGHOURS_SP
    @WorkingHoursId BIGINT
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
     WHERE W.WORKINGHOURSID = @WorkingHoursId
       AND (@Organization IS NULL OR W.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
