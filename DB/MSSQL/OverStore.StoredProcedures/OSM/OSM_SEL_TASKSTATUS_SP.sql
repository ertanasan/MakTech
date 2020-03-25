-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_SEL_TASKSTATUS_SP
    @OverStoreTaskStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           T.TASKSTATUSID,
           T.STATUS_NM      
      FROM OSM_TASKSTATUS T (NOLOCK)
     WHERE T.TASKSTATUSID = @OverStoreTaskStatusId;

    /*Section="End"*/
END;
