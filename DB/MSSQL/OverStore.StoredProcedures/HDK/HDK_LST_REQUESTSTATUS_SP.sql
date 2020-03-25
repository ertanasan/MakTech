-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_LST_REQUESTSTATUS_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           R.REQUESTSTATUSID,
           R.STATUS_NM
      FROM HDK_REQUESTSTATUS R (NOLOCK)
     ORDER BY REQUESTSTATUSID;

/*Section="End"*/
END;
