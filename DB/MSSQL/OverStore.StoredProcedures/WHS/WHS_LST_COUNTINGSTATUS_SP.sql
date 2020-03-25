-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_COUNTINGSTATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.COUNTINGSTATUSID,
           C.COUNTINGSTATUS_NM
      FROM WHS_COUNTINGSTATUS C (NOLOCK);

/*Section="End"*/
END;
