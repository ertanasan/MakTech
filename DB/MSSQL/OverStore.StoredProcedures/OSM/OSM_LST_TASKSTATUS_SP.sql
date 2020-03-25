-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE OSM_LST_TASKSTATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           T.TASKSTATUSID,
           T.STATUS_NM
      FROM OSM_TASKSTATUS T (NOLOCK)
     ORDER BY STATUS_NM;

/*Section="End"*/
END;
