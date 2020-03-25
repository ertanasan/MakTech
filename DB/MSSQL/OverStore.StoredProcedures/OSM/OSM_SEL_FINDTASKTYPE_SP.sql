-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_SEL_FINDTASKTYPE_SP
    @TaskType VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           T.TASKTYPEID,
           T.TYPE_NM      
      FROM OSM_TASKTYPE T (NOLOCK)
     WHERE T.TYPE_NM = @TaskType;

/*Section="End"*/
END;
