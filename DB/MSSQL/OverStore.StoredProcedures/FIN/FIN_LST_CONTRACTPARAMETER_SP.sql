-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE FIN_LST_CONTRACTPARAMETER_SP
AS
BEGIN
    /*Section="Query"*/
    -- Select all
    SELECT
           C.CONTRACTPARAMETERID,
           C.PARAMETER_NM,
           C.VALUE_TXT
      FROM FIN_CONTRACTPARAMETER C (NOLOCK)
     ORDER BY CONTRACTPARAMETERID;

/*Section="End"*/
END;
