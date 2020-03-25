-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_PROCESSDEF_SP
    @ProcessDefinitionId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           P.PROCESSDEFID,
           P.PROCESSDEF_NM,
           P.PROCESS_NO
      FROM HDK_PROCESSDEF P (NOLOCK)
     WHERE P.PROCESSDEFID = @ProcessDefinitionId;

    /*Section="End"*/
END;
