-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_REQUESTDEF_SP
    @RequestDefinitionId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           R.REQUESTDEFID,
           R.REQUESTDEF_NM,
           R.REQUESTGROUP,
           R.PROCESS,
           R.MICROCODE_TXT,
           R.DISPLAYORDER_NO,
           R.ACTIVE_FL
      FROM HDK_REQUESTDEF R (NOLOCK)
     WHERE R.REQUESTDEFID = @RequestDefinitionId;

    /*Section="End"*/
END;
