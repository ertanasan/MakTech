-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_REQUEST_SP
    @HelpdeskRequestId BIGINT
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
           R.REQUESTID,
           R.EVENT,
           R.ORGANIZATION,
           R.DELETED_FL,
           R.CREATE_DT,
           R.UPDATE_DT,
           R.CREATEUSER,
           R.UPDATEUSER,
           R.CREATECHANNEL,
           R.CREATEBRANCH,
           R.CREATESCREEN,
           R.REQUESTDEFINITION,
           R.REQUEST_DSC,
           R.STATUS_CD,
           R.PROCESSINSTANCE_LNO,
           R.STORE,
           R.REDIRECTIONGROUP,
           RD.REQUESTGROUP,
           R.PHONENUMBER_TXT,
           R.RESPONSIBLEUSER
      FROM HDK_REQUEST R (NOLOCK)
	  JOIN HDK_REQUESTDEF RD (NOLOCK) ON R.REQUESTDEFINITION = RD.REQUESTDEFID
     WHERE R.REQUESTID = @HelpdeskRequestId
       AND (@Organization IS NULL OR R.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
