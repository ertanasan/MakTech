-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_REQUESTDETAIL_SP
    @RequestDetailId BIGINT
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
           R.REQUESTDETAILID,
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
           R.ATTRIBUTE,
           R.ATTRIBUTEVALUE_TXT      
      FROM HDK_REQUESTDETAIL R (NOLOCK)
     WHERE R.REQUESTDETAILID = @RequestDetailId     
       AND (@Organization IS NULL OR R.ORGANIZATION = @Organization);

    /*Section="End"*/
END;
