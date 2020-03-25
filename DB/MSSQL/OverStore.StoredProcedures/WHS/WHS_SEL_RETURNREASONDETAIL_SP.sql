-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_RETURNREASONDETAIL_SP
    @ReturnReasonDetailId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           R.RETURNREASONDETAILID,
           R.RETURNREASON,
           R.DETAIL_NM      
      FROM WHS_RETURNREASONDETAIL R (NOLOCK)
     WHERE R.RETURNREASONDETAILID = @ReturnReasonDetailId;

    /*Section="End"*/
END;
