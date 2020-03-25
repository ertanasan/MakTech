-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_REQUESTGROUP_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           R.REQUESTGROUPID,
           R.REQUESTGROUP_NM,
           R.DISPLAYORDER_NO,
           R.ACTIVE_FL
      FROM HDK_REQUESTGROUP R (NOLOCK)
     ORDER BY REQUESTGROUP_NM;

/*Section="End"*/
END;
