-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_RETURNREASONDETAIL_SP
    @ReturnReason INT = NULL
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           R.RETURNREASONDETAILID,
           R.RETURNREASON,
           R.DETAIL_NM
      FROM WHS_RETURNREASONDETAIL R (NOLOCK)
     WHERE (@ReturnReason IS NULL OR R.RETURNREASON = @ReturnReason)
     ORDER BY DETAIL_NM;

/*Section="End"*/
END;
