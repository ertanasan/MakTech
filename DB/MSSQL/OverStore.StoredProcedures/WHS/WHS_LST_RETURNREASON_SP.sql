-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_RETURNREASON_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           R.RETURNREASONID,
           R.REASON_NM,
           R.PARENT
      FROM WHS_RETURNREASON R (NOLOCK)
     ORDER BY REASON_NM;

/*Section="End"*/
END;
