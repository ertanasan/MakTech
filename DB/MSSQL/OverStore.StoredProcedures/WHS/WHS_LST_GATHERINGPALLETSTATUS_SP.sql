﻿-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_GATHERINGPALLETSTATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           G.GATHERINGPALLETSTATUSID,
           G.STATUS_NM
      FROM WHS_GATHERINGPALLETSTATUS G (NOLOCK)
     ORDER BY GATHERINGPALLETSTATUSID;

/*Section="End"*/
END;
