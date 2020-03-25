-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_INTAKESTATUSTYPE_SP
    @IntakeStatusTypeId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           I.INTAKESTATUSTYPEID,
           I.INTAKESTATUSTYPE_NM      
      FROM WHS_INTAKESTATUSTYPE I (NOLOCK)
     WHERE I.INTAKESTATUSTYPEID = @IntakeStatusTypeId;

    /*Section="End"*/
END;
