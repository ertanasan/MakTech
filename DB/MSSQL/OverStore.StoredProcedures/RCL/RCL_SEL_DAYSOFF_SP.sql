-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE RCL_SEL_DAYSOFF_SP
    @DaysOffId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           D.DAYSOFFID,
           D.STORE,
           D.OFFDAY_DT      
      FROM RCL_DAYSOFF D (NOLOCK)
     WHERE D.DAYSOFFID = @DaysOffId;

    /*Section="End"*/
END;
