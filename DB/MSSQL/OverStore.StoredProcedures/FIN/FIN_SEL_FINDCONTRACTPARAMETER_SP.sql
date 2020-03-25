-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_SEL_FINDCONTRACTPARAMETER_SP
    @ParameterName VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           C.CONTRACTPARAMETERID,
           C.PARAMETER_NM,
           C.VALUE_TXT      
      FROM FIN_CONTRACTPARAMETER C (NOLOCK)
     WHERE C.PARAMETER_NM = @ParameterName;

/*Section="End"*/
END;
