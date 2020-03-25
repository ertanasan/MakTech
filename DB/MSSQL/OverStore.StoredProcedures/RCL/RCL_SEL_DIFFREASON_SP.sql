-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_DIFFREASON_SP
    @DiffReasonId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           D.DIFFREASONID,
           D.REASON_NM,
           D.SHORT_FL      
      FROM RCL_DIFFREASON D (NOLOCK)
     WHERE D.DIFFREASONID = @DiffReasonId;

    /*Section="End"*/
END;
