-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_PROCESSDEF_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           P.PROCESSDEFID,
           P.PROCESSDEF_NM,
           P.PROCESS_NO
      FROM HDK_PROCESSDEF P (NOLOCK)
     ORDER BY PROCESSDEF_NM;

/*Section="End"*/
END;
