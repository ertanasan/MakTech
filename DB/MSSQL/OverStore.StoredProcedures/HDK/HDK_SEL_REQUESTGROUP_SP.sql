-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_REQUESTGROUP_SP
    @RequestGroupId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           R.REQUESTGROUPID,
           R.REQUESTGROUP_NM,
           R.DISPLAYORDER_NO,
           R.ACTIVE_FL
      FROM HDK_REQUESTGROUP R (NOLOCK)
     WHERE R.REQUESTGROUPID = @RequestGroupId;

    /*Section="End"*/
END;
