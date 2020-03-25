-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_SEL_CONTRACTPARAMETER_SP
    @ContractParameterId INT
AS
BEGIN

    /*Section="Query"*/
    -- Select
    SELECT
           C.CONTRACTPARAMETERID,
           C.PARAMETER_NM,
           C.VALUE_TXT      
      FROM FIN_CONTRACTPARAMETER C (NOLOCK)
     WHERE C.CONTRACTPARAMETERID = @ContractParameterId;

    /*Section="End"*/
END;
