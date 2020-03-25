-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_SEL_TASKTYPE_SP
    @OverStoreTaskTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           T.TASKTYPEID,
           T.TYPE_NM      
      FROM OSM_TASKTYPE T (NOLOCK)
     WHERE T.TASKTYPEID = @OverStoreTaskTypeId;

    /*Section="End"*/
END;
