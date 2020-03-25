-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_INTAKESTATUSTYPE_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           I.INTAKESTATUSTYPEID,
           I.INTAKESTATUSTYPE_NM
      FROM WHS_INTAKESTATUSTYPE I (NOLOCK);

/*Section="End"*/
END;
