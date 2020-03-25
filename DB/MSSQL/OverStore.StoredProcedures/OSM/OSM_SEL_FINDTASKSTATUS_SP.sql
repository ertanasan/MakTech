-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_SEL_FINDTASKSTATUS_SP
    @Status VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           T.TASKSTATUSID,
           T.STATUS_NM      
      FROM OSM_TASKSTATUS T (NOLOCK)
     WHERE T.STATUS_NM = @Status;

/*Section="End"*/
END;
