-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_RETURNSTATUS_SP
    @ReturnStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           R.RETURNSTATUSID,
           R.STATUS_NM      
      FROM WHS_RETURNSTATUS R (NOLOCK)
     WHERE R.RETURNSTATUSID = @ReturnStatusId;

    /*Section="End"*/
END;
