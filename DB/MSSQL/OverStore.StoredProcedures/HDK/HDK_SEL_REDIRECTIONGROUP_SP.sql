-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_REDIRECTIONGROUP_SP
    @RedirectionGroupId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           R.REDIRECTIONGROUPID,
           R.GROUP_NM,
           R.REQUESTDEFINITION      
      FROM HDK_REDIRECTIONGROUP R (NOLOCK)
     WHERE R.REDIRECTIONGROUPID = @RedirectionGroupId;

    /*Section="End"*/
END;
