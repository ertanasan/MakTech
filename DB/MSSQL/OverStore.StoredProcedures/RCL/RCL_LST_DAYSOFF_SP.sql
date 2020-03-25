-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_LST_DAYSOFF_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           D.DAYSOFFID,
           D.STORE,
           D.OFFDAY_DT
      FROM RCL_DAYSOFF D (NOLOCK);

/*Section="End"*/
END;
