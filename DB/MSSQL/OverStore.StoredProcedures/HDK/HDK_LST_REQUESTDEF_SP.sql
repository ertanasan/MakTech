-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_REQUESTDEF_SP
    @RequestGroup INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           R.REQUESTDEFID,
           R.REQUESTDEF_NM,
           R.REQUESTGROUP,
           R.PROCESS,
           R.MICROCODE_TXT,
           R.DISPLAYORDER_NO,
           R.ACTIVE_FL
      FROM HDK_REQUESTDEF R (NOLOCK)
     WHERE (@RequestGroup IS NULL OR R.REQUESTGROUP = @RequestGroup)
     ORDER BY REQUESTDEF_NM;

/*Section="End"*/
END;
