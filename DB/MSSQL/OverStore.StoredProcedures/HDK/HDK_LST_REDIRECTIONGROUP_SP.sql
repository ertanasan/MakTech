-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_REDIRECTIONGROUP_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           R.REDIRECTIONGROUPID,
           R.GROUP_NM,
           R.REQUESTDEFINITION
      FROM HDK_REDIRECTIONGROUP R (NOLOCK)
     ORDER BY GROUP_NM;

/*Section="End"*/
END;
