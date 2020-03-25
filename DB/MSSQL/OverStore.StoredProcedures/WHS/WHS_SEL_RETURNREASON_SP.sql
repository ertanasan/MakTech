-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_RETURNREASON_SP
    @ReturnReasonId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           R.RETURNREASONID,
           R.REASON_NM,
           R.PARENT
      FROM WHS_RETURNREASON R (NOLOCK)
     WHERE R.RETURNREASONID = @ReturnReasonId;

    /*Section="End"*/
END;
