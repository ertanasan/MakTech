-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE WHS_SEL_CONSTRAINTEXCEPTION_SP
    @ConstraintExceptionId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CONSTRAINTEXCEPTIONID,
           C.STORE,
           C.STARTDATE_DT,
           C.ENDDATE_DT,
           C.CATEGORY,
           C.SUBGROUP,
           C.PRODUCT,
           C.COEFFICIENT_RT      
      FROM WHS_CONSTRAINTEXCEPTION C (NOLOCK)
     WHERE C.CONSTRAINTEXCEPTIONID = @ConstraintExceptionId;

    /*Section="End"*/
END;
