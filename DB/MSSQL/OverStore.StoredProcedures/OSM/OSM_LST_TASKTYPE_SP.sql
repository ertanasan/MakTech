-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_LST_TASKTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           T.TASKTYPEID,
           T.TYPE_NM
      FROM OSM_TASKTYPE T (NOLOCK)
     ORDER BY TYPE_NM;

/*Section="End"*/
END;
