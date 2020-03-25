-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_LST_CONSTRAINTEXCEPTION_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CONSTRAINTEXCEPTIONID,
           C.STORE,
           C.STARTDATE_DT,
           C.ENDDATE_DT,
           C.CATEGORY,
           C.SUBGROUP,
           C.PRODUCT,
           C.COEFFICIENT_RT
      FROM WHS_CONSTRAINTEXCEPTION C (NOLOCK);

/*Section="End"*/
END;
