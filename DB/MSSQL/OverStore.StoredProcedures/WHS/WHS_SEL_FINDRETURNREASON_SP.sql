-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_FINDRETURNREASON_SP
    @ReasonName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           R.RETURNREASONID,
           R.REASON_NM,
           R.PARENT
      FROM WHS_RETURNREASON R (NOLOCK)
     WHERE R.REASON_NM = @ReasonName;

/*Section="End"*/
END;
