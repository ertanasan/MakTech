-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_COUNTINGSTATUS_SP
    @CountingStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.COUNTINGSTATUSID,
           C.COUNTINGSTATUS_NM      
      FROM WHS_COUNTINGSTATUS C (NOLOCK)
     WHERE C.COUNTINGSTATUSID = @CountingStatusId;

    /*Section="End"*/
END;
