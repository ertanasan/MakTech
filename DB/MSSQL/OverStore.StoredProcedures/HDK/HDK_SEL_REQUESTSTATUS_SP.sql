-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE HDK_SEL_REQUESTSTATUS_SP
    @RequestStatusId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           R.REQUESTSTATUSID,
           R.STATUS_NM      
      FROM HDK_REQUESTSTATUS R (NOLOCK)
     WHERE R.REQUESTSTATUSID = @RequestStatusId;

    /*Section="End"*/
END;
