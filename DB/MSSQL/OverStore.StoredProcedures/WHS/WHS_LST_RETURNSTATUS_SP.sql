-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_RETURNSTATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           R.RETURNSTATUSID,
           R.STATUS_NM
      FROM WHS_RETURNSTATUS R (NOLOCK)
     ORDER BY STATUS_NM;

/*Section="End"*/
END;
