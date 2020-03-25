-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_REQUESTDETAIL_SP
    @Request BIGINT = NULL
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
           R.ATTRIBUTEVALUE_TXT,
		   A.DISPLAYORDER_NO,
		   ATTYPE.ATTRIBUTETYPE_NM
      FROM HDK_REQUESTDETAIL R (NOLOCK)
	  JOIN HDK_ATTRIBUTE A (NOLOCK) ON R.ATTRIBUTE = A.ATTRIBUTEID
	  JOIN HDK_ATTRIBUTETYPE ATTYPE (NOLOCK) ON A.ATTRIBUTETYPE = ATTYPE.ATTRIBUTETYPEID
     WHERE (@Request IS NULL OR R.REQUEST = @Request)
       AND (@Organization IS NULL OR R.ORGANIZATION = @Organization)
       AND DELETED_FL = 'N'
     ORDER BY A.DISPLAYORDER_NO;

/*Section="End"*/
END;
