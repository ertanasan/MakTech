-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_LST_DIFFREASON_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           D.DIFFREASONID,
           D.REASON_NM,
           D.SHORT_FL
      FROM RCL_DIFFREASON D (NOLOCK)
     ORDER BY REASON_NM;

/*Section="End"*/
END;
