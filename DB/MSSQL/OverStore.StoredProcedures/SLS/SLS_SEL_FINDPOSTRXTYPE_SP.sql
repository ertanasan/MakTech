-- Created by OverGenerator
/*Section="Main"*/
CREATE PROCEDURE SLS_SEL_FINDPOSTRXTYPE_SP
    @TrxType VARCHAR(100)
AS
BEGIN
    /*Section="Query"*/
    -- Select
    SELECT
           P.POSTRXTYPEID,
           P.TRXTYPE_NM      
      FROM SLS_POSTRXTYPE P (NOLOCK)
     WHERE P.TRXTYPE_NM = @TrxType;

/*Section="End"*/
END;
