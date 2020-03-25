-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE ACC_LST_EXPENSECENTER_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           E.EXPENSECENTERID,
           E.EXPENSECENTER_NM,
           E.EXPENSECENTERCODE_TXT,
           E.CENTERGROUP_NO,
           E.REGIONMANAGER,
           E.STORE,
           E.ACTIVE_FL
      FROM ACC_EXPENSECENTER E (NOLOCK)
     ORDER BY EXPENSECENTER_NM;

/*Section="End"*/
END;
