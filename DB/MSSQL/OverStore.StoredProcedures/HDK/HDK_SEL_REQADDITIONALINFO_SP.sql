-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_REQADDITIONALINFO_SP
    @RequestAdditionalInfoId BIGINT
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
           R.REQADDITIONALINFOID,
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
           R.REQUEST,
           R.COST_AMT,
           R.WARRANTYDUE_DT,
           R.FOLDER      
      FROM HDK_REQADDITIONALINFO R (NOLOCK)
     WHERE R.REQADDITIONALINFOID = @RequestAdditionalInfoId     
       AND (@Organization IS NULL OR R.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
